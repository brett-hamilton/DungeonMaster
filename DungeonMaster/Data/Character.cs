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
		public Weapon Weapon { get; set; } 

		/// <summary>
		/// The amount of Health points they have
		/// </summary>
		public double Health { get; set; }

		/// <summary>
		/// They armor object they are wearing
		/// </summary>
		public Armor Armor { get; set; } = new Armor("Leather Armor", 6);

		/// <summary>
		/// determines if the player is dead or not for future actions
		/// </summary>
		public bool IsDead { get; set; } 

		/// <summary>
		/// The number of points they have to perform an attack or action
		/// </summary>
		public double ActionPoints { get; set; }

		///represents the current status of the player
		public Status Status { get; set; }

		public Character()
		{
			Weapon sword = new Weapon("sword", 10, Dice.D6, 5.0);
			this.Name = "Geralt";
			this.Health = 100;
			this.Weapon = sword;
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
			Weapon sword = new Weapon("Sword", 10, Dice.D6, 5.0);
			this.Weapon = sword;
			Armor armor = new Armor("Leather", 6);
			Armor = armor;
			this.Name = name;
			this.Health = health;
			IsDead = false;
			this.ActionPoints = actionPoints;
		}



		/// <summary>
		/// Constructor for the Character to be initialized
		/// </summary>
		/// <param name="name"></param>
		/// <param name="health"></param>
		public Character(string name, double health, double actionPoints, string playerImage)
		{
			Weapon sword = new Weapon("Sword", 10, Dice.D6, 5.0);
			this.Weapon = sword;
			Armor armor = new Armor("Leather", 6);
			Armor = armor;
			this.Name = name;
			this.Health = health;
			IsDead = false;
			this.ActionPoints = actionPoints;
			IsCollidable = true;
			ImageLocation = playerImage;
			BackupColorCode = "FF00FF";
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
				IsDead = true;
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

	}
}
