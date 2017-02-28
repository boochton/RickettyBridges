using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Models.Mappers
{
    using System.Data.SqlTypes;

    using RickettyBridges.API.Util;

    internal static class AssetMapper
    {
        internal static Asset AsModel(this DAL.Entities.Asset entity)
        {
            Assert.IsNotNull(entity, "entity");

            return new Asset
                       {
                           Id = entity.Id,
                           DeckType = entity.DeckType.AsModel(),
                           InspectionDate = entity.InspectionDate.HasValue ? entity.InspectionDate.Value.ToString("yyyy-MM-dd") : "",
                           InspectionNumber = entity.InspectionNumber,
                           IsHighwayBridge = entity.IsHighwayBridge,
                           IsMaintenanceRequired = entity.IsMaintenanceRequired,
                           Name = entity.Name,
                           Owner = entity.Owner,
                           StructureNumber = entity.StructureNumber
                       };
        }

        internal static List<Asset> AsModels(this IEnumerable<DAL.Entities.Asset> entities)
        {
            Assert.IsNotNull(entities, "entities");

            return entities.Select(entity => entity.AsModel()).ToList();
        }

        internal static DAL.Entities.Asset AsEntity(this Asset model)
        {
            Assert.IsNotNull(model, "model");
            var inspectionDate = (DateTime)SqlDateTime.MinValue;
            Assert.IsDate(model.InspectionDate, "model.InspectionDate", out inspectionDate);
            
            return new DAL.Entities.Asset
            {
                Id = model.Id,
                DeckTypeId = Convert.ToInt32(model.DeckType.Id),
                InspectionDate = inspectionDate,
                InspectionNumber = model.InspectionNumber,
                IsHighwayBridge = model.IsHighwayBridge,
                IsMaintenanceRequired = model.IsMaintenanceRequired,
                Name = model.Name,
                Owner = model.Owner,
                StructureNumber = model.StructureNumber
            };
        }

        internal static List<DAL.Entities.Asset> AsEntities(this IEnumerable<Asset> models)
        {
            Assert.IsNotNull(models, "models");

            return models.Select(entity => entity.AsEntity()).ToList();
        }
    }
}