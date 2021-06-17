using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Concretion of a Roll report for two D20's where the larger is returned.
    /// </summary>
    public class AdvantageRollReport : DiceRollReport
    {
        /// <summary>
        /// Returns a string containing the report of the dice roll.
        /// </summary>
        /// <returns> A string containing the report of the dice roll.</returns>
        public override string GetDiceReport()
        {
            return $"rolled with advantage {DiceRolled[0]} & {DiceRolled[1]}. {GetDiceTotal()} is used.";
        }

        /// <summary>
        /// Returns the larger of the two dice rolled. We sorted the array earlier
        /// so this should be position 1.
        /// </summary>
        /// <returns> The larger dice roll.</returns>
        public override int GetDiceTotal()
        {
            return DiceRolled[1];
        }
    }
}
