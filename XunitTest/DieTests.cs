using Xunit;
using DungeonMaster.Data;

namespace DungeonMaster.XunitTest
{
    /// <summary>
    /// Class containing methods to test the Die class
    /// </summary>
    public class DieTests
    {
        /// <summary>
        /// Method to test that a D20 roll returns a valid value
        /// </summary>
        [Fact]
        public void RollD20Test()
        {
            var dieRoll = Die.RollD20();

            Assert.True(dieRoll > 0 && dieRoll < 21);
        }

        /// <summary>
        /// Method to test that a valid number is returned from the two D20s are rolled.
        /// </summary>
        [Fact]
        public void RollD20WithAdvantageReturnValueTest()
        {
            var dieRoll = Die.RollD20Advantage();

            var highRoll = dieRoll.GetDiceTotal();

            Assert.True(highRoll > 0 && highRoll < 21);
        }

        /// <summary>
        /// Method to test that when two D20s are rolled that we return the lower.
        /// </summary>
        [Fact]
        public void RollD20WithAdvantageRightDieReturnedTest() 
        {
            var dieRoll = Die.RollD20Advantage();

            Assert.True(dieRoll.DiceRolled[0] <= dieRoll.DiceRolled[1]);
        }
    }
}
