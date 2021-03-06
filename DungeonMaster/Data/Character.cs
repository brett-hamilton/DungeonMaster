/*************************************************
 * Name: Character.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/

using System;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Class representing a character in the game.
    /// </summary>
    public class Character : Drawable
    {
        /// <summary>
        /// increases stats of the character, as well as action points and health
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Melee weapon they have equipped
        /// </summary>
        public Weapon ActiveWeapon { get; set; }

        /// <summary>
        /// The amount of Health points they have
        /// </summary>
        public double Health { get; set; }

        /// <summary>
        /// The armor object they are wearing
        /// </summary>
        public Armor Armor { get; set; } = new Armor("Leather Armor", 6);

        /// <summary>
        /// The number of points they have to improve an attack or action
        /// </summary>
        public double ActionPoints { get; set; }

        /// <summary>
        /// Actions are used to implement attacks in-game
        /// </summary>
        public double Actions { get; set; }

        /// <summary>
        /// Represents the status of the character
        /// </summary>		
        public Status Status { get; set; }

        /// <summary>
        /// Inventory of the Spells and Weapons of the Player
        /// </summary>
        public Inventory PlayersInventory { get; set; } = new Inventory();

        /// <summary>
        /// What spell the character currently has equipped
        /// </summary>
        public Spell ActiveSpell { get; set; }

        /// <summary>
        /// Holds all of the stats of the player, defaults to 8 for all stats.
        /// </summary>
        public CharacterStats CharacterStats { get; set; } = new CharacterStats(8, 8, 8, 8, 8, 8);

        /// <summary>
        /// What weapon type the user is good with
        /// </summary>
        public WeaponType Proficiency { get; set; }

        /// <summary>
        /// Default constructor for a character
        /// </summary>
        public Character()
        {
            Weapon sword = new Weapon("Sword", Dice.D6, 5.0, WeaponType.OneHanded);
            Name = "Geralt";
            this.Health = 100;
            this.ActiveWeapon = sword;
            this.ActionPoints = 120;
            IsCollidable = false;
            this.BackupColorCode = "#FF00FF";
            this.ImageLocation = "/images/char1.png";
        }

        /// <summary>
        /// Constructor for the Character to be initialized
        /// </summary>
        /// <param name="name">Name of the character.</param>
        /// <param name="health">Amount of health points character has.</param>
        /// <param name="actionPoints">Number of action points character has.</param>
        public Character(string name, double health, double actionPoints)
        {
            this.ActiveWeapon = new Weapon("Sword", Dice.D6, 5.0, WeaponType.OneHanded);
            Armor = new Armor("Leather", 6);
            this.Name = name;
            this.Health = health;
            IsCollidable = false;
            this.ActionPoints = actionPoints;
            Status = Status.Alive;
            PlayersInventory = new Inventory();
        }

        /// <summary>
        /// Parameterized constructor for a character when creating one on the Character Creation page.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="health">The amount of health points the character has.</param>
        /// <param name="actionPoints">The number of action points the character has.</param>
        /// <param name="characterClass">The name of the class for the character.</param>
        public Character(string name, double health, int actionPoints, string characterClass)
        {
            Armor = new Armor("Leather", 6);
            this.Name = name;
            this.Health = health;
            this.ActionPoints = actionPoints;
            Status = Status.Alive;
            IsCollidable = false;
            PlayersInventory = new Inventory();

            switch (characterClass)
            {
                case "ranger":
                    ActiveWeapon = new Weapon("Long Bow", Dice.D6, 50, WeaponType.Range)
                    {
                        RangedWeapon = true
                    };

                    Proficiency = WeaponType.Range;
                    break;

                case "fighter":
                    ActiveWeapon = new Weapon("Battle Axe", Dice.D6, 1, WeaponType.TwoHanded);
                    Proficiency = WeaponType.TwoHanded;
                    break;

                case "wizard":
                    ActiveSpell = new DamageSpell("Fireball", SpellTypes.Fire, 20, Dice.D6, 1, 20);
                    break;

                default:
                    ActiveWeapon = new Weapon("Dagger", Dice.D6, 1, WeaponType.LightOneHanded);
                    Proficiency = WeaponType.LightOneHanded;
                    break;
            }
        }


        /// <summary>
        /// Constructor for the Character to be initialized, including player image.
        /// </summary>
        /// <param name="name">Name of the character.</param>
        /// <param name="health">Health of the character.</param>
        /// <param name="actionPoints">Action points for the character.</param>
        /// <param name="playerImage">Image file for the player.</param>
        public Character(string name, double health, double actionPoints, string playerImage)
        {
            this.ActiveWeapon = new Weapon("Sword", Dice.D6, 5.0, WeaponType.OneHanded);
            Armor = new Armor("Leather", 6);
            this.Name = name;
            this.Health = health;
            this.ActionPoints = actionPoints;
            IsCollidable = false;
            ImageLocation = playerImage;
            BackupColorCode = "#FF00FF";
            Status = Status.Alive;
            PlayersInventory = new Inventory();
        }

        /// <summary>
        /// Take health from the player
        /// </summary>
        /// <param name="damage">Amount of damage to subtract from the player's health.</param>
        public void DamagePlayer(double damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;
                Status = Status.Dead;
            }
        }
        /// <summary>
        /// Method to heal a player and give them health.
        /// </summary>
        /// <param name="health">Amount to be added to the player.</param>
        public void HealPlayer(double health)
        {
            Health += health;
        }

        /// <summary>
        /// Check the armor status with an attack value to see if the attack will hit or miss
        /// 
        /// </summary>
        /// <param name="attackValue">Value representing the attack.</param>
        /// <returns>True if armor is too weak, false otherwise.</returns>
        public bool CheckArmor(double attackValue)
        {
            if (attackValue >= Armor.ProtectionPoints)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Add a weapon to the Player's Inventory
        /// 
        /// </summary>
        /// <param name="weapon">A weapon to be added to the list.</param>
        public void AddWeaponInventory(Weapon weapon)
        {
            PlayersInventory.Weapons.Add(weapon);
        }

        /// <summary>
        /// Add a spell to the Player's Inventory
        /// 
        /// </summary>
        /// <param name="spell">A spell to be added to the list.</param>
        public void AddSpellInventory(Spell spell)
        {
            PlayersInventory.Spells.Add(spell);
        }

        /// <summary>
        /// determines if the user is efficient with the weapon they are currently holding
        /// </summary>
        /// <returns>integer of 2 if both weapon type and proficiency are the same</returns>
        public int IsProficient()
        {
            if (Proficiency == ActiveWeapon.WeaponType)
            {
                return 2;
            }

            return 0;
        }

        /// <summary>
        /// Lowers the action points of the character
        /// </summary>
        public void LowerActionPoint()
        {
            ActionPoints--;
        }

        /// <summary>
        /// makes all changes necessary to when a character levels up
        /// CURRENTLY: Leveling Up feature changes the Action Points the player has.
        /// Nothing else at the moment
        /// </summary>
        public void LevelUp()
        {
            double levelVariable = Level / 2;
            ActionPoints = 5 + Math.Floor(levelVariable);
        }
    }
}
