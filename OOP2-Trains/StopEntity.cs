using System;

namespace OOP2_Trains
{
    public class StopEntity
    {
        public int Id { get; set; }
        public string Station { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TrainEntityId { get; set; }
    }
}