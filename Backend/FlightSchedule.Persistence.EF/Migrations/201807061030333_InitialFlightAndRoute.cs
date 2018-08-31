namespace FlightSchedule.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialFlightAndRoute : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DepartDate = c.DateTime(nullable: false),
                        AirCraft = c.String(),
                        FlightNo = c.String(),
                        Route_Origin = c.String(),
                        Route_Destination = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Flights");
        }
    }
}
