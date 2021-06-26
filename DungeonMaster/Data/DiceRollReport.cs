using System.Collections.Generic;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Class reports the total from the dice report and a string
    /// describing it.
    /// </summary>
    public abstract class DiceRollReport
    {
        /// <summary>
        /// List of the die sides of all dice rolled.
        /// </summary>
        public List<int> DiceRolled { get; set; }

        /// <summary>
        /// Returns dice that was rolled.
        /// </summary>
        /// <returns> The sum of all dice rolled.</returns>
        public abstract int GetDiceTotal();
        /// <summary>
        /// Returns a string containing the report of the dice roll.
        /// </summary>
        /// <returns> A string containing the report of the dice roll.</returns>
        public abstract string GetDiceReport();

    }
}
