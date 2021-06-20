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
		/// melee weapon they have equipped
		/// </summary>
		public Weapon ActiveWeapon { get; set; } 

		/// <summary>
		/// The amount of Health points they have
		/// </summary>
		public double Health { get; set; }

		/// <summary>
		/// They armor object they are wearing
		/// </summary>
		public Armor Armor { get; set; } = new Armor("Leather Armor", 6);

		/// <summary>
		/// The number of points they have to perform an attack or action
		/// </summary>
		public double ActionPoints { get; set; }

		///represents the current status of the player
		public Status Status { get; set; }

		///Inventory of the Spells and Weapons of the Player
		public Inventory PlayersInventory { get; set; }

		///temporary spell attribute to create the attack method in Attack.cs for proof of concept
		public Spell ActiveSpell { get; set; }

		///holds all of the stats of the player
		public CharacterStats CharacterStats { get; set; }

		public Character()
		{
			Weapon sword = new Weapon("sword", 10, Dice.D6, 5.0);
			Name = "Geralt";
			this.Health = 100;
			this.ActiveWeapon = sword;
			this.ActionPoints = 120;
			this.IsCollidable = true;
			this.BackupColorCode = "#FF00FF";
		}

		/// <summary>
		/// Constructor for the Character to be initialized
		/// </summary>
		/// <param name="name"></param>
		/// <param name="health"></param>
		public Character(string name, double health, double actionPoints)
		{
			this.ActiveWeapon = new Weapon("Sword", 10, Dice.D6, 5.0);
			Armor = new Armor("Leather", 6);
			this.Name = name;
			this.Health = health;
			this.ActionPoints = actionPoints;
			Status = Status.Alive;
		}

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
					break;

				case "fighter" :
					ActiveWeapon = new Weapon("Battle Axe", 20, Dice.D6, 1);
					break;

				case "wizard" :
					ActiveSpell = new DamageSpell("Fireball", SpellTypes.Fire, 20, Dice.D6, 1, 20);
					break;

				default :
					ActiveWeapon = new Weapon("dagger", 2, Dice.D6, 1);
					break;
			}
		}
			

		/// <summary>
		/// Constructor for the Character to be initialized
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
		/// take health from the player
		/// </summary>
		/// <param name="damage"></param>
		public void DamagePlayer(double damage)
		{
			Health -= damage;

			if(Health <= 0)
			{
				Health = 0;
				Status = Status.Dead;
			}
		}

		/// <summary>
		/// check the armor status with an attack value to see if the attack will hit or miss
		/// 
		/// </summary>
		/// <param name="attackValue"></param>
		/// <returns>true if armor is too weak, false otherwise</returns>
		public bool CheckArmor(double attackValue)
		{
			if(attackValue >= Armor.ProtectionPoints)
			{
				return true;
			}

			return false;

		}

		/// <summary>
		/// add a weapon to the Player's Inventory
		/// 
		/// </summary>
		/// <param name="weapon">a weapon to be added to the list</param>
		/// <returns>true if armor is too weak, false otherwise</returns>
		public void addWeaponInventory(Weapon weapon)
        {
			PlayersInventory.Weapons.Add(weapon);
        }

		/// <summary>
		/// add a spell to the Player's Inventory
		/// 
		/// </summary>
		/// <param name="weapon">a spell to be added to the list</param>public void addSpellInventory(Spell spell)
		public void addSpellInventory(Spell spell)
        {
			PlayersInventory.Spells.Add(spell);
        }

		/// <summary>
		/// Gets a number for the healing ppower of a spell
		/// </summary>
		/// <returns></returns>
		public double GetHealingSpellPower()
        {

			int.TryParse(ActiveSpell.DiceUsed.ToString()[1..], out int dieSides);
			var spellRollReport = Die.Roll(dieSides, ActiveSpell.NumberOfRolls);
			return spellRollReport.GetDiceTotal() + CharacterStats.Intelligence;
        }
	}
}
