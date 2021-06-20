using System;


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
		/// endurance of the player
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
        /// meant for initializing a variable
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
        /// Loaded COnstructor to set the traits of the character.
        /// Descriptions are above
        /// </summary>
        /// <param name="strength"></param>
        /// <param name="dexterity"></param>
        /// <param name="constitution"></param>
        /// <param name="intelligence"></param>
        /// <param name="wisdom"></param>
        /// <param name="charisma"></param>
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

