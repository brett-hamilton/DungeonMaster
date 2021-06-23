/*************************************************
 * Name: Character.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
	public class Character : Drawable
	{
		/// <summary>
		/// Name of the character
		/// </summary>
		//public string Name { get; set; }

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
		/// The number of points they have to perform an attack or action
		/// </summary>
		public double ActionPoints { get; set; }

		/// <summary>
		/// Represents the status of the character
		/// </summary>		
		public Status Status { get; set; }

		/// <summary>
		/// Inventory of the Spells and Weapons of the Player
		/// </summary>
		public Inventory PlayersInventory { get; set; }

		/// <summary>
		/// Temporary spell attribute to create the attack method in Attack.cs for proof of concept
		/// </summary>
		public Spell ActiveSpell { get; set; }

		/// <summary>
		/// Holds all of the stats of the player
		/// </summary>
		public CharacterStats CharacterStats { get; set; }

		/// <summary>
		/// What weapon type the user is good with
		/// </summary>
		public WeaponType Proficiency { get; set; }

		/// <summary>
		/// Default constructor for a character
		/// </summary>
		public Character()
		{
			Weapon sword = new Weapon("sword", 10, Dice.D6, 5.0);
			Name = "Geralt";
			this.Health = 100;
			this.ActiveWeapon = sword;
			this.ActionPoints = 120;
			this.IsCollidable = true;
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
			this.ActiveWeapon = new Weapon("Sword", 10, Dice.D6, 5.0);
			Armor = new Armor("Leather", 6);
			this.Name = name;
			this.Health = health;
			this.ActionPoints = actionPoints;
			Status = Status.Alive;
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

			switch(characterClass)
            {
				case "ranger" :
					ActiveWeapon = new Weapon("long bow", 10, Dice.D6, 50)
					{
						RangedWeapon = true
                    };

					Proficiency = WeaponType.Range;
					break;

				case "fighter" :
					ActiveWeapon = new Weapon("Battle Axe", 20, Dice.D6, 1);
					Proficiency = WeaponType.TwoHanded;
					break;

				case "wizard" :
					ActiveSpell = new DamageSpell("Fireball", SpellTypes.Fire, 20, Dice.D6, 1, 20);
					break;

				default :
					ActiveWeapon = new Weapon("dagger", 2, Dice.D6, 1);
					Proficiency = WeaponType.LightOneHanded;
					break;
			}
		}
			

		/// <summary>
		/// Constructor for the Character to be initialized, including player image
		/// </summary>
		/// <param name="name"></param>
		/// <param name="health"></param>
		public Character(string name, double health, double actionPoints, string playerImage)
		{
			this.ActiveWeapon = new Weapon("Sword", 10, Dice.D6, 5.0);
			Armor = new Armor("Leather", 6);
			this.Name = name;
			this.Health = health;
			this.ActionPoints = actionPoints;
			IsCollidable = true;
			ImageLocation = playerImage;
			BackupColorCode = "FF00FF";
			Status = Status.Alive;
		}

		/// <summary>
		/// Take health from the player
		/// </summary>
		/// <param name="damage">Amount of damage to subtract from the player's health.</param>
		public void DamagePlayer(double damage)
		{
			Health -= damage;

			if(Health <= 0)
			{
				Health = 0;
				Status = Status.Dead;
			}
		}

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
			if(attackValue >= Armor.ProtectionPoints)
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
		public void addWeaponInventory(Weapon weapon)
        {
			PlayersInventory.Weapons.Add(weapon);
        }

		/// <summary>
		/// Add a spell to the Player's Inventory
		/// 
		/// </summary>
		/// <param name="weapon">A spell to be added to the list.</param>
		public void addSpellInventory(Spell spell)
        {
			PlayersInventory.Spells.Add(spell);
        }

		/// <summary>
		/// Gets a number for the healing power of a spell
		/// </summary>
		/// <returns>The healing power of the spell.</returns>
		public DiceRollReport GetHealingSpellPower()
        {

			int.TryParse(ActiveSpell.DiceUsed.ToString()[1..], out int dieSides);
			var spellRollReport = Die.Roll(dieSides, ActiveSpell.NumberOfRolls);
			return spellRollReport;
        }

		/// <summary>
		/// determines if the user is efficient with the weapon they are currently holding
		/// </summary>
		/// <returns>integer of 2 if both weapon type and proficiency are the same</returns>
		public int isProficient()
        {
			if(Proficiency == ActiveWeapon.WeaponType)
            {
				return 2;
            }

			return 0;
        }
	}
}
