namespace DungeonMaster.Data
{
    /// <summary>
    /// Concretion of Dice Roll Report when rolling multiple dice.
    /// </summary>
    public class MultipleDiceRollReport : DiceRollReport
    {
        /// <summary>
        /// Returns the total of all the dice rolled.
        /// </summary>
        /// <returns> The sum of all dice rolled.</returns>
        public override int GetDiceTotal()
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
        public override string GetDiceReport()
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
                    diceReport += $"{DiceRolled[i]} = {GetDiceTotal()}";
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
