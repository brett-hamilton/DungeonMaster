using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    public class Game
    {
        /// <summary>
        /// Name of the game.
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Gameboard, representing a two dimensional array of potential Character locations.
        /// </summary>
        public Character[,] GameBoard { get; set; }

        /// <summary>
        /// Number of rows in the game board.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Number of columns in the game board.
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// Constructor to create a game with a set gameboard size. the game.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Game(int rows, int columns)
        {
            GameBoard = new Character[rows, columns];
            Rows = rows;
            Columns = columns;
        }

        /// <summary>
        /// Default constructor to build a generic game.
        /// </summary>
        public Game() 
        {
            Rows = 5;
            Columns = 5;
            GameBoard = new Character[Rows, Columns];
            GameName = "Test Game";
        }

        /// <summary>
        /// Default constructor to build a generic game.
        /// </summary>
        public Game(Character char1, Character char2)
        {
            Rows = 5;
            Columns = 5;
            GameBoard = new Character[Rows, Columns];
            GameName = "Test Game";
            GameBoard[2, 2] = char1;
            GameBoard[2, 3] = char2;
        }

        /// <summary>
        /// Method to determine if the player is within melee range. As of now we assume all melee
        /// ranges are 1 block.
        /// </summary>
        /// <param name="attacker">Character attempting to attack the other. </param>
        /// <param name="defender">Character defending against the other.</param>
        /// <returns>Boolean representing if character is within range.</returns>
        public bool MeleeRangeCheck(Character attacker, Character defender)
        {
            Coordinate attackerCoord = GetCoordinate(attacker);
            Coordinate defenderCoord = GetCoordinate(defender);

            if (attackerCoord == null || defenderCoord == null)
            {
                return false;
            }

            var verticalDistance = attackerCoord.Row - defenderCoord.Row;
            var horizontalDistance = attackerCoord.Column - defenderCoord.Column;

            // If the unit is within one vertical or horizontal block. This would also include
            //      diagonal locations.
            if (Math.Abs(verticalDistance) == 1 || Math.Abs(horizontalDistance) == 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// As of now, we assume all ranged attacks are within range.
        /// </summary>
        /// <param name="attacker">Attacking Character.</param>
        /// <param name="defender">Defending Character</param>
        /// <returns>Boolean representing if attack is in range.</returns>
        public bool RangedRangeCheck(Character attacker, Character defender)
        {
            return true;
        }

        /// <summary>
        /// Returns the Coordinate representing the Character's location in the game.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public Coordinate GetCoordinate(Character character)
        {
            Coordinate coordinateToReturn = null;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (character == GameBoard[i, j])
                    {
                        coordinateToReturn = new Coordinate() { Row = i, Column = j };
                        return coordinateToReturn;
                    }
                }
            }
            return coordinateToReturn;
        }

        /// <summary>
        /// Melee Attack method, which will check range, then call the attack class's melee attack.
        /// </summary>
        /// <param name="attacker">Attacking character.</param>
        /// <param name="defender">Defending character.</param>
        /// <returns>String explaining result if needed.</returns>
        public string MeleeAttack(Character attacker, Character defender) 
        {
            if (defender.IsDead) 
            {
                return ($"{defender.Name} is already dead.");
            }
            var rangeCheck = MeleeRangeCheck(attacker, defender);
            if (!rangeCheck) 
            {
                return ($"{defender.Name} is too far away to melee attack.");
            }

            var attack = new Attack();
            attack.MeleeAttack(attacker, defender);
            return null;

        }
    }
}
