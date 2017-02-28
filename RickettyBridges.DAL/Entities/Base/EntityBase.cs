namespace RickettyBridges.DAL.Entities.Base
{
    using System;
    using System.Data.SqlTypes;

    public class EntityBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the added date.
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        public byte[] TimeStamp { get; set; }

        #endregion
    }
}
