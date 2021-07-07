using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Class Inventory, 
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// List of Weapons held in the inventory.
        /// </summary>
        public List<Weapon> Weapons { get; set; }

        /// <summary>
        /// List of Spells held in the inventory.
        /// </summary>
        public List<Spell> Spells { get; set; }

        /// <summary>
        /// Default constructor for inventory
        /// </summary>
        public Inventory()
        {
            Weapons = new List<Weapon>();
            Spells = new List<Spell>();
        }

        /// <summary>
        /// Provides an inventory listing.
        /// </summary>
        /// <returns>String representation of the inventory.</returns>
        public override string ToString()
        {
            StringBuilder inventoryList = new StringBuilder();

            inventoryList.Append("Weapons\n-------------");

            foreach (Weapon w in Weapons)
            {
                inventoryList.Append(w.ToString() + "\n");
            }

            inventoryList.Append("Spells\n-------------");

            foreach (Spell s in Spells)
            {
                inventoryList.Append(s.ToString() + "\n");
            }

            return inventoryList.ToString();
        }
    }
}

