using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickettyBridges.DAL.Entities
{
    using RickettyBridges.DAL.Entities.Base;
    using RickettyBridges.DAL.Enums;

    /// <summary>
    /// Criteria object used to hold AssetCategory search criteria
    /// </summary>
    public class AssetCategoryListCriteria : CriteriaBase.ListCriteria
    {
        /// <summary>
        /// Gets or sets the asset category filter.
        /// </summary>
        public List<AssetCategoryCriteriaFilter> AssetCategoryFilter { get; set; }
    }

    /// <summary>
    /// A filter object detailing an Asset search criterion
    /// </summary>
    public class AssetCategoryCriteriaFilter : CriteriaBase.ListCriteriaFilter
    {
        /// <summary>
        /// Gets or sets the field name
        /// </summary>
        public AssetCategorySearchCriteria FieldNameEnum { get; set; }
    }
}
