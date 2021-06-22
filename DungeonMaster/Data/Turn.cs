using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Class representing the current Turn of the game.
    /// </summary>
    public class Turn
    {
        /// <summary>
        /// Current character whose turn it is.
        /// </summary>
        public Character CurrentCharacter { get; set; }

        /// <summary>
        /// List of all other characters in the game. Stored in turn order.
        /// </summary>
        public LinkedList<Character> OtherCharactersInOrder { get; set; } = new LinkedList<Character>();

        /// <summary>
        /// If the current character can launch a Weapon Attack.
        /// </summary>
        public bool WeaponAttackPossible { get; set; }

        /// <summary>
        /// If the current character can launch a magic Attack.
        /// </summary>
        public bool MagicAttackPossible { get; set; }

        /// <summary>
        /// If the current character can cast a healing spell.
        /// </summary>
        public bool MagicHealPossible { get; set; }

        /// <summary>
        /// If movement is possible for the current character.
        /// </summary>
        public bool MovePossible { get; set; }

        /// <summary>
        /// Game that the turn is for. 
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Constructor that creates a turn, for the Game provided.
        /// </summary>
        /// <param name="game"></param>
        public Turn(Game game) 
        {
            Game = game;
            if (Game.CharacterList != null) 
            {
                foreach (var character in Game.CharacterList) 
                {
                    OtherCharactersInOrder.AddLast(character);
                }
                CurrentCharacter = Game.CharacterList[0];
                OtherCharactersInOrder.RemoveFirst();
            }
            UpdatePossibilities();
        }

        /// <summary>
        /// Method to add the current character to the end of the queue, and make the 
        /// first Character in the list the current character.
        /// </summary>
        public void UpdateTurn() 
        {
            OtherCharactersInOrder.AddLast(CurrentCharacter);

            CurrentCharacter = OtherCharactersInOrder.First();
            OtherCharactersInOrder.RemoveFirst();

            UpdatePossibilities();
        }

        /// <summary>
        /// Update all the possible options the current character has.
        /// </summary>
        public void UpdatePossibilities() 
        {
            UpdateWeaponPossibilities();
            UpdateMagicAttackPossibilities();
            UpdateMagicHealPossibilities();
            UpdateMovementPossibilities();
        }

        /// <summary>
        /// Update if the person is able to attack another.
        /// </summary>
        public void UpdateWeaponPossibilities() 
        {
            if (CurrentCharacter.ActiveWeapon != null)
            {
                WeaponAttackPossible = true;
            }
            else
            {
                WeaponAttackPossible = false;
            }
        }
        /// <summary>
        /// Update if the character is able to use a spell attack.
        /// </summary>
        public void UpdateMagicAttackPossibilities() 
        {
            if (CurrentCharacter.ActiveSpell != null)
            {
                if (CurrentCharacter.ActiveSpell is DamageSpell) 
                {
                    MagicAttackPossible = true;
                }
            }
            
            MagicAttackPossible = false;
        }
        /// <summary>
        /// Update if the character is able to use a magic spell.
        /// </summary>
        public void UpdateMagicHealPossibilities() 
        {
            if (CurrentCharacter.ActiveSpell != null)
            {
                if (CurrentCharacter.ActiveSpell is HealingSpell)
                {
                    MagicHealPossible = true;
                }
            }

            MagicHealPossible = false;
        }

        /// <summary>
        /// As movement range is not yet impelemented, we assume movement is possible.
        /// </summary>
        public void UpdateMovementPossibilities() 
        {
            MovePossible = true;
        }
    }
}
