﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    public class Gameboard
    {
        /// <summary>
        /// Contains the Drawables objects that make up the game board.
        /// </summary>
        /// <value>The drawables.</value>
        public Drawable[,] Drawables { get; set; }

        /// <summary>
        /// Gets or sets the number of rows.
        /// </summary>
        /// <value>The rows.</value>
        public int Rows { get; protected set; }

        /// <summary>
        /// Gets or sets the number of columns.
        /// </summary>
        public int Columns { get; protected set; }

        /// <summary>
        /// Gets or sets the image location.
        /// </summary>
        /// <value>The image location.</value>
        public string ImageLocation { get; set; }

        /// <summary>
        /// Default constructor, gives a 40x40 board.
        /// </summary>
        public Gameboard()
        {
            Rows = 40;
            Columns = 40;
            Drawables = new Drawable[Columns, Rows];
        }

        /// <summary>
        /// Constructor that generates a gameboard of the given size.
        /// </summary>
        /// <param name="rows">Number of rows for the gameboard.</param>
        /// <param name="columns">Number of columns for the gameboard.</param>
        public Gameboard(int columns, int rows)
        {
            if (rows < 1)
            {
                rows = 5;
            }
            if (columns < 1)
            {
                columns = 5;
            }
            Rows = rows;
            Columns = columns;
            Drawables = new Drawable[Columns, Rows];
            ImageLocation = "/images/tempmap.png";
        }

        /// <summary>
        /// Returns the Coordinate representing the Drawable's location in the game.
        /// Created by: Jordan DeBord
        /// Last Updated: 06/12/2021 by Dustin Ollis
        /// Update: Restructured to Drawable over Character.
        /// </summary>
        /// <param name="Drawable">Drawable to get coordinates from.</param>
        /// <returns>The coordinates of the character.</returns>
        public Coordinate GetCoordinate(Drawable drawable)
        {
            Coordinate coordinateToReturn = null;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (drawable == Drawables[j, i])
                    {
                        coordinateToReturn = new Coordinate() { Row = i, Column = j };
                        return coordinateToReturn;
                    }
                }
            }
            return coordinateToReturn;
        }

        /// <summary>
        /// Attempts to add the drawable to the game board. 
        /// </summary>
        /// <param name="drawable">The drawable.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///     <c>true</c> if the item is added; otherwise, <c>false</c>.
        /// </returns>
        public bool AddDrawable(Drawable drawable, int column, int row)
        {
            if (row < Rows && column < Columns && row > -1 && column > -1)
            {
                if (Drawables[column, row] != null)
                {
                    return false;
                }
                else
                {
                    Drawables[column, row] = drawable;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified row and column is occupied.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <c>true</c> if the specified row is occupied; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsOccupied(int column, int row)
        {
            if (row < Rows && column < Columns && row > -1 && column > -1)
            {
                if (Drawables[column, row] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
		/// Method to determine if the defender is within range of the attacker's
		/// ranged weapon.
		/// Created by: Jordan DeBord
		/// Last Updated: 06/14/2021
		/// </summary>
		/// <param name="attacker">Attacking Character.</param>
		/// <param name="defender">Defending Character</param>
		/// <returns>Boolean representing if attack is in range.</returns>
		public bool RangedRangeCheck(Character attacker, Character defender)
        {
            var attackerCoordinates = GetCoordinate(attacker);
            var defenderCoordinates = GetCoordinate(defender);

            // If either character is not in the gameboard, return null;
            if (attackerCoordinates == null || defenderCoordinates == null)
            {
                return false;
            }

            double distanceBetween = GetDistance(attackerCoordinates, defenderCoordinates);

            // In order to allow diagonal attacks, we will round the value down to the previous whole number.
            var roundedDistance = Math.Round(distanceBetween, 0, MidpointRounding.ToZero);

            if (attacker.ActiveWeapon.Range < roundedDistance)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to determine if the player is within melee range. As of now we assume all melee
        /// ranges are 1 block.
        /// Created by: Jordan DeBord
        /// Last Updated: 06/12/2021
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

            double distanceBetween = GetDistance(attackerCoord, defenderCoord);

            // In order to allow diagonal attacks, we will round the value down to the previous whole number.
            var roundedDistance = Math.Round(distanceBetween, 0, MidpointRounding.ToZero);

            // If the unit is within one vertical or horizontal block. This would also include
            //      diagonal locations.
            if (roundedDistance <= 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method determines if a receiver is within range to accept a healing spell
        /// Author: Hunter Page
        /// </summary>
        /// <param name="caster">the person using the spell</param>
        /// <param name="receiver">the person receiving the spell</param>
        /// <returns>true if receiver is in range, false otherwise</returns>
        public bool SpellRangeCheck(Character caster, Character receiver)
        {
            Coordinate attackerCoord = GetCoordinate(caster);
            Coordinate defenderCoord = GetCoordinate(receiver);

            if (attackerCoord == null || defenderCoord == null)
            {
                return false;
            }

            double distanceBetween = GetDistance(attackerCoord, defenderCoord);

            // In order to allow diagonal attacks, we will round the value down to the previous whole number.
            var roundedDistance = Math.Round(distanceBetween, 0, MidpointRounding.ToZero);

            if (caster.ActiveSpell.Range < roundedDistance)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to calculate the distance between two characters.
        /// </summary>
        /// <param name="character1">First character in the gameboard.</param>
        /// <param name="character2">Second character to calculate distance to.</param>
        /// <returns>Distance between two characters.</returns>
        public double GetDistance(Coordinate character1, Coordinate character2)
        {
            double rowDifference = character1.Row - character2.Row;
            double colDifference = character1.Column - character2.Column;

            // Calculate distance using A^2 + B^2 = C^2
            double distance = Math.Sqrt(((rowDifference * rowDifference) + (colDifference * colDifference)));

            return distance;
        }

        /// <summary>
        /// Gets the new coordinate.
        /// </summary>
        /// <param name="currentPosition">The current position of the object in the gameboard.</param>
        /// <param name="direction">The direction to move.</param>
        /// <returns></returns>
        public Coordinate GetNewCoordinate(Coordinate currentPosition, CardinalDirection direction) 
        {
            var newCoordinate = new Coordinate();

            var firstCharacterInDirection = direction.ToString()[0];

            if (firstCharacterInDirection.Equals('N'))
            {
                newCoordinate.Row = currentPosition.Row - 1;
            }
            else if (firstCharacterInDirection.Equals('S'))
            {
                newCoordinate.Row = currentPosition.Row + 1;
            }
            else 
            {
                newCoordinate.Row = currentPosition.Row;
                if(direction.ToString().Contains("E"))
                {
                    newCoordinate.Column = currentPosition.Column + 1;
                }
                else
                {
                    newCoordinate.Column = currentPosition.Column - 1;
                }
                return newCoordinate;
            }


            if (direction.ToString().Contains("E"))
            {
                newCoordinate.Column = currentPosition.Column + 1;
            }
            else if (direction.ToString().Contains("W"))
            {
                newCoordinate.Column = currentPosition.Column - 1;
            }
            else 
            {
                newCoordinate.Column = currentPosition.Column;
            }

            return newCoordinate;
        }

        /// <summary>
        /// Moves the specified object to move.
        /// </summary>
        /// <param name="objectToMove">The object to move.</param>
        /// <param name="currentCoordinate">The current coordinate.</param>
        /// <param name="newCoordinate">The new coordinate.</param>
        /// <returns>A string reporting the result of the move</returns>
        public string Move(Drawable objectToMove, Coordinate currentCoordinate, Coordinate newCoordinate) 
        {
            // Validate Coords
            var x = newCoordinate.Column;
            var y = newCoordinate.Row;
            if (x >= Columns || x < 0)
            {
                return "Coordinate was out of bounds: Column";
            }

            if (y < 0 || y >= Rows) 
            {
                return "Coordinate was out of bounds: Row";
            }
            // Validate not occupied
            if (!(Drawables[x,y] == null))
            {
                return "Space is occupied already";
            }
            else
            {
                Drawables[currentCoordinate.Column, currentCoordinate.Row] = null;
                Drawables[x, y] = objectToMove;
                return $"Character moved to {x + 1}, {y + 1}";
            }
        }
    }
}
