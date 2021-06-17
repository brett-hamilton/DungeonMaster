using System;
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
		/// <returns>Amount of damage attacker does to defender; 0 if miss.</returns>
		public AttackReport MeleeAttack (Character attacker, Character defender)
		{
			// Roll the attack dice for a value to compare to defender's armor rating
			double attackValue = Die.RollD20();

			// Determine if the attack value is enough to hit
			bool hit = defender.CheckArmor (attackValue);

			if (hit)
			{
				// Decrease defender's health by the attacker's weapon stat
				
				var attackReport = attacker.Weapon.GetDamage ( );
				int damageAmount = attackReport.TotalDamageDealt;
				defender.DamagePlayer (damageAmount);
				attackReport.AttackRoll = attackValue;
				attackReport.HitCheck = hit;
				attackReport.AttackerName = attacker.Name;
				attackReport.DefenderName = defender.Name;

				return attackReport;
			}

			return new AttackReport 
			{ 
				AttackRoll = attackValue, 
				HitCheck = hit,
				AttackerName = attacker.Name,
				DefenderName = defender.Name
			};

		}

		/// <summary>
		/// Perform a ranged attack against the defending character. If the defender is within melee range
		/// then the attack roll is with disadvantage.
		/// Created by: Jordan DeBord
		/// Last Updated: 06/12/2021
		/// </summary>
		/// <param name="attacker">Character attacking the other.</param>
		/// <param name="defender">Character defending against the attack.</param>
		/// <param name="disadvantage">If the defending character is in melee range.</param>
		/// <returns>An attack report containing information about the attack.</returns>
		public AttackReport RangedAttack(Character attacker, Character defender, bool disadvantage) 
		{
			double attackValue;
			if (disadvantage)
			{
				attackValue = Die.RollD20Disadvantage().GetDiceTotal();
			}
			else 
			{
				attackValue = Die.RollD20();
			}

			bool hit = defender.CheckArmor(attackValue);

			if (hit) 
			{
				var attackReport = attacker.Weapon.GetDamage();
				defender.DamagePlayer(attackReport.TotalDamageDealt); attackReport.AttackRoll = attackValue;
				attackReport.HitCheck = hit;
				attackReport.AttackerName = attacker.Name;
				attackReport.DefenderName = defender.Name;

				return attackReport;
			}

			return new AttackReport
			{
				AttackRoll = attackValue,
				HitCheck = hit,
				AttackerName = attacker.Name,
				DefenderName = defender.Name
			};
		}
	}
}
