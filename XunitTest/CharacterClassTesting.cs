using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMaster.Data;
using Xunit;

namespace XunitTest
{
    public class CharacterClassTesting
    {
        Character character1 = new Character("Dale Gribble", 125, 80);

        /// <summary>
        /// Checks that the player dies when health is depleted
        /// </summary>
        [Fact]
        public void CheckPlayerDyingFromDamage()
        {
            character1.DamagePlayer(125);

            Assert.Equal(Status.Dead, character1.Status);
        }

        /// <summary>
        /// Checks that player is Alive after small attack
        /// </summary>
        [Fact]
        public void CheckPlayerBeingInjuredFromDamage()
        {
            character1.DamagePlayer(100);

            Assert.True(character1.Status != Status.Dead);
        }

        /// <summary>
        /// Checks that the correct amount of healing is implemented
        /// </summary>
        [Fact]
        public void PlayerBeingHealed()
        {
            character1.HealPlayer(25);

            Assert.Equal(150, character1.Health);
        }

        /// <summary>
        /// Checks if the Armor is more powerful than the attack roll
        /// </summary>
        [Fact]
        public void CheckForBiggerArmorPoints()
        {
            character1.Armor = new Armor("Orange Hat", 200);
            Assert.False(character1.CheckArmor(100));
        }

        /// <summary>
        /// Checks that the armor is not enough to stop the attack roll
        /// </summary>
        [Fact]
        public void CheckForLowerArmorPoints()
        {
            character1.Armor = new Armor("Orange Hat", 200);
            Assert.True(character1.CheckArmor(200));
        }

        /// <summary>
        /// Makes sure adding a weapon works
        /// </summary>
        [Fact]
        public void AddWeaponToInventory()
        {
            Weapon newWeapon = new Weapon("Pocket Sand", Dice.D12, 100, WeaponType.LightOneHanded);
            character1.AddWeaponInventory(newWeapon);

            Assert.Contains(newWeapon, character1.PlayersInventory.Weapons);
        }

        /// <summary>
        /// Make sure adding a spell works
        /// </summary>
        [Fact]
        public void AddSpellToInventory()
        {
            Spell newSpell = new Spell("Cigarette", SpellTypes.Fire, Dice.D6, 3, 20);

            character1.AddSpellInventory(newSpell);

            Assert.Contains(newSpell, character1.PlayersInventory.Spells);
        }

        /// <summary>
        /// Check that the Spell Health roll lands between specified parameters that it should fall into
        /// </summary>
        [Fact]
        public void HealingSpellParameterCheck()
        {
            character1.ActiveSpell = new HealingSpell("Revive", SpellTypes.Healing, 20, Dice.D6, 2, 10);

            var healingPowerReport = character1.ActiveSpell.GetHealingSpellPower();

            Assert.InRange(healingPowerReport.GetDiceTotal(), 1, 12);
        }

        /// <summary>
        /// Confirms that the character is proficient with the weapon they are using
        /// </summary>
        [Fact]
        public void CheckingIfPlayerIsProficient()
        {
            character1.Proficiency = WeaponType.OneHanded;

            Assert.Equal(2, character1.IsProficient());


        }

        /// <summary>
        /// Confirms that they Character is not proficient with the weapon they are using
        /// </summary>
        [Fact]
        public void CheckingIfPlayerIsNotProficient()
        {
            character1.Proficiency = WeaponType.TwoHanded;

            Assert.NotEqual(2, character1.IsProficient());


        }
    }
}
