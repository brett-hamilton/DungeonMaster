using System;
using System.Collections.Generic;

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
	}
}

