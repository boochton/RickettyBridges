using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Messages
{
    using RickettyBridges.API.Models;

    public class AssetSaveRequest
    {
        public Asset Asset { get; set; }
    }
}