using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Trains
{
    public abstract class Train
    {
        protected DateTime _departureTime;
        protected double _distance;
        protected string _firstStation;
        protected string _lastStation;

        public Train(string firstStation, string lastStation, DateTime departureTime, double distance)
        {
            _firstStation = firstStation;
            _lastStation = lastStation;
            _departureTime = departureTime;
            _distance = distance;
        }

        public abstract void Print();
        public abstract double TrainSpeed();
        public abstract DateTime GetStation(string station);

        public abstract string TimeToArrival(string station);
    }
}
