using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Class to report the dice roll result.
    /// </summary>
    public class DiceRollReport
    {
        /// <summary>
        /// List of the die sides of all dice rolled.
        /// </summary>
        public List<int> DiceRolled { get; set; }

        /// <summary>
        /// Returns the total of all the dice rolled.
        /// </summary>
        /// <returns> The sum of all dice rolled.</returns>
        public int GetDiceTotal() 
        {
            int diceTotal = 0;
            if (DiceRolled.Count == 0) 
            {
                return diceTotal;
            }

            for (int i = 0; i < DiceRolled.Count; i++)
            {
                diceTotal += DiceRolled[i];
            }

            return diceTotal;
        }

        /// <summary>
        /// Returns a string containing the report of the dice roll.
        /// </summary>
        /// <returns> A string containing the report of the dice roll.</returns>
        public string GetDiceReport() 
        {
            var diceReport = "";

            if (DiceRolled.Count == 0) 
            {
                return diceReport;
            }

            for (int i = 0; i < DiceRolled.Count; i++) 
            {
                if (i == (DiceRolled.Count - 1))
                {
                    diceReport += $"{DiceRolled[i]} = ${GetDiceTotal()}";
                }
                else 
                {
                    diceReport += $"{DiceRolled[i]} + ";
                }
            }

            return diceReport;
        }
        
    }
}
