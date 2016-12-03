using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOP2_Trains
{
    public class KindTrain : Train
    {
        private TrainKind _kTr;
        private DateTime _arrivalTime;
        private Dictionary<string, DateTime> _stopsInfo;
        private int _id;
        public KindTrain(int id, TrainKind kTr, DateTime arrTime, Dictionary<string, DateTime> stops, string firstStation, string lastStation, DateTime departureTime, double distance)
            : base(firstStation, lastStation, departureTime, distance)
        {
            _id = id;
            _kTr = kTr;
            _arrivalTime = arrTime;
            _stopsInfo = stops;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string FirstStation { get { return _firstStation; } set { _firstStation = value; } }

        public string LastStation { get { return _lastStation; } set { _lastStation = value; } }

        public DateTime DepartureTime { get { return _departureTime; } set { _departureTime = value; } }

        public DateTime ArrivalTime { get { return _arrivalTime; } set { _arrivalTime = value; } }

        public TrainKind TrainKind { get { return _kTr; } set { _kTr = value; } }

        public double Distance { get { return _distance; } set { _distance = value; } }

        public Dictionary<string, DateTime> Stops { get { return _stopsInfo; } set { _stopsInfo = value; } }
        public override void Print()
        {
            string kind = _kTr.ToString("D"); // converts enum to string representation
            string stops = string.Join("\n", _stopsInfo.Select(s => s.Key + ": " + s.Value).ToArray());
            string output = string
                .Format(" Вид влак :{0}, Време на тръгване: {1}, Време на пристигане: {2} Първа гара: {3}, Последна гара:{4}, Спирки:\n{5}",
                    kind, _arrivalTime, _departureTime, _firstStation, _lastStation, stops);
            MessageBox.Show(output);
        }

        public override double TrainSpeed()
        {
            double time = (_departureTime - _arrivalTime).TotalSeconds;
            time = time - (_stopsInfo.Count - 2) * 300;
            double hour = time / 3600.0;
            double kmH = _distance / hour;
            return kmH;
        }

        public override DateTime GetStation(string station)
        {
            return _stopsInfo
                .Where(k => k.Key == station)
                .Select(k => k.Value)
                .FirstOrDefault();
        }

        public override string TimeToArrival(string station)
        {
            DateTime time = GetStation(station);
            return (_departureTime - time).TotalSeconds.ToString();
        }
    }
}
