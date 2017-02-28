namespace RickettyBridges.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using RickettyBridges.DAL.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<RickettyBridgesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RickettyBridgesContext context)
        {
            context.DeckTypes.AddOrUpdate(dt => dt.Id, new DeckType { Id = 1, Value = "Concrete" });
            context.DeckTypes.AddOrUpdate(dt => dt.Id, new DeckType { Id = 2, Value = "Steel" });
            context.DeckTypes.AddOrUpdate(dt => dt.Id, new DeckType { Id = 3, Value = "Sealed" });
            context.DeckTypes.AddOrUpdate(dt => dt.Id, new DeckType { Id = 4, Value = "Wood" });
            context.DeckTypes.AddOrUpdate(dt => dt.Id, new DeckType { Id = 5, Value = "Earth" });

            context.Assets.AddOrUpdate(a => a.Id, 
                                       new Asset
                                       {
                                           Id = 1,
                                           DeckTypeId = 1,
                                           IsHighwayBridge = false,
                                           IsMaintenanceRequired = true,
                                           InspectionDate = new DateTime(2017, 02, 24),
                                           StructureNumber = "Test Structure Number",
                                           InspectionNumber = "Test Inspection Number",
                                           Name = "Inspection Report 1.1",
                                           Owner = "Inspector1"
                                       });

            context.Assets.AddOrUpdate(a => a.Id,
                                       new Asset
                                       {
                                           Id = 1,
                                           DeckTypeId = 4,
                                           IsHighwayBridge = false,
                                           IsMaintenanceRequired = false,
                                           InspectionDate = new DateTime(2017, 02, 22),
                                           StructureNumber = "Test Structure Number 1",
                                           InspectionNumber = "Test Inspection Number 1",
                                           Name = "Bridge Health 2.1",
                                           Owner = "Inspector2"
                                       });

            context.Assets.AddOrUpdate(a => a.Id,
                                       new Asset
                                       {
                                           Id = 1,
                                           DeckTypeId = 4,
                                           IsHighwayBridge = false,
                                           IsMaintenanceRequired = false,
                                           InspectionDate = new DateTime(2017, 02, 23),
                                           StructureNumber = "Test Structure Number 2",
                                           InspectionNumber = "Test Inspection Number 2",
                                           Name = "Bridge Health 2.2",
                                           Owner = "Inspector2"
                                       });
        }
    }
}
