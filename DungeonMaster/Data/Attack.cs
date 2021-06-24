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
		/// <returns>Attack Report detailing what happened in the attack.</returns>
		public AttackReport MeleeAttack(Character attacker, Character defender)
		{
			// Roll the attack dice for a value to compare to defender's armor rating
			double attackValue = Die.RollD20() + attacker.isProficient() + attacker.CharacterStats.Strength;

			// Determine if the attack value is enough to hit
			bool hit = defender.CheckArmor(attackValue);

			if (hit)
			{
				// Decrease defender's health by the attacker's weapon stat
				
				var attackReport = attacker.ActiveWeapon.GetDamage();
				int damageAmount = attackReport.TotalDamageDealt + attacker.CharacterStats.Strength;
				defender.DamagePlayer(damageAmount);
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
			DiceRollReport disadvatageRollReport = null;
			double attackValue;
			if (disadvantage)
			{
				disadvatageRollReport = Die.RollD20Disadvantage();
				attackValue = disadvatageRollReport.GetDiceTotal() + attacker.isProficient() + attacker.CharacterStats.Dexterity;
				
			}
			else 
			{
				attackValue = Die.RollD20() + attacker.isProficient() + attacker.CharacterStats.Dexterity;
			}

			bool hit = defender.CheckArmor(attackValue);

			if (hit) 
			{
				var attackReport = attacker.ActiveWeapon.GetDamage();
				defender.DamagePlayer(attackReport.TotalDamageDealt + attacker.CharacterStats.Dexterity); 
				attackReport.AttackRoll = attackValue;
				attackReport.HitCheck = hit;
				attackReport.AttackerName = attacker.Name;
				attackReport.DefenderName = defender.Name;
				attackReport.DisadvantageRoll = disadvatageRollReport;

				return attackReport;
            }

			return new AttackReport
			{
				AttackRoll = attackValue,
				HitCheck = hit,
				AttackerName = attacker.Name,
				DefenderName = defender.Name,
				DisadvantageRoll = disadvatageRollReport
			};
        }

		public AttackReport SpellAttack(Character caster, Character receiver)
        {
			AttackReport attackReport = caster.ActiveSpell.GetSpellDamage();

			double totalDamage = attackReport.DiceRollReport.GetDiceTotal() + caster.CharacterStats.Intelligence;
			receiver.DamagePlayer(totalDamage);

			attackReport.AttackerName = caster.Name;
			attackReport.DefenderName = receiver.Name;
			attackReport.CharacterIntelligence = caster.CharacterStats.Intelligence;
			attackReport.SpellName = caster.ActiveSpell.SpellName;
			attackReport.SpellType = caster.ActiveSpell.SpellType;
			attackReport.TotalDamageDealt = (int)totalDamage;

			return attackReport;
        }
	}
}
