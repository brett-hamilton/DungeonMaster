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

		public Gameboard Gameboard { get; set; }

		/// <summary>
		/// Constructor to create a game with a set gameboard size. the game.
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
		public Game(int rows, int columns)
		{
			Gameboard = new Gameboard(rows, columns);
		}

		/// <summary>
		/// Default constructor to build a generic game.
		/// </summary>
		public Game() 
		{
			Gameboard = new Gameboard(5, 5);
			GameName = "Test Game";
		}

		/// <summary>
		/// Default constructor to build a generic game.
		/// </summary>
		public Game(Character char1, Character char2)
		{
			Gameboard = new Gameboard(5, 5);
			GameName = "Test Game";
			Gameboard.AddDrawable(char1, 2, 2);
			Gameboard.AddDrawable(char2, 2, 3);
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
			Coordinate attackerCoord = Gameboard.GetCoordinate(attacker);
			Coordinate defenderCoord = Gameboard.GetCoordinate(defender);

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
			return Gameboard.AddDrawable(character, row, col);
		}
	}
}
