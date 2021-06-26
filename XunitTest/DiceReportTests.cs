using DungeonMaster.Data;
using System.Collections.Generic;
using Xunit;

namespace XunitTest
{
    /// <summary>
    /// Class to test the Dice Report classes, which all inherit from DiceRollReport
    /// </summary>
    public class DiceReportTests
    {
        /// <summary>
        /// Test roll values.
        /// </summary>
        private readonly List<int> listOfRollValues = new() { 10, 15 };

        /// <summary>
        /// Sum of the dice in list of roll values.
        /// </summary>
        private const int SUM_OF_DICE = 25;

        /// <summary>
        /// Value of the smaller die.
        /// </summary>
        private const int SMALLER_DIE = 10;

        /// <summary>
        /// Value of the larger die.
        /// </summary>
        private const int LARGER_DIE = 15;

        /// <summary>
        /// Method to test that we are correctly getting the sum of our two rolled dice.
        /// </summary>
        [Fact]
        public void AdvantageRollReportTotalTest()
        {
            var advantageReport = new AdvantageRollReport() { DiceRolled = listOfRollValues };
            var diceTotal = advantageReport.GetDiceTotal();

            Assert.True(diceTotal == LARGER_DIE);
        }

        /// <summary>
        /// Method to test that we are getting a correct report for our dice report.
        /// </summary>
        [Fact]
        public void AdvantageRollReportGetReportTest()
        {
            var advantageReport = new AdvantageRollReport() { DiceRolled = listOfRollValues };
            var diceReport = advantageReport.GetDiceReport();
            var expectedReport = "rolled with advantage 10 & 15. 15 is used.";

            Assert.True(diceReport.Equals(expectedReport));
        }

        /// <summary>
        /// Method to test that we are getting the correct die total with disadvantage.
        /// </summary>
        [Fact]
        public void DisadvantageRollReportGetTotalTest()
        {
            var disadvantageReport = new DisadvantageRollReport() { DiceRolled = listOfRollValues };
            var diceTotal = disadvantageReport.GetDiceTotal();

            Assert.True(diceTotal == SMALLER_DIE);
        }

        /// <summary>
        /// Method to test that our dice report is providing the correct string output.
        /// </summary>
        [Fact]
        public void DisadvantageRollReportGetReportTest()
        {
            var disadvantageReport = new DisadvantageRollReport() { DiceRolled = listOfRollValues };
            var diceReport = disadvantageReport.GetDiceReport();
            var expectedReport = "rolled with disadvantage 10 & 15. 10 is used.";

            Assert.True(diceReport.Equals(expectedReport));
        }

        /// <summary>
        /// Method to test that we are returning the sum of the dice.
        /// </summary>
        [Fact]
        public void MultipleDiceRollReportGetTotalTest()
        {
            var multipleRollReport = new MultipleDiceRollReport() { DiceRolled = listOfRollValues };
            var diceTotal = multipleRollReport.GetDiceTotal();

            Assert.True(diceTotal == SUM_OF_DICE);
        }

        /// <summary>
        /// Method to test that the returned string is formatted correctly.
        /// </summary>
        [Fact]
        public void MultipleDiceRollReportGetReportTest()
        {
            var multipleRollReport = new MultipleDiceRollReport() { DiceRolled = listOfRollValues };
            var diceReport = multipleRollReport.GetDiceReport();
            var expectedReport = "10 + 15 = 25";

            Assert.True(diceReport.Equals(expectedReport));
        }
    }
}
