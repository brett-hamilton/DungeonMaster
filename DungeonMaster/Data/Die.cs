
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Class that represents a single Die, or collection of Dice to be rolled.
    /// </summary>
    public class Die
    {
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Method to roll a die with the provided sides the number of times provided.
        /// Created by: Jordan DeBord
        /// Created on: 06/02/2021
        /// </summary>
        /// <param name="dieSides">Number of sides on the die to roll.</param>
        /// <param name="numberOfDie">Number of die to roll.</param>
        /// <returns>An int representing the total after rolling the die.</returns>
        public static int Roll(int dieSides, int numberOfDie)
        {
            if (dieSides < 2 || dieSides > 20)
            {
                throw new Exception("Invalid Die Sides.");
            }

            if (numberOfDie < 1 || numberOfDie > 10)
            {
                throw new Exception("Invalid Number of Die.");
            }
            var numberToReturn = 0;

            for (int i = 1; i <= numberOfDie; i++)
            {
                numberToReturn += Rand.Next(1, (dieSides + 1));
            }
            return numberToReturn;
        }

        /// <summary>
        /// Method to roll a single 20 sided die.
        /// Created by: Jordan DeBord
        /// Created on: 06/02/2021
        /// </summary>
        /// <returns> An int between 1 and 20, representing the result of the roll.</returns>
        public static int RollD20()
        {
            return Rand.Next(1, 21);
        }

        /// <summary>
        /// Method to roll two 20 sided dice, and return the larger result, representing advantage.
        /// Created by: Jordan DeBord
        /// Created on: 06/02/2021
        /// </summary>
        /// <returns> An int between 1 and 20, representing the larger of the two dice rolls. </returns>
        public static int RollD20Advantage()
        {
            var roll1 = RollD20();
            var roll2 = RollD20();

            if (roll2 > roll1)
            {
                return roll2;
            }

            return roll1;
        }

        /// <summary>
        /// Method to roll two 20 sided dice, and return the smaller result, representing disadvantage.
        /// Created by: Jordan DeBord
        /// Created on: 06/02/2021
        /// </summary>
        /// <returns> An int between 1 and 20, representing the smaller of the two dice rolls.</returns>
        public static int RollD20Disadvantage()
        {
            var roll1 = RollD20();
            var roll2 = RollD20();

            if (roll2 < roll1)
            {
                return roll2;
            }

            return roll1;
        }
    }
}
