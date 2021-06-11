/*************************************************
 * Name: Weapon.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/11/21
 *************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
	public class Weapon
	{
		/// <summary>
		/// name of the weapon
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// the amount of damage with no dice rolls
		/// </summary>
		public int BaseDamage {get; set;}

		/// <summary>
		/// What dice the weapon uses, default is set to D4.
		/// </summary>
		public Dice DiceUsed { get; set; } = Dice.D4;

		/// <summary>
		/// How far the weapon can reach
		/// </summary>
		public double Range { get; set; } //not necessary for the time being

		///
		//determines whether the weapon is used for range
		///
		public bool rangedWeapon { get; set; } 

		///
		//the type of damage the weapon uses
		///
		public Effect DamageType { get; set; }

		/// <summary>
		/// Default constructor that takes no parameters
		/// 
		/// Created by: Brett Hamilton
		/// Created on: 6/11/2021
		/// </summary>
		public Weapon ( )
		{
			this.Name = "sword";
			this.BaseDamage = 10;
			this.DiceUsed = Dice.D6;
			this.Range = 5.0;
		}

		/// <summary>
		/// Loaded constructor for making a new weapon
		/// </summary>
		/// Author: Hunter Page
		/// <param name="name">name of the weapon</param>
		/// <param name="baseDamage">damage of the weapon</param>
		/// <param name="dice">dice it uses</param>
		/// <param name="range">what effective range the weapon has</param>
		public Weapon(string name, int baseDamage, Dice dice, double range)
		{
			this.Name = name;
			this.BaseDamage = baseDamage;
			this.DiceUsed = dice;
			this.Range = range;
		}

		/// <summary>
		/// Loaded constructor for making a new weapon
		/// </summary>
		/// Author: Hunter Page
		/// <param name="name">name of the weapon</param>
		/// <param name="baseDamage">damage of the weapon</param>
		/// <param name="dice">dice it uses</param>
		/// <param name="range">what effective range the weapon has</param>
		/// <param name="damageTypes">what type of damage the weapon does</param>
		public Weapon(string name, int baseDamage, Dice dice, double range, Effect damageTypes)
		{
			this.Name = name;
			this.BaseDamage = baseDamage;
			this.DiceUsed = dice;
			this.Range = range;
			this.DamageType = damageTypes;

			//sets value of rangedWeapon to false if a melee weapon
			if(range <= 1)
			{
				this.rangedWeapon = false;
			}
			
		}

		/// <summary>
		/// Method to get the total damage done by this weapon.
		/// Author: Jordan DeBord
		/// </summary>
		/// <returns>An int representing the total damage done.</returns>
		public AttackReport GetDamage()
		{
			var dieToUse = DiceUsed.ToString();

			// Try to parse out how many sides the Die is, then Roll it.
			if (int.TryParse(dieToUse[1..], out int dieSides))
			{
				DiceRollReport dieRollReport = null;
				int dieRoll;

				// If the die had a non-allowed number of sides, return 0 for the result.
				try 
				{
					dieRollReport = Die.Roll(dieSides, 1);
					dieRoll = dieRollReport.GetDiceTotal();
				} 
				catch (Exception) 
				{
					dieRoll = 0;
				}

				if (dieRollReport != null)
				{
					return new AttackReport
					{
						DiceRollReport = dieRollReport,
						TotalDamageDealt = BaseDamage + dieRoll,
						WeaponBaseDamage = BaseDamage,
						DieUsed = DiceUsed
					};
				}
			}

			return new AttackReport 
			{ 
				TotalDamageDealt = BaseDamage, 
				WeaponBaseDamage = BaseDamage, 
				DieUsed = DiceUsed 
			};
		}


		
	}
}
