using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace OOP2_Trains
{
    public class TrainNet
    {
        private List<KindTrain> _trains;
        private TrainContext trainContext;

        public TrainNet(List<KindTrain> trains)
        {
            _trains = trains;
            trainContext = new TrainContext();
            //var lines = File.ReadAllLines(fileName);
            //if (lines.Any())
            //{
            //    foreach (var line in lines)
            //    {
            //        Dictionary<string, DateTime> stopsDict = new Dictionary<string, DateTime>();
            //        var items = line.Split(',');
            //        var stops = items[2].Split(' ');
            //        foreach (var stop in stops)
            //        {
            //            var pair = stop.Split('-');
            //            stopsDict.Add(pair[0], Convert.ToDateTime(pair[1]));
            //        }

            //        _trains.Add(new KindTrain(
            //            (TrainKind)int.Parse(items[0]),
            //            Convert.ToDateTime(items[1]),
            //            stopsDict,
            //            items[3],
            //            items[4],
            //            Convert.ToDateTime(items[5]),
            //            double.Parse(items[6])
            //            ));
            //    }
            //}
        }
        private TrainEntity ToTrainEntity(KindTrain train)
        {
            return new TrainEntity()
            {
                ArrivalTime = train.ArrivalTime,
                DepartureTime = train.DepartureTime,
                Distance = train.Distance,
                FirstStation = train.FirstStation,
                LastStation = train.LastStation,
                TrainKind = train.TrainKind,
            };
        }

        private StopEntity ToStopEntity(KeyValuePair<string, DateTime> t, TrainEntity enteredTrain)
        {
            return new StopEntity()
            {
                Station = t.Key,
                ArrivalTime = t.Value,
                TrainEntityId = enteredTrain.Id
            };
        }

        public void AddTrain(KindTrain train)
        {
            _trains.Add(train);
            TrainEntity trainEntity = ToTrainEntity(train);
            var enteredTrain = trainContext.KindTrains.Add(trainEntity);
            trainContext
                .Stops
                .AddRange(train
                    .Stops
                    .Select(t => ToStopEntity(t, enteredTrain)));
            trainContext.SaveChanges();
        }

        public void DeleteTrain(KindTrain train)
        {
            _trains.Remove(train);
            trainContext.KindTrains.Remove(ToTrainEntity(train));
            var stops = trainContext.Stops.Where(t => t.TrainEntityId == train.Id);
            trainContext.Stops.RemoveRange(stops);
            trainContext.SaveChanges();
        }

        public void UpdateTrain(KindTrain train)
        {
            KindTrain listTrain = _trains.Where(t => t.Id == train.Id).FirstOrDefault();
            _trains.Remove(listTrain);
            _trains.Add(train);
            trainContext.KindTrains.AddOrUpdate(ToTrainEntity(train));
            trainContext.SaveChanges();
        }

        public IEnumerable<KindTrain> GetTrains(string fStation, string lStation)
        {
            return _trains.Where(t => t.FirstStation.ToLower() == fStation.ToLower().Trim() 
                && t.LastStation.ToLower() == lStation.ToLower().Trim()).AsEnumerable();
        }

        public IEnumerable<KindTrain> GetTrainsBeforeDeparture(string fStation, string lStation, DateTime hour)
        {
            var gt = GetTrains(fStation, lStation);
            return GetTrains(fStation, lStation).Where(t => t.DepartureTime < hour);
        }

        public KindTrain GetFastestTrain(string fStation, string lStation)
        {
            return GetTrains(fStation, lStation).OrderBy(t => t.TrainSpeed()).FirstOrDefault();
        }

        public double GetAverageSpeed(TrainKind trainKind)
        {
            double sumOfSpeed = _trains.Where(t => t.TrainKind == trainKind).Select(t => t.TrainSpeed()).Sum();
            double trainCount = _trains.Where(t => t.TrainKind == trainKind).Count();
            if (trainCount == 0)
            {
                return 0;
            }
            return sumOfSpeed / trainCount;
        }

        public IEnumerable<KindTrain> GetTrainsBeforeArrival(string fStation, string lStation, DateTime hour)
        {
            return GetTrains(fStation, lStation).Where(t => t.ArrivalTime < hour);
        }
    }
}
