﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
	/// <summary>
	/// Class containing methods that allow characters to perform a variety of attack-types.
	/// 
	/// Created by: Brett Hamilton
	/// Created on: 6/2/21
	/// </summary>
	public class Attack
	{	
		/// <summary>
		/// Perform a melee attack against a defending character. Depends on dice rolling to calculate
		/// whether or not the attack hits or misses.
		/// 
		/// Created by: Brett Hamilton
		/// Created on: 6/2/21
		/// </summary>
		/// <param name="attacker">The character attacking.</param>
		/// <param name="defender">The character being attacked.</param>
		public void MeleeAttack (Character attacker, Character defender)
		{
			// Roll the attack dice for a value to compare to defender's armor rating
			double attackValue = AttackRoll (attacker);

			// Determine if the attack value is enough to hit
			bool hit = defender.CheckArmor (attackValue);

			if (hit)
			{
				// Decrease defender's health by the attacker's weapon stat
				defender.DmgPlayer (Attack.Weapon.Stat);
			}

		}
	}
}
