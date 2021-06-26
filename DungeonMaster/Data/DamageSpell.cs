/*************************************************
 * Name: DamageSpell.cs
 * Author: Hunter Page
 * Date Created: 6/9/21
 * Last Modified: 6/9/21
 *************************************************/

namespace DungeonMaster.Data
{
    /// <summary>
    /// Represents a spell that can inflict damage.
    /// </summary>
    public class DamageSpell : Spell
    {
        /// <summary>
        /// Amount of damage the spell can inflict.
        /// </summary>
        public double Damage { get; set; }

        /// <summary>
        /// Parameterized constructor for creating a damage spell.
        /// </summary>
        /// <param name="spellName">The name of the spell.</param>
        /// <param name="spellType">Type of spell.</param>
        /// <param name="damage">Amount of damage spell can inflict.</param>
        /// <param name="diceUsed">Dice used for this spell.</param>
        /// <param name="numberOfRolls">How many rolls spell takes.</param>
        /// <param name="range">Range of the spell.</param>
        public DamageSpell(string spellName, SpellTypes spellType, double damage, Dice diceUsed, int numberOfRolls, int range) : base(spellName, spellType, diceUsed, numberOfRolls, range)
        {
            this.Damage = damage;
        }
    }
}
