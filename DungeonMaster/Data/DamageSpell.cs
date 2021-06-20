﻿/*************************************************
 * Name: DamageSpell.cs
 * Author: Hunter Page
 * Date Created: 6/9/21
 * Last Modified: 6/9/21
 *************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
	public class DamageSpell : Spell
	{

		public double Damage { get; set; }


		public DamageSpell(string spellName, SpellTypes spellType, double damage, Dice diceUsed, int numberOfRolls, int range) : base(spellName, spellType, diceUsed, numberOfRolls, range)
		{
			this.Damage = damage;
		}
	}
}
