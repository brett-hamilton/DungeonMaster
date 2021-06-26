using DungeonMaster.Data;
using System.Collections.Generic;
using Xunit;

namespace XunitTest
{
    /// <summary>
    /// Class containing tests for Turns.
    /// </summary>
    public class TurnTests
    {
        /// <summary>
        /// Readonly damage spell, healing spell, and weapon used by the turns below. The addition or removal of these from the 
        /// characters in the turn are then used to test if our updates are working as expected.
        /// </summary>
        private readonly Weapon meleeWeapon = new Weapon { Name = "Sword", RangedWeapon = false };
        private readonly Spell damageSpell = new DamageSpell("Fire Ball", SpellTypes.Fire, 2, Dice.D2, 2, 20);
        private readonly Spell healingSpell = new HealingSpell("Heal", SpellTypes.Healing, 2, Dice.D2, 2, 20);


        /// <summary>
        /// Method to test that turns are updated.
        /// </summary>
        [Fact]
        public void UpdateTurnOnceTest()
        {
            Turn turn = new Turn();
            var character1 = new Character() { Name = "Char 1" }; ;
            var character2 = new Character() { Name = "Char 2" };

            turn.CurrentCharacter = character1;
            turn.OtherCharactersInOrder.AddFirst(character2);

            turn.UpdateTurn();

            var expectedCurrentCharacter = character2;

            Assert.True(turn.CurrentCharacter == expectedCurrentCharacter);

        }

        /// <summary>
        /// Method to test that turns are updated if done multiple times.
        /// </summary>
        [Fact]
        public void UpdateTurnTwiceTest()
        {
            Turn turn = new Turn();
            var character1 = new Character() { Name = "Char 1" }; ;
            var character2 = new Character() { Name = "Char 2" };

            turn.CurrentCharacter = character1;
            turn.OtherCharactersInOrder.AddFirst(character2);

            turn.UpdateTurn();
            turn.UpdateTurn();

            var expectedCurrentCharacter = character1;

            Assert.True(turn.CurrentCharacter == expectedCurrentCharacter);

        }

        /// <summary>
        /// If we add a weapon to our character and update the weapon possibilities,
        /// we should now have the option to attack with a weapon.
        /// </summary>
        [Fact]
        public void UpdateAddWeaponPossibilitiesTest()
        {
            var turn = new Turn();
            var character1 = new Character();
            character1.ActiveWeapon = meleeWeapon;
            turn.CurrentCharacter = character1;

            turn.UpdateWeaponPossibilities();

            Assert.True(turn.WeaponAttackPossible == true);
        }

        /// <summary>
        /// Method to test that if we remove a weapon, the bool representing it is switched to false.
        /// </summary>
        [Fact]
        public void UpdateRemoveWeaponPossibilitiesTest()
        {
            var turn = new Turn();
            var character1 = new Character();
            turn.WeaponAttackPossible = true;
            character1.ActiveWeapon = null;

            turn.CurrentCharacter = character1;

            turn.UpdateWeaponPossibilities();

            Assert.True(turn.WeaponAttackPossible == false);
        }

        /// <summary>
        /// If we add a damage spell to our character and update the magic attack possibility,
        /// we should now have the option to use it to attack.
        /// </summary>
        [Fact]
        public void UpdateAddMagicAttackPossibilitiesTest()
        {
            var turn = new Turn();
            var character1 = new Character();
            character1.ActiveSpell = damageSpell;
            turn.CurrentCharacter = character1;

            turn.UpdateMagicAttackPossibilities();

            Assert.True(turn.MagicAttackPossible == true);
        }

        /// <summary>
        /// Method to test that if we remove a damage spell, the bool representing it is set to false.
        /// </summary>
        [Fact]
        public void UpdateRemoveMagicAttackPossibilitiesTest()
        {
            var turn = new Turn();
            var character1 = new Character();
            turn.MagicAttackPossible = true;
            character1.ActiveSpell = null;
            turn.CurrentCharacter = character1;

            turn.UpdateMagicAttackPossibilities();

            Assert.True(turn.MagicAttackPossible == false);
        }

        /// <summary>
        /// If we add a healing spell to our character and update the heal possibility,
        /// we should now see that it is possible.
        /// </summary>
        [Fact]
        public void UpdateAddMagicHealTest()
        {
            var turn = new Turn();
            var character1 = new Character();
            character1.ActiveSpell = healingSpell;
            turn.CurrentCharacter = character1;

            turn.UpdateMagicHealPossibilities();

            Assert.True(turn.MagicHealPossible == true);
        }

        /// <summary>
        /// Method to test that if we remove a magic heal item, that the bool representing it it set to false.
        /// </summary>
        [Fact]
        public void UpdateRemoveMagicHealTest()
        {
            var turn = new Turn();
            var character1 = new Character();
            character1.ActiveSpell = null;
            turn.CurrentCharacter = character1;
            turn.MagicHealPossible = true;

            turn.UpdateMagicHealPossibilities();

            Assert.True(turn.MagicHealPossible == false);
        }

        /// <summary>
        /// If we set all possibilities to true, remove all weapons and spells,
        /// then when we update possibilities we should no longer have any option
        /// but to move (as it is by default allowed).
        /// </summary>
        [Fact]
        public void UpdateAllPossibilitiesTest()
        {
            var turn = new Turn();
            var game = new Game();
            var character1 = new Character();
            turn.CurrentCharacter = character1;
            character1.ActiveWeapon = null;
            character1.ActiveSpell = null;
            game.AddCharacter(character1, 2, 2);
            turn.Game = game;
            // Set all possibilities to True.
            turn.MagicAttackPossible = true;
            turn.MagicHealPossible = true;
            turn.WeaponAttackPossible = true;
            turn.MovePossible = true;
            turn.PushableObjects = new List<Drawable> { character1, character1 };
            turn.InteractionPossible = true;

            turn.UpdatePossibilities();

            Assert.True(turn.MagicAttackPossible == false);
            Assert.True(turn.WeaponAttackPossible == false);
            Assert.True(turn.MagicHealPossible == false);
            Assert.True(turn.InteractionPossible == false);
            Assert.True(turn.PushableObjects.Count == 0);
        }

        /// <summary>
        /// Method to test if a pushable object is nearby, if our method
        /// recognizes it.
        /// </summary>
        [Fact]
        public void UpdateInteractionPossibleTest()
        {
            var turn = new Turn();
            var game = new Game();
            var character1 = new Character();
            turn.CurrentCharacter = character1;
            var pushableObject = new Drawable() { IsCollidable = true };
            game.AddCharacter(character1, 2, 2);
            game.AddDrawable(pushableObject, 3, 2);
            turn.Game = game;

            turn.UpdateInteractionPossibilities();

            Assert.True(turn.InteractionPossible == true);
            Assert.True(turn.PushableObjects.Count == 1);
        }

        /// <summary>
        /// Method to test if a pushable object is not nearby, if our method
        /// recognizes it.
        /// </summary>
        [Fact]
        public void UpdateInteractionNotPossibleTest()
        {
            var turn = new Turn();
            var game = new Game();
            var character1 = new Character();
            turn.CurrentCharacter = character1;
            var pushableObject = new Drawable() { IsCollidable = true };
            game.AddCharacter(character1, 2, 2);
            game.AddDrawable(pushableObject, 4, 4);
            turn.Game = game;
            turn.InteractionPossible = true;
            turn.PushableObjects = new List<Drawable> { character1, character1 };

            turn.UpdateInteractionPossibilities();

            Assert.True(turn.InteractionPossible == false);
            Assert.True(turn.PushableObjects.Count == 0);
        }
    }
}
