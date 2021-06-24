using System;
using System.Collections;
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
        /// Gets or sets the gameboard.
        /// </summary>
        /// <value>The gameboard.</value>
        public Gameboard Gameboard { get; private set; }

        /// <summary>
        /// Gets or sets the character list.
        /// </summary>
        /// <value>
        /// The character list of characters in the game.
        /// </value>
		public List<Character> CharacterList { get; set; }

		public Turn CurrentTurn { get; set; }

		/// <summary>
		/// Default constructor to build a generic game with no entities.
		/// </summary>
		public Game() 
		{
			Gameboard = new Gameboard(5, 5);
			GameName = "Test Game";
			CharacterList = new List<Character>();
		}

		/// <summary>
		/// Constructor to create a game with a set gameboard size.
		/// </summary>
		/// <param name="rows">Number of rows for the game board.</param>
		/// <param name="columns">Number of columns for the game board.</param>
		public Game(int columns, int rows)
		{
			Gameboard = new Gameboard(columns, rows);
			CharacterList = new List<Character>();
		}

		/// <summary>
		/// Constructor to build a generic game with two characters..
		/// </summary>
		/// <param name="char1">The first character to add to the game.</param>
		/// <param name="char2">The second character to add to the game.</param>
		public Game(Character char1, Character char2)
		{
			Gameboard = new Gameboard(5, 5);
			GameName = "Test Game";
			CharacterList = new List<Character>();
			AddCharacter(char1, 2, 3);
			AddCharacter(char2, 2, 4);

		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="name">The name of the game.</param>
        /// <param name="gameboard">The gameboard to use.</param>
        /// <param name="characterList">The character list.</param>
        public Game(string name, Gameboard gameboard, List<Character> characterList)
		{
			this.GameName = name;
			this.Gameboard = gameboard;
			this.CharacterList = characterList;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class based on an already existing game.
        /// </summary>
        /// <param name="gameToCopy">The game to copy.</param>
        public Game(Game gameToCopy)
        {
			this.GameName = gameToCopy.GameName;
			this.Gameboard = gameToCopy.Gameboard;
			this.CharacterList = gameToCopy.CharacterList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class based on an already existing game.
        /// </summary>
        /// <param name="gameToCopy">The game to copy.</param>
        /// <param name="newGameName">The new game's name.</param>
        public Game(Game gameToCopy, string newGameName)
        {
			this.GameName = newGameName;
			this.Gameboard = gameToCopy.Gameboard;
			this.CharacterList = gameToCopy.CharacterList;
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
		public bool AddCharacter(Character character, int column, int row)
        {
			if (Gameboard.AddDrawable(character, column, row))
			{
				CharacterList.Add(character);
				return true;
			}
			else
			{
				return false;
			}
        }

        /// <summary>
        /// Adds the drawable to the gameboard if column/row are valid.
        /// </summary>
        /// <param name="drawable">The drawable.</param>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <returns>True if drawable can be inserted at location given, false otherwise.</returns>
        public bool AddDrawable(Drawable drawable, int column, int row)
        {
			if(Gameboard.AddDrawable(drawable, column, row))
            {
				return true;
            }
			else
            {
				return false;
            }			
        }

		/// <summary>
		/// Melee Attack method, which will check range, then call the attack class's melee attack.
		/// </summary>
		/// <param name="attacker">Attacking character.</param>
		/// <param name="defender">Defending character.</param>
		/// <returns>String explaining result if needed.</returns>
		public string MeleeAttackAttempt(Character attacker, Character defender) 
		{
			if (defender.Status == Status.Dead) 
			{
				return ($"{defender.Name} is already dead.");
			}
			var rangeCheck = Gameboard.MeleeRangeCheck(attacker, defender);
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
			if (!attacker.ActiveWeapon.RangedWeapon) 
			{
				return ($"{attacker.Name} does not have a ranged weapon to attack with.");
			}
			if (defender.Status == Status.Dead)
			{
				return ($"{defender.Name} is already dead.");
			}

			var rangeCheck = Gameboard.RangedRangeCheck(attacker, defender);
			if (!rangeCheck)
			{
				return ($"{defender.Name} is too far away to range attack.");
			}

			// If the defender is in melee range, attacker has disadvantage.
			var disadvantageCheck = Gameboard.MeleeRangeCheck(defender, attacker);

			var attack = new Attack();
			var attackReport = attack.RangedAttack(attacker, defender, disadvantageCheck);

			return attackReport.GetAttackReport();
		}
		/// <summary>
		/// Method to attempt to heal another character with a spell.
		/// </summary>
		/// <param name="caster">Character casting the spell. </param>
		/// <param name="receiver">Target of the spell.</param>
		/// <returns>String describing the result.</returns>
		public string SpellHealAttempt(Character caster, Character receiver)
        {
			if (receiver.Status == Status.Dead)
			{
				return ($"{receiver.Name} is already dead.");
			}

			var rangeCheck = Gameboard.SpellRangeCheck(caster, receiver);
			if (!rangeCheck)
			{
				return ($"{receiver.Name} is too far away to heal.");
			}

			var heal = new Heal();

			var healingReport = heal.HealCharacter(caster, receiver);

			return healingReport.GetHealingReport();
		}

		/// <summary>
		/// Attempt to attack another character with a spell.
		/// </summary>
		/// <param name="caster">Character attempting to attack. </param>
		/// <param name="receiver">Character defending. </param>
		/// <returns>A string describing the outcome of the attempt.</returns>
		public string SpellAttackAttempt(Character caster, Character receiver)
        {
			if (receiver.Status == Status.Dead)
			{
				return ($"{receiver.Name} is already dead.");
			}

			var rangeCheck = Gameboard.SpellRangeCheck(caster, receiver);
			if (!rangeCheck)
			{
				return ($"{receiver.Name} is too far away to attack.");
			}

			var attack = new Attack();

			var attackReport = attack.SpellAttack(caster, receiver);

			return attackReport.GetSpellAttackReport();


        }

        /// <summary>
        /// Gets the formatted character list.
        /// </summary>
        /// <returns> String with all character names in the game</returns>
        public string GetFormattedCharacterList()
        {
			string outputString = string.Empty;
			if (CharacterList.Count > 0)
			{
				foreach (Character character in CharacterList)
				{
					outputString += character.Name + "\n";
				}
			}
			else
			{
				outputString = "No Characters In Game";
			}

			return outputString;
		}


        /// <summary>
        /// Attempts to move the drawable (character) in the CardinalDirection (direction)
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>Returns a string reporting the outcome</returns>
	    public string CharacterMove(Drawable character, CardinalDirection direction) 
		{
			// Once implemented -> check movement points.
			var currentPosition = Gameboard.GetCoordinate(character);
			// Get new Coords
			var newCoords = Gameboard.GetNewCoordinate(currentPosition, direction);
			// Call Move

			return Gameboard.Move(character, currentPosition, newCoords).GetMoveResult();
		}

        /// <summary>
        /// Attempts to push "itemToPush" from "character".
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="itemToPush">The item to push.</param>
        /// <returns>string representing the result of the action</returns>
        public string PushObject(Drawable character, Drawable itemToPush)
        {
			Coordinate currLocation = Gameboard.GetCoordinate(itemToPush);
			PushReport pushReport = Gameboard.GetCoordinateAfterPush(character, itemToPush);

			if(!pushReport.PushPossible)
            {
				return pushReport.GetPushResult();
			}
			else
            {
				MoveReport moveReport = Gameboard.Move(itemToPush, currLocation, pushReport.NewCoordinate);
				pushReport.PushPossible = moveReport.MoveSuccessful;
				pushReport.ErrorString = moveReport.ErrorString;
				return pushReport.GetPushResult();
			}		
        }
	}
}
