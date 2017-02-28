using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RickettyBridges.API.Controllers
{
    using log4net;

    using RickettyBridges.API.Autofac.Attributes;
    using RickettyBridges.API.Messages;
    using RickettyBridges.API.Models.Mappers;
    using RickettyBridges.API.Util;
    using RickettyBridges.DAL.Entities;
    using RickettyBridges.DAL.Enums;
    using RickettyBridges.DAL.Interfaces;

    using WebGrease.Css.Extensions;

    public class ReferenceDataController : ApiControllerBase
    {
        private readonly IRickettyBridgeService _dal;

        public ReferenceDataController(ILog logger, IRickettyBridgeService rickettyBridgeDal)
            : base(logger)
        {
            Assert.IsNotNull(rickettyBridgeDal, "rickettyBridgeDal");

            _dal = rickettyBridgeDal;
        }

        [HttpGet]
        [EnableInterceptor]
        [Route("api/GetDeckTypes")]
        public virtual IEnumerable<Models.DeckType> GetDeckTypes()
        {
            var results = _dal.GetDeckTypes();
            var response = new List<Models.DeckType>();
            if (results.Any())
            {
                foreach (var result in results)
                {
                    response.Add(result.AsModel());
                }
            }

            return response;
        }
    }
}
