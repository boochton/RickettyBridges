using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RickettyBridges.API.Models
{
    using System.Runtime.Serialization;

    public class Asset
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public virtual DeckType DeckType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Inspection Number.
        /// </summary>
        public string InspectionNumber { get; set; }

        /// <summary>
        /// Gets or sets the Inspection Date
        /// </summary>
        public string InspectionDate { get; set; }

        /// <summary>
        /// Gets or sets the Structure Number.
        /// </summary>
        public string StructureNumber { get; set; }

        /// <summary>
        /// Is Maintenance Required?
        /// </summary>
        public bool IsMaintenanceRequired { get; set; }

        /// <summary>
        /// Is Highway Bridge?
        /// </summary>
        public bool IsHighwayBridge { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        public string Owner { get; set; }
    }
}