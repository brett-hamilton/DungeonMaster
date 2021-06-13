/*************************************************
 * Name: Spell.cs
 * Author: Hunter Page
 * Date Created: 6/9/21
 * Last Modified: 6/9/21
 *************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMaster.Data;

namespace DungeonMaster.Data
{
	public class Spell
	{

		public string SpellName { get; set; }

		public SpellTypes SpellType { get; set; }

		public Dice DiceUsed { get; set; }

		public int NumberOfRolls { get; set; }

		public Spell(string spellName, SpellTypes spellType, Dice diceUsed)
		{
			this.SpellName = spellName;
			this.SpellType = spellType;
			this.DiceUsed = diceUsed;
		}
	}
}

