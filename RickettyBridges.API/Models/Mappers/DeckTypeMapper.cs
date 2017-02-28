using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Models.Mappers
{
    using RickettyBridges.API.Util;

    internal static class DeckTypeMapper
    {
        internal static DeckType AsModel(this DAL.Entities.DeckType entity)
        {
            Assert.IsNotNull(entity, "entity");

            return new DeckType { Id = entity.Id.ToString(), Value = entity.Value };
        }

        internal static List<DeckType> AsModels(this IEnumerable<DAL.Entities.DeckType> entities)
        {
            Assert.IsNotNull(entities, "entities");

            return entities.Select(entity => entity.AsModel()).ToList();
        }

        internal static DAL.Entities.DeckType AsEntity(this DeckType model)
        {
            Assert.IsNotNull(model, "model");

            return new DAL.Entities.DeckType { Id = Convert.ToInt32(model.Id), Value = model.Value };
        }

        internal static List<DAL.Entities.DeckType> AsEntities(this IEnumerable<DeckType> models)
        {
            Assert.IsNotNull(models, "models");

            return models.Select(model => model.AsEntity()).ToList();
        }
    }
}