using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Controllers
{
    using System.Diagnostics;
    using System.Web.Http;

    using log4net;

    using RickettyBridges.API.Autofac.Attributes;
    using RickettyBridges.API.Messages;
    using RickettyBridges.API.Models.Mappers;
    using RickettyBridges.API.Util;
    using RickettyBridges.DAL.Entities;
    using RickettyBridges.DAL.Enums;
    using RickettyBridges.DAL.Interfaces;

    using WebGrease.Css.Extensions;

    public class AssetController : ApiControllerBase
    {
        private readonly IRickettyBridgeService _dal;

        public AssetController(ILog logger, IRickettyBridgeService rickettyBridgeDal)
            : base(logger)
        {
            Assert.IsNotNull(rickettyBridgeDal, "rickettyBridgeDal");

            _dal = rickettyBridgeDal;
        }

        [HttpGet]
        [EnableInterceptor]
        public virtual AssetSearchResponse Owner(string owner)
        {
            Assert.IsNotNull(owner, "owner");

            var criteriaFilters = new List<AssetCriteriaFilter>
                                  {
                                      new AssetCriteriaFilter
                                      {
                                          FieldNameEnum = AssetSearchCriteria.Owner, 
                                          Value = owner
                                      }
                                  };

            var criteria = new AssetListCriteria
                           {
                               AssetFilter = criteriaFilters
                           };

            var results = _dal.GetAssets(criteria);

            var response = new AssetSearchResponse();                   

            if (results.Any())
            {
                results.ForEach(r => response.Assets.Add(r.AsModel()));
            }

            return response;
        }

        [HttpGet]
        [EnableInterceptor]
        public virtual Models.Asset Id(int id)
        {
            Assert.IsNotNull(id, "id");

            var result = _dal.GetAsset(id);

            return result.AsModel();
        }

        [HttpPost]
        [EnableInterceptor]
        public virtual Models.Asset Save(Models.Asset asset)
        {
            Assert.IsNotNull(asset, "asset");

            // TODO: Should really have some validations at this point!!

            var id = _dal.SaveAsset(asset.AsEntity());

            var savedAsset = _dal.GetAsset(id);

            return savedAsset.AsModel();
        }
    }
}
