using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Messages
{
    using RickettyBridges.API.Models;

    public class AssetSearchResponse
    {
        public AssetSearchResponse()
        {
            Assets = new List<Asset>();
        }

        public List<Asset> Assets { get; set; }
    }
}