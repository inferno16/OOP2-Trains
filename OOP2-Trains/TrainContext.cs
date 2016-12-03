using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Trains
{
    public class TrainContext : DbContext
    {
        public TrainContext() : base("name=TrainsContext")
        {

        }
        public virtual DbSet<TrainEntity> KindTrains { get; set; }
        public virtual DbSet<StopEntity> Stops { get; set; }
    }
}
