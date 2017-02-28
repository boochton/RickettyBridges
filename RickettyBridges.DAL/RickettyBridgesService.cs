using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickettyBridges.DAL
{
    using LinqKit;

    using RickettyBridges.DAL.Entities;
    using RickettyBridges.DAL.Enums;
    using RickettyBridges.DAL.Interfaces;

    public class RickettyBridgesService : IRickettyBridgeService
    {
        private RickettyBridgesContext _context;

        public RickettyBridgesService(RickettyBridgesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The get assets.
        /// </summary>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// Application exception
        /// </exception>
        public IQueryable<Asset> GetAssets(AssetListCriteria criteria)
        {
            // TODO: Validate Criteria
            ////throw new ArgumentNullException("criteria", "You must provide a value for the parameter 'criteria'.");            

            try
            {
                var predicate = PredicateBuilder.New<Asset>();

                foreach (var item in criteria.AssetFilter)
                {
                    var temp = item.Value;
                    switch (item.FieldNameEnum)
                    {
                        case AssetSearchCriteria.Name:
                            predicate = item.GroupLogicJoin == LogicalJoin.Logical_AND ?
                                  predicate.And(Asset.NameLike(temp))
                                : predicate.Or(Asset.NameLike(temp));
                            break;
                        case AssetSearchCriteria.InspectionNumber:
                            predicate = item.GroupLogicJoin == LogicalJoin.Logical_AND ?
                                  predicate.And(Asset.InspectionNumberLike(temp))
                                : predicate.Or(Asset.InspectionNumberLike(temp));
                            break;
                        case AssetSearchCriteria.StructureNumber:
                            predicate = item.GroupLogicJoin == LogicalJoin.Logical_AND ?
                                  predicate.And(Asset.StructureNumberLike(temp))
                                : predicate.Or(Asset.StructureNumberLike(temp));
                            break;
                        case AssetSearchCriteria.Owner:
                            predicate = item.GroupLogicJoin == LogicalJoin.Logical_AND ?
                                  predicate.And(Asset.OwnerLike(temp))
                                : predicate.Or(Asset.OwnerLike(temp));
                            break;
                        case AssetSearchCriteria.DeckTypeId:
                            int dtId;
                            if (int.TryParse(temp, out dtId))
                            {
                                predicate = item.GroupLogicJoin == LogicalJoin.Logical_AND ?
                                      predicate.And(Asset.DeckTypeIdEquals(dtId))
                                    : predicate.Or(Asset.DeckTypeIdEquals(dtId));
                            }
                            break;
                        case AssetSearchCriteria.InspectionDate:
                            DateTime iDate;
                            if (DateTime.TryParse(temp, out iDate))
                            {
                                predicate = item.GroupLogicJoin == LogicalJoin.Logical_AND ?
                                      predicate.And(Asset.InspectionDateEquals(iDate))
                                    : predicate.Or(Asset.InspectionDateEquals(iDate));
                            }
                            break;
                        default:
                            throw new ApplicationException(string.Format(
                                "An error occurred: {0}", "Unknown AssetListCriteria"));
                    }
                }

                return from asset in this._context.Assets.AsExpandable().Where(predicate) select asset;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format(
                    "An error occurred: {0}", ex.Message));
            }
        }

        /// <summary>
        /// The get asset categories.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<DeckType> GetDeckTypes()
        {
            // TODO: Implement criteria based searching if needed?
            var types = from deckTypes in this._context.DeckTypes
                        select deckTypes;

            return types;
        }

        public Asset GetAsset(int id)
        {
            return this._context.Assets.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public int SaveAsset(Asset asset)
        {
            Asset result;
            if (asset.Id != 0)
            {
                result = this._context.Assets.FirstOrDefault(a => a.Id == asset.Id);
                if (result != null)
                {
                    result.DeckTypeId = asset.DeckTypeId;
                    result.InspectionDate = asset.InspectionDate;
                    result.InspectionNumber = asset.InspectionNumber;
                    result.IsHighwayBridge = asset.IsHighwayBridge;
                    result.IsMaintenanceRequired = asset.IsMaintenanceRequired;
                    result.Name = result.Name; // This value cannot be changed
                    result.Owner = result.Owner; // This value cannot be changed
                    result.StructureNumber = asset.StructureNumber;
                }
                else
                {
                    // Options here but for simplicity if we can't find it we'll create a new one - this may not be appropriate in reality
                    result = this._context.Assets.Add(asset);
                }
            }
            else
            {
                result = this._context.Assets.Add(asset);
            }

            this._context.SaveChanges();

            return result.Id;
        }
    }
}
