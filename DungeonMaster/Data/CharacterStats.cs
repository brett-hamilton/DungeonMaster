﻿using System;


namespace DungeonMaster.Data
{
	public class CharacterStats
	{
		/// <summary>
		/// Measures physical power of character
		/// </summary>
		public int Strength { get; set; }

		/// <summary>
		/// The agility of the Character
		/// </summary>
		public int Dexterity { get; set; }

		/// <summary>
		/// Endurance of the player
		/// </summary>
		public int Constitution { get; set; }

		/// <summary>
		/// Memory and reasoning of the Character
		/// </summary>
		public int Intelligence { get; set; }

		/// <summary>
		/// Insight of the Character
		/// </summary>
		public int Wisdom { get; set; }

		/// <summary>
		/// Personality of the Character
		/// </summary>
		public int Charisma { get; set; }

		/// <summary>
        /// Default constructor
        /// </summary>
		public CharacterStats()
		{
			Strength = 0;
			Dexterity = 0;
			Constitution = 0;
			Intelligence = 0;
			Wisdom = 0;
			Charisma = 0;
		}

		/// <summary>
        /// Loaded Constructor to set the traits of the character.
        /// Descriptions are above
        /// </summary>
        /// <param name="strength">Strength level.</param>
        /// <param name="dexterity">Dexterity level.</param>
        /// <param name="constitution">Constitution level.</param>
        /// <param name="intelligence">Intelligence level.</param>
        /// <param name="wisdom">Wisdom level.</param>
        /// <param name="charisma">Charisma level.</param>
		public CharacterStats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
		{
			Strength = strength;
			Dexterity = dexterity;
			Constitution = constitution;
			Intelligence = intelligence;
			Wisdom = wisdom;
			Charisma = charisma;
		}
	}
}

