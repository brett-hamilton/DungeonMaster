using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Concretion of Dice Roll report where two D20 are rolled and the smaller is returned.
    /// </summary>
    public class DisadvantageRollReport : DiceRollReport
    {
        /// <summary>
        /// Returns a string containing the report of the dice roll.
        /// </summary>
        /// <returns> A string containing the report of the dice roll.</returns>
        public override string GetDiceReport()
        {
            return $"rolled with disadvantage {DiceRolled[0]} & {DiceRolled[1]}. {GetDiceTotal()} is used.";
        }

        /// <summary>
        /// Returns the lower of the two die rolled. We sorted the array previously, so
        /// this is position 0.
        /// </summary>
        /// <returns> The smaller of the two dice rolled.</returns>
        public override int GetDiceTotal()
        {
            return DiceRolled[0];
        }
    }
}
