/*************************************************
 * Name: Weapon.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
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
		/// Method to get the total damage done by this weapon.
		/// Author: Jordan DeBord
		/// </summary>
		/// <returns>An int representing the total damage done.</returns>
		public int GetDamage()
		{
			var dieToUse = DiceUsed.ToString();

			// Try to parse out how many sides the Die is, then Roll it.
			if (int.TryParse(dieToUse[1..], out int dieSides))
			{
				DiceRollReport dieRollReport;
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
				return BaseDamage + dieRoll;
			}
			return BaseDamage;
		}


		
	}
}
