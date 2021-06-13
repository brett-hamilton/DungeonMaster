/*************************************************
 * Name: DamageSpell.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/

using System;

namespace DungeonMaster.Data
{
	public class HealingSpell : Spell
	{
		public double HealingFactor { get; set; }

		public HealingSpell(string spellName, SpellTypes spellType, double healingFactor, Dice diceUsed) : base(spellName, spellType, diceUsed)
		{
			this.HealingFactor = HealingFactor;
		}
	}
}