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
        /// <value>
        /// The drawables.
        /// </value>
        public Drawable[,] Drawables { get; set; }

        public int Rows { get; protected set; }

        public int Columns { get; protected set; }

        public Gameboard()
        {
            Rows = 40;
            Columns = 40;
            Drawables = new Drawable[Rows, Columns];
        }

        public Gameboard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Drawables = new Drawable[Rows, Columns];
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
                    if (drawable == Drawables[i, j])
                    {
                        coordinateToReturn = new Coordinate() { Row = i, Column = j };
                        return coordinateToReturn;
                    }
                }
            }
            return coordinateToReturn;
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
        /// Created by: Jordan DeBord
        /// Last Updated: 06/12/2021
        /// </summary>
        /// <param name="attacker">Attacking Character.</param>
        /// <param name="defender">Defending Character</param>
        /// <returns>Boolean representing if attack is in range.</returns>
        public bool RangedRangeCheck(Character attacker, Character defender)
        {
            return true;
        }

        /// <summary>
        /// Attempts to add the drawable to the 
        /// </summary>
        /// <param name="drawable">The drawable.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public Boolean AddDrawable(Drawable drawable, int row, int column)
        {
            if (row < Rows && column < Columns && row > -1 && column > -1)
            {
                if (Drawables[row, column] != null)
                    return false;
                else
                    Drawables[row, column] = drawable;
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
        public Boolean IsOccupied(int row, int column)
        {
            if (row < Rows && column < Columns && row > -1 && column > -1)
            {
                if (Drawables[row, column] != null)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
