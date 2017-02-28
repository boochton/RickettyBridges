using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickettyBridges.DAL.Config
{
    using System.Data.Entity.ModelConfiguration;

    using RickettyBridges.DAL.Entities;

    /// <summary>
    /// The asset map.
    /// </summary>
    internal class AssetConfig : EntityTypeConfiguration<Asset>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConfig"/> class.
        /// </summary>
        public AssetConfig()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(255);
            Property(p => p.Owner).IsRequired().HasMaxLength(255);
            Property(p => p.InspectionNumber).HasMaxLength(255);
            Property(p => p.StructureNumber).HasMaxLength(255);
            Property(p => p.TimeStamp).IsRowVersion();
        }
        #endregion
    }

    /// <summary>
    /// The deck type map.
    /// </summary>
    internal class DeckTypeConfig : EntityTypeConfiguration<DeckType>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DeckTypeConfig"/> class.
        /// </summary>
        public DeckTypeConfig()
        {
            Property(p => p.Value).IsRequired().HasMaxLength(255);
            Property(p => p.TimeStamp).IsRowVersion();
        }

        #endregion
    }
}
