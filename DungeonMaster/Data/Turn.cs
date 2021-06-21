using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    public class Turn
    {
        public Character CurrentCharacter { get; set; }

        public LinkedList<Character> OtherCharactersInOrder { get; set; } = new LinkedList<Character>();

        public bool WeaponAttackPossible { get; set; }

        public bool MagicAttackPossible { get; set; }

        public bool MagicHealPossible { get; set; }

        public bool MovePossible { get; set; }

        public Game Game { get; set; }

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
