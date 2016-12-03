using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Trains
{
    public class TrainEntity
    {
        public TrainEntity()
        {
            Stops = new List<StopEntity>();
        }
        public int Id { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public DateTime DepartureTime { get; set; }
        public virtual TrainKind TrainKind { get; set; }
        public virtual DateTime ArrivalTime { get; set; }
        public double Distance { get; set; }
        public virtual ICollection<StopEntity> Stops { get; set; }
    }
}
