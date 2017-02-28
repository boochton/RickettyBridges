using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickettyBridges.DAL.Entities
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AssetSimple
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Deck { get; set; }

        public string Location { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Level { get; set; }
    }
}
