namespace BookYourHoliday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Reference = c.String(),
                        HotelTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelTypes", t => t.HotelTypes_Id)
                .Index(t => t.HotelTypes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "HotelTypes_Id", "dbo.HotelTypes");
            DropIndex("dbo.Reservations", new[] { "HotelTypes_Id" });
            DropTable("dbo.Reservations");
            DropTable("dbo.HotelTypes");
        }
    }
}
