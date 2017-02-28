using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickettyBridges.DAL.Entities
{
    using System.Data.SqlTypes;
    using System.Linq.Expressions;

    using RickettyBridges.DAL.Entities.Base;

    /// <summary>
    /// The asset.
    /// </summary>
    public class Asset : EntityBase
    {
        #region Public Properties

        /// <summary>
        ///  Gets or sets the deck type id.
        /// </summary>
        public int DeckTypeId { get; set; }

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
        public DateTime? InspectionDate { get; set; }

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

        #endregion

        #region LINQ Predicates

        /// <summary>
        /// The name like.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<Asset, bool>> NameLike(string name)
        {
            return p => p.Name.Contains(name);
        }

        /// <summary>
        /// The model like.
        /// </summary>
        /// <param name="inspectionNumber">
        /// The inspectionNumber.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<Asset, bool>> InspectionNumberLike(string inspectionNumber)
        {
            return p => p.InspectionNumber.Contains(inspectionNumber);
        }

        /// <summary>
        /// The manufacturer like.
        /// </summary>
        /// <param name="structureNumber">
        /// The structureNumber.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<Asset, bool>> StructureNumberLike(string structureNumber)
        {
            return p => p.StructureNumber.Contains(structureNumber);
        }

        /// <summary>
        /// The category name equals.
        /// </summary>
        /// <param name="dtId">
        /// The deck type id.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<Asset, bool>> DeckTypeIdEquals(int dtId)
        {
            return p => p.DeckType.Id == dtId;
        }

        /// <summary>
        /// The Inspection Date Equals
        /// </summary>
        /// <param name="inspectionDate"></param>
        /// <returns></returns>
        public static Expression<Func<Asset, bool>> InspectionDateEquals(DateTime? inspectionDate)
        {
            return p => p.InspectionDate.GetValueOrDefault().Date == inspectionDate.GetValueOrDefault().Date;
        }

        /// <summary>
        /// The name like.
        /// </summary>
        /// <param name="owner">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public static Expression<Func<Asset, bool>> OwnerLike(string owner)
        {
            return p => p.Owner.Contains(owner);
        }

        #endregion LINQ Predicates
    }
}
