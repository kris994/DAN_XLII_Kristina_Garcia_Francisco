namespace DAN_XLII_Kristina_Garcia_Francisco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class worker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblLocations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationAddress = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        JMBG = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        IDCard = c.String(),
                        PhoneNumber = c.String(),
                        LocationID = c.Int(nullable: false),
                        SectorID = c.Int(nullable: false),
                        MenagerID = c.Int(),
                        Manager_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.tblUsers", t => t.Manager_UserID)
                .ForeignKey("dbo.tblLocations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.tblSectors", t => t.SectorID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.SectorID)
                .Index(t => t.Manager_UserID);
            
            CreateTable(
                "dbo.tblSectors",
                c => new
                    {
                        SectorID = c.Int(nullable: false, identity: true),
                        SectorName = c.String(),
                    })
                .PrimaryKey(t => t.SectorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUsers", "SectorID", "dbo.tblSectors");
            DropForeignKey("dbo.tblUsers", "LocationID", "dbo.tblLocations");
            DropForeignKey("dbo.tblUsers", "Manager_UserID", "dbo.tblUsers");
            DropIndex("dbo.tblUsers", new[] { "Manager_UserID" });
            DropIndex("dbo.tblUsers", new[] { "SectorID" });
            DropIndex("dbo.tblUsers", new[] { "LocationID" });
            DropTable("dbo.tblSectors");
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblLocations");
        }
    }
}
