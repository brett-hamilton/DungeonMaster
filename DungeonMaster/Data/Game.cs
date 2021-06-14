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

			if (attacker.Weapon.Range < roundedDistance) 
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Returns the Coordinate representing the Character's location in the game.
		/// Created by: Jordan DeBord
		/// Last Updated: 06/12/2021
		/// </summary>
		/// <param name="character">Character to get coordinates from.</param>
		/// <returns>The coordinates of the character.</returns>
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
		public string MeleeAttackAttempt(Character attacker, Character defender) 
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
			var attackReport = attack.MeleeAttack(attacker, defender);

			return attackReport.GetAttackReport();

		}

		/// <summary>
		/// Ranged attack method, which will verify target is not dead and attempt to attack them.
		/// Created by: Jordan DeBord
		/// Last Updated: 06/12/2021
		/// </summary>
		/// <param name="attacker">Character attempting to attack the other.</param>
		/// <param name="defender">Character being attacked.</param>
		/// <returns>A string containing information about the result.</returns>
		public string RangedAttackAttempt(Character attacker, Character defender) 
		{
			if (!attacker.Weapon.rangedWeapon) 
			{
				return ($"{attacker.Name} does not have a ranged weapon to attack with.");
			}
			if (defender.IsDead)
			{
				return ($"{defender.Name} is already dead.");
			}

			var rangeCheck = RangedRangeCheck(attacker, defender);
			if (!rangeCheck)
			{
				return ($"{defender.Name} is too far away to range attack.");
			}

			// If the defender is in melee range, attacker has disadvantage.
			var disadvantageCheck = MeleeRangeCheck(defender, attacker);

			var attack = new Attack();
			var attackReport = attack.RangedAttack(attacker, defender, disadvantageCheck);

			return attackReport.GetAttackReport();
		}

		/// <summary>
		/// Check if the provided row and column are valid in the game board,
		/// if so check if that space is occupied. If not, place character there.
		/// Created by: Jordan DeBord
		/// Last Updated: 06/12/2021
		/// </summary>
		/// <param name="character">Character to be placed in the gameboard.</param>
		/// <param name="row">Row to place character in.</param>
		/// <param name="col">Column to place character in.</param>
		/// <returns>Boolean representing if character was placed into the gameboard.</returns>
		public bool AddCharacter(Character character, int row, int col) 
		{
			var currentOccupant = GameBoard[row, col];

			if (row >= Rows || col >= Columns || row < 0 || col < 0)
			{
				return false;
			}

			if (currentOccupant != null)
			{
				return false;
			}

			GameBoard[row, col] = character;
			return true;
		}

		/// <summary>
		/// Method to calculate the distance between two characters.
		/// </summary>
		/// <param name="character1">First character in the gameboard.</param>
		/// <param name="character2">Second character to calculate distance to.</param>
		/// <returns>distance between two characters.</returns>
		public double GetDistance(Coordinate character1, Coordinate character2)
		{
			double rowDifference = character1.Row - character2.Row;
			double colDifference = character1.Column - character2.Column;

			// Calculate distance using A^2 + B^2 = C^2
			double distance = Math.Sqrt(((rowDifference * rowDifference) + (colDifference * colDifference)));

			return distance;
		}
	}
}
