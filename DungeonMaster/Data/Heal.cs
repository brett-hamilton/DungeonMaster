using System;


namespace DungeonMaster.Data
{
    /// <summary>
    /// Collections of methods that involve healing
    /// </summary>
    public class Heal
    {
        /// <summary>
        /// Allows a character to heal themself based off of their spell roll and intelligence
        /// </summary>
        /// <param name="caster">Person healing themself</param>
        public void HealSelf(Character caster)
        {
            caster.Health += caster.GetHealingSpellPower() + caster.CharacterStats.Intelligence;
        }

        /// <summary>
        /// Allows a caster to heal another Character
        /// </summary>
        /// <param name="caster">Person performing the spell</param>
        /// <param name="receiver">Character receiving the Spell</param>
        public void HealCharacter(Character caster, Character receiver)
        {
            receiver.Health += caster.GetHealingSpellPower() + caster.CharacterStats.Intelligence;
        }
    }
}

