using Xunit;
using DungeonMaster.Data;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DungeonMaster.XunitTest
{
    
    /// <summary>
    /// Class containing methods to test the Die class
    /// </summary>
    public class DieTests
    {
        /// <summary>
        /// Maximum value that should be returned from a D20.
        /// </summary>
        private const int D20_MAX_VALUE = 20;
        
        /// <summary>
        /// Minimum value that should be returned from a D20. 
        /// </summary>
        private const int D20_MIN_VALUE = 1;

        /// <summary>
        /// A valid number of sides for a die to be rolled.
        /// </summary>
        private const int MULTI_DICE_VALID_SIDES = 4;

        /// <summary>
        /// A valid number of dice to be rolled.
        /// </summary>
        private const int MULTI_DICE_VALID_NUM_DICE = 3;
        
        /// <summary>
        /// Method to test that a D20 roll returns a valid value
        /// </summary>
        [Fact]
        public void RollD20Test()
        {
            var dieRoll = Die.RollD20();

            Assert.True(dieRoll >= D20_MIN_VALUE && dieRoll <= D20_MAX_VALUE);
        }

        /// <summary>
        /// Method to test that a valid number is returned from the two D20s are rolled.
        /// </summary>
        [Fact]
        public void RollD20WithAdvantageReturnValueTest()
        {
            var dieRoll = Die.RollD20Advantage();

            var highRoll = dieRoll.GetDiceTotal();

            Assert.True(highRoll >= D20_MIN_VALUE && highRoll <= D20_MAX_VALUE);
        }

        /// <summary>
        /// Method to test that exactly two dice are rolled.
        /// </summary>
        [Fact]
        public void RollD20WithAdvantageValidNumberOfRolls()
        {
            var dieRoll = Die.RollD20Advantage();

            Assert.True(dieRoll.DiceRolled.Count == 2);
        }

        /// <summary>
        /// Method to test that when two D20s are that they are sorted correctly
        /// in the list to return.
        /// </summary>
        [Fact]
        public void RollD20WithAdvantageRightSortOrderTest() 
        {
            var dieRoll = Die.RollD20Advantage();

            Assert.True(dieRoll.DiceRolled[0] <= dieRoll.DiceRolled[1]);
        }

        /// <summary>
        /// Method to test that when two D20s are rolled, the higher value is returned.
        /// </summary>
        [Fact]
        public void RollD20WithAdvantageRightDieReturnedTest() 
        {
            var dieRoll = Die.RollD20Advantage();
            var highRoll = dieRoll.GetDiceTotal();
            var highRollInList = dieRoll.DiceRolled[1];

            Assert.True(highRoll == highRollInList);
        }

        /// <summary>
        /// Method to test that when two D20s are rolled, a valid value is returned.
        /// </summary>
        [Fact]
        public void RollD20WithDisadvantageReturnValueTest() 
        {
            var dieRoll = Die.RollD20Disadvantage();

            var lowRoll = dieRoll.GetDiceTotal() ;

            Assert.True(lowRoll >= D20_MIN_VALUE && lowRoll <= D20_MAX_VALUE);
        }

        /// <summary>
        /// Method to test that exactly two dice are rolled.
        /// </summary>
        [Fact]
        public void RollD20WithDisadvantageValidNumberOfRolls() 
        {
            var dieRoll = Die.RollD20Disadvantage();

            Assert.True(dieRoll.DiceRolled.Count == 2);
        }

        /// <summary>
        /// Method to test that when two D20 die are rolled, they are stored in the correct order.
        /// </summary>
        [Fact]
        public void RollD20WithDisAvantageRightSortOrderTest() 
        {
            var dieRoll = Die.RollD20Disadvantage();

            Assert.True(dieRoll.DiceRolled[0] <= dieRoll.DiceRolled[1]);
        }

        /// <summary>
        /// Method to test that when two die are rolled with disadvantage, the lower is returned.
        /// </summary>
        [Fact]
        public void RollD20WithDisAvantageRightDieReturnedTest() 
        {
            var dieRoll = Die.RollD20Disadvantage();
            var lowRoll = dieRoll.GetDiceTotal();
            var lowRollInList = dieRoll.DiceRolled[0];

            Assert.True(lowRoll == lowRollInList);
        }

        /// <summary>
        /// Method to test that our output of rolling three four sided vice is valid.
        /// </summary>
        [Fact]
        public void RollMultipleDiceValidInputValidTotal() 
        {
            var minPossibleOutcome = 1 * MULTI_DICE_VALID_NUM_DICE;
            var maxPossibleOutcome = MULTI_DICE_VALID_SIDES * MULTI_DICE_VALID_NUM_DICE;

            var diceRoll = Die.Roll(MULTI_DICE_VALID_SIDES, MULTI_DICE_VALID_NUM_DICE);
            var outcome = diceRoll.GetDiceTotal();
            
            Assert.True(outcome >= minPossibleOutcome && outcome <= maxPossibleOutcome);
        }

        /// <summary>
        /// Method to make sure that we roll the correct number of dice.
        /// </summary>
        [Fact]
        public void RollMultipleDiceValidInputValidRollNumber() 
        {
            var diceRoll = Die.Roll(MULTI_DICE_VALID_SIDES, MULTI_DICE_VALID_NUM_DICE);
            var numDiceRolled = diceRoll.DiceRolled.Count;

            Assert.True(numDiceRolled == MULTI_DICE_VALID_NUM_DICE);
        }

        /// <summary>
        /// Method to check that each value rolled is valid.
        /// </summary>
        [Fact]
        public void RollMultipleDiceCheckMinValue() 
        {
            var diceRoll = Die.Roll(MULTI_DICE_VALID_SIDES, MULTI_DICE_VALID_NUM_DICE);

            foreach (var roll in diceRoll.DiceRolled)
            {
                Assert.True(roll >= 1 && roll <= MULTI_DICE_VALID_SIDES);
            }    

        }

        /// <summary>
        /// Method to check output if too few sides are provided.
        /// </summary>
        [Fact]
        public void RollMultipleDiceTooFewSides() 
        {
            Assert.Throws<Exception>(() => Die.Roll(-1, MULTI_DICE_VALID_NUM_DICE));
        }

        /// <summary>
        /// Method to check output if too many sides are provided.
        /// </summary>
        [Fact]
        public void RollMultipleDiceTooManySides() 
        {
            Assert.Throws<Exception>(() => Die.Roll(10000, MULTI_DICE_VALID_NUM_DICE));
        }

        /// <summary>
        /// Method to check output if too many dice are provided.
        /// </summary>
        [Fact]
        public void RollMultipleDiceTooManyDice() 
        {
            Assert.Throws<Exception>(() => Die.Roll(MULTI_DICE_VALID_SIDES, 1000));
        }

        /// <summary>
        /// Method to check output if too few dice are provided.
        /// </summary>
        [Fact]
        public void RollMultipleDiceTooFewDice() 
        {
            Assert.Throws<Exception>(() => Die.Roll(MULTI_DICE_VALID_SIDES, -1));
        }
    }
}
