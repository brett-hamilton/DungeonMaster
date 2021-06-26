/*************************************************
 * Name: Weapon.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/


using System;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Represents a weapon that a character can use
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// Name of the weapon
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of damage with no dice rolls
        /// </summary>
        //public int BaseDamage {get; set;}

        /// <summary>
        /// What dice the weapon uses, default is set to D4.
        /// </summary>
        public Dice DiceUsed { get; set; } = Dice.D4;

        /// <summary>
        /// How far the weapon can reach
        /// </summary>
        public double Range { get; set; }

        ///	<summary>
        /// Determines whether the weapon is used for range
        ///	</summary>
        public bool RangedWeapon { get; set; } = false;

        /// <summary>
        /// What type of weapon it is.
        /// </summary>
        public WeaponType WeaponType { get; set; }

        ///	<summary>
        /// The type of damage the weapon uses.
        ///	</summary>
        public Effect DamageType { get; set; } = new Effect("piercing", EffectTypes.Piercing, 0);

        /// <summary>
        /// Default constructor that takes no parameters
        /// 
        /// Created by: Brett Hamilton
        /// Created on: 6/11/2021
        /// </summary>
        public Weapon()
        {
            this.Name = "sword";
            //this.BaseDamage = 10;
            this.DiceUsed = Dice.D6;
            this.Range = 5.0;
        }

        /// <summary>
        /// Loaded constructor for making a new weapon
        /// </summary>
        /// Author: Hunter Page
        /// <param name="name">Name of the weapon.</param>
        /// <param name="baseDamage">Damage of the weapon.</param>
        /// <param name="dice">Dice it uses.</param>
        /// <param name="range">What effective range the weapon has.</param>
        public Weapon(string name, Dice dice, double range, WeaponType weaponType)
        {
            this.Name = name;
            //this.BaseDamage = baseDamage;
            this.DiceUsed = dice;
            this.Range = range;
        }

        /// <summary>
        /// Loaded constructor for making a new weapon
        /// </summary>
        /// Author: Hunter Page
        /// <param name="name">Name of the weapon.</param>
        /// <param name="baseDamage">Damage of the weapon.</param>
        /// <param name="dice">Dice it uses.</param>
        /// <param name="range">What effective range the weapon has.</param>
        /// <param name="damageTypes">What type of damage the weapon does.</param>
        public Weapon(string name, Dice dice, double range, Effect damageTypes, bool rangedWeapon, WeaponType weaponType)
        {
            this.Name = name;
            //this.BaseDamage = baseDamage;
            this.DiceUsed = dice;
            this.Range = range;
            this.DamageType = damageTypes;
            this.RangedWeapon = rangedWeapon;

        }

        /// <summary>
        /// Method to get the total damage done by this weapon.
        /// Author: Jordan DeBord
        /// </summary>
        /// <returns>An int representing the total damage done.</returns>
        public AttackReport GetDamage()
        {
            var dieToUse = DiceUsed.ToString();

            // Try to parse out how many sides the Die is, then Roll it.
            if (int.TryParse(dieToUse[1..], out int dieSides))
            {
                DiceRollReport dieRollReport = null;
                int dieRoll;

                // If the die had a non-allowed number of sides, return 0 for the result.
                try
                {
                    dieRollReport = Die.Roll(dieSides, 1);
                    dieRoll = dieRollReport.GetDiceTotal();
                }
                catch (Exception)
                {
                    dieRoll = 0;
                }

                // Set the weapon type. Default to piercing damage if none listed.
                string damageType;

                if (DamageType == null)
                {
                    damageType = "piercing";
                }
                else
                {
                    damageType = DamageType.EffectType.ToString();
                }

                // If we were successful in getting damage, create a new attack report.
                if (dieRollReport != null)
                {
                    return new AttackReport
                    {
                        DiceRollReport = dieRollReport,
                        TotalDamageDealt = dieRoll,
                        DieUsed = DiceUsed,
                        DamageType = damageType
                    };
                }
            }
            // If we could not parse the Die, or the Die was invalid, return just base damage.
            return new AttackReport
            {
                TotalDamageDealt = 0,
                DieUsed = DiceUsed
            };
        }

        /// <summary>
        /// Provides string representation of a Weapon.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
