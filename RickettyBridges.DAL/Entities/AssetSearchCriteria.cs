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
    /// Criteria object used to hold Asset search criteria
    /// </summary>
    public class AssetListCriteria : CriteriaBase.ListCriteria
    {
        /// <summary>
        /// List of filters detailing the specific criteria for the search
        /// </summary>
        public List<AssetCriteriaFilter> AssetFilter { get; set; }
    }

    /// <summary>
    /// A filter object detailing an Asset search criterion
    /// </summary>
    public class AssetCriteriaFilter : CriteriaBase.ListCriteriaFilter
    {
        /// <summary>
        /// The enum for the type of filter
        /// </summary>
        public AssetSearchCriteria FieldNameEnum { get; set; }
    }
}
