namespace OOP2_Trains.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstStation = c.String(),
                        LastStation = c.String(),
                        DepartureTime = c.DateTime(nullable: false),
                        TrainKind = c.Int(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        Distance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StopEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Station = c.String(),
                        ArrivalTime = c.DateTime(nullable: false),
                        TrainEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainEntities", t => t.TrainEntityId, cascadeDelete: true)
                .Index(t => t.TrainEntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StopEntities", "TrainEntityId", "dbo.TrainEntities");
            DropIndex("dbo.StopEntities", new[] { "TrainEntityId" });
            DropTable("dbo.StopEntities");
            DropTable("dbo.TrainEntities");
        }
    }
}
