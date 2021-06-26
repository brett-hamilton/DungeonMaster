/*************************************************
 * Name: DamageSpell.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/

namespace DungeonMaster.Data
{
    /// <summary>
    /// Represents a spell that has the ability to heal.
    /// </summary>
    public class HealingSpell : Spell
    {
        /// <summary>
        /// The amount this spell can heal.
        /// </summary>
        public double HealingFactor { get; set; }

        /// <summary>
        /// Parameterized constructor that creates a Healing Spell.
        /// </summary>
        /// <param name="spellName">Name of the Healing Spell.</param>
        /// <param name="spellType">Type of spell.</param>
        /// <param name="healingFactor">Amount of healing the spell can heal.</param>
        /// <param name="diceUsed">Dice used for this spell.</param>
        /// <param name="numberOfRolls">Number of rolls needed for this spell.</param>
        /// <param name="range">Range of this spell.</param>
        public HealingSpell(string spellName, SpellTypes spellType, double healingFactor, Dice diceUsed, int numberOfRolls, int range) : base(spellName, spellType, diceUsed, numberOfRolls, range)
        {
            this.HealingFactor = healingFactor;
        }
    }
}