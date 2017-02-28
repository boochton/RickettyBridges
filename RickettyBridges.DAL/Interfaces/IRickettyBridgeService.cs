using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickettyBridges.DAL.Interfaces
{
    using RickettyBridges.DAL.Entities;
    using RickettyBridges.DAL.Enums;

    public interface IRickettyBridgeService
    {
        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<Asset> GetAssets(AssetListCriteria criteria);

        /// <summary>
        /// Gets the asset categories.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<DeckType> GetDeckTypes();

        /// <summary>
        /// The get asset.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Asset"/>.
        /// </returns>
        Asset GetAsset(int id);

        /// <summary>
        /// Saves the provided asset and returns the currently persisted entity
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        int SaveAsset(Asset asset);
    }
}
