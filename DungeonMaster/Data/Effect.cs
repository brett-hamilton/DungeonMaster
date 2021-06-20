/*****************************
 * File: Effect.cs
 * Author: Hunter Page
 * Last Modified: 6/9/21
 ***************************** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// A modifier to a weapon that can add more damage to a weapon
    /// </summary>
    public class Effect
    {
        /// <summary>
        /// The type of effect it is
        /// </summary>
        public EffectTypes EffectType { get; set; }

        /// <summary>
        /// Name of the effect
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of damage the effect will do
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Overloaded constructor of the Effect class
        /// </summary>
        /// <param name="name">Name of the effect.</param>
        /// <param name="effectType">Type of effect.</param>
        /// <param name="damage">Amount of damage effect can inflict.</param>
        public Effect(string name, EffectTypes effectType, int damage)
        {
            this.Name = name;
            this.EffectType = effectType;
            this.Damage = damage;
        }
    }
}

