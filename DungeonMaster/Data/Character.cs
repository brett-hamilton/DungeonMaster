﻿/*************************************************
 * Name: Character.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageHunter_SE1_Project.Data
{
	public class Character
	{
		/// <summary>
		/// Name of the character
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// melee weapon they have equipped
		/// </summary>
		public Weapon MeleeWeapon { get; set; } 

		/// <summary>
		/// The amount of Health points they have
		/// </summary>
		public double Health { get; set; }

		/// <summary>
		/// They armor object they are wearing
		/// </summary>
		public Armor Armor { get; set; } 

		/// <summary>
		/// determines if the player is dead or not for future actions
		/// </summary>
		public bool IsDead { get; set; } 

		/// <summary>
		/// The number of points they have to perform an attack or action
		/// </summary>
		public double ActionPoints { get; set; }

		public Character()
        {
			Weapon sword = new Weapon("sword", 10, Dice.D6, 5.0);
			this.Name = "Geralt";
			this.Health = 100;
			this.MeleeWeapon = sword;
			this.ActionPoints = 120;
        }

		/// <summary>
		/// Constructor for the Character to be initialized
		/// </summary>
		/// <param name="name"></param>
		/// <param name="health"></param>
		public Character(string name, double health, double actionPoints)
		{
			this.Name = name;
			this.Health = health;
			IsDead = false;
			this.ActionPoints = ActionPoints;
		}

		/// <summary>
		/// take health from the player
		/// </summary>
		/// <param name="damage"></param>
		public void damagePlayer(double damage)
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
