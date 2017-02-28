using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickettyBridges.DAL
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlTypes;

    using LinqKit;

    using RickettyBridges.DAL.Config;
    using RickettyBridges.DAL.Entities;
    using RickettyBridges.DAL.Entities.Base;
    using RickettyBridges.DAL.Enums;
    using RickettyBridges.DAL.Interfaces;

    public class RickettyBridgesContext : DbContext
    {
        static RickettyBridgesContext()
        {
            Database.SetInitializer<RickettyBridgesContext>(null);
        }

        public RickettyBridgesContext()
            : base("RickettyBridgesContext")
        {
        }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        public virtual DbSet<Asset> Assets { get; set; }

        /// <summary>
        /// Gets or sets the asset categories.
        /// </summary>
        public virtual DbSet<DeckType> DeckTypes { get; set; }

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                                                    .Where(e => e.Entity is EntityBase
                                                       && (e.State == EntityState.Added
                                                         | e.State == EntityState.Modified)))
            {
                var dateClass = (EntityBase)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    dateClass.AddedDate = DateTime.Now;
                    dateClass.ModifiedDate = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    dateClass.ModifiedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssetConfig());
            modelBuilder.Configurations.Add(new DeckTypeConfig());

            // Asset-DeckType Relationship
            modelBuilder.Entity<Asset>()
                .HasRequired(t => t.DeckType)
                .WithMany()
                .HasForeignKey(d => d.DeckTypeId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
