using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Data
{
	public class Inventory
	{
		public List<Weapon> Weapons { get; set; }

		public List<Spell> Spells { get; set; }


		public Inventory()
		{
			Weapons = new List<Weapon>();
			Spells = new List<Spell>();
		}

		///Provides an inventory listing
        public override string ToString()
        {
			StringBuilder inventoryList = new StringBuilder();

			inventoryList.Append("Weapons\n-------------");

            foreach(Weapon w in Weapons)
            {
				inventoryList.Append(w.ToString() + "\n");
            }

			inventoryList.Append("Spells\n-------------");

            foreach(Spell s in Spells)
            {
				inventoryList.Append(s.ToString() + "\n");
            }

			return inventoryList.ToString();
        }
    }
}

