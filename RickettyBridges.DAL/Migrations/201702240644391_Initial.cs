namespace RickettyBridges.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeckTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        InspectionNumber = c.String(maxLength: 255),
                        InspectionDate = c.DateTime(),
                        StructureNumber = c.String(maxLength: 255),
                        IsMaintenanceRequired = c.Boolean(nullable: false),
                        IsHighwayBridge = c.Boolean(nullable: false),
                        Owner = c.String(nullable: false, maxLength: 255),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeckTypes", t => t.DeckTypeId)
                .Index(t => t.DeckTypeId);
            
            CreateTable(
                "dbo.DeckTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false, maxLength: 255),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "DeckTypeId", "dbo.DeckTypes");
            DropIndex("dbo.Assets", new[] { "DeckTypeId" });
            DropTable("dbo.DeckTypes");
            DropTable("dbo.Assets");
        }
    }
}
