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
		/// <summary>
		/// Name of the spell.
		/// </summary>
		public string SpellName { get; set; }

		/// <summary>
		/// Type of the spell.
		/// </summary>
		public SpellTypes SpellType { get; set; }

		/// <summary>
		/// Die used to roll this spell.
		/// </summary>
		public Dice DiceUsed { get; set; }

		/// <summary>
		/// Number of time dice will be rolled.
		/// </summary>
		public int NumberOfRolls { get; set; }

		/// <summary>
		/// The range the spell can reach.
		/// </summary>
		public int Range { get; set; }

		/// <summary>
		/// Default constructor for a spell.
		/// </summary>
		public Spell()
        {
			this.SpellName = "Fireball";
			this.SpellType = SpellTypes.Fire;
			this.DiceUsed = Dice.D6;
			this.NumberOfRolls = 4;
			this.Range = 10;
        }

		/// <summary>
		/// Overloaded constructor of the Spell class
		/// </summary>
		/// Author: Hunter Page
		/// <param name="spellName">Name of the spell.</param>
		/// <param name="spellType">Type of spell.</param>
		/// <param name="diceUsed">Dice it uses.</param>
		/// <param name="range">What effective range the weapon has.</param>
        ///<param name="numberOfRolls">How many the die will be rolled when spell is being used.</param>
		public Spell(string spellName, SpellTypes spellType, Dice diceUsed, int numberOfRolls, int range)
		{
			this.SpellName = spellName;
			this.SpellType = spellType;
			this.DiceUsed = diceUsed;
			this.NumberOfRolls = numberOfRolls;
			this.Range = range;
		}

		/// <summary>
		/// Gets the damage of the Spell based off of its number of rolls and the dice being used
		/// </summary>
		/// Author: Hunter Page
		///<returns>Report representing the damage dealt by the spell.<returns>
		public AttackReport GetSpellDamage()
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
					dieRollReport = Die.Roll(dieSides, NumberOfRolls); //added number of rolls instead of 1
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
						//TotalDamageDealt = dieRoll, //only will use dieRoll until proficiency is implemented
						DieUsed = DiceUsed
					};
				}
			}

			return new AttackReport 
			{ 
				TotalDamageDealt = 1, 
				//ModifierDamage = BaseDamage, 
				DieUsed = DiceUsed 
			};
        }

		/// <summary>
		/// Provides a string representation for a spell.
		/// </summary>
		/// <returns>String representation.</returns>
        public override string ToString()
        {
            return SpellName;
        }
    }
}

