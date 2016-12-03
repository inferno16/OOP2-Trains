namespace OOP2_Trains.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TrainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OOP2_Trains.TrainContext";
        }

        protected override void Seed(TrainContext context)
        {
            context.KindTrains.Add(new TrainEntity()
            {
                ArrivalTime = new DateTime(2017, 1, 20, 10, 20, 30),
                DepartureTime = new DateTime(2017, 1, 20, 12, 30, 12),
                Distance = 320,
                FirstStation = "София",
                LastStation = "Габрово",
                TrainKind = TrainKind.Express
            });

            context.KindTrains.Add(new TrainEntity()
            {
                ArrivalTime = new DateTime(2017, 3, 20, 10, 20, 30),
                DepartureTime = new DateTime(2017, 3, 20, 12, 30, 12),
                Distance = 350,
                FirstStation = "Варна",
                LastStation = "Лом",
                TrainKind = TrainKind.Fast
            });

            context.SaveChanges();

            context.Stops.Add(new StopEntity()
            {
                ArrivalTime = new DateTime(2017, 1, 20, 10, 20, 30),
                Station = "София",
                TrainEntityId = 1
            });

            context.Stops.Add(new StopEntity()
            {
                ArrivalTime = new DateTime(2017, 1, 20, 10, 30, 20),
                Station = "Пловдив",
                TrainEntityId = 1
            });

            context.Stops.Add(new StopEntity()
            {
                ArrivalTime = new DateTime(2017, 1, 20, 12, 30, 12),
                Station = "Габрово",
                TrainEntityId = 1
            });

            context.Stops.Add(new StopEntity()
            {
                ArrivalTime = new DateTime(2017, 3, 20, 10, 20, 30),
                Station = "Варна",
                TrainEntityId = 2
            });

            context.Stops.Add(new StopEntity()
            {
                ArrivalTime = new DateTime(2017, 3, 20, 10, 40, 30),
                Station = "Русе",
                TrainEntityId = 2
            });

            context.Stops.Add(new StopEntity()
            {
                ArrivalTime = new DateTime(2017, 3, 20, 12, 30, 12),
                Station = "Лом",
                TrainEntityId = 2
            });
            context.SaveChanges();
        }
    }
}
