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
            caster.Health += caster.GetHealingSpellPower().GetDiceTotal() + caster.CharacterStats.Intelligence;
        }

        /// <summary>
        /// Allows a caster to heal another Character
        /// </summary>
        /// <param name="caster">Person performing the spell</param>
        /// <param name="receiver">Character receiving the Spell</param>
        public AttackReport HealCharacter(Character caster, Character receiver)
        {
            DiceRollReport roll = caster.GetHealingSpellPower();
            double totalHealth = roll.GetDiceTotal() + caster.CharacterStats.Intelligence;
            receiver.HealPlayer(totalHealth); 

            AttackReport healingReport = new AttackReport();

            healingReport.AttackerName = caster.Name;
            healingReport.DefenderName = receiver.Name;
            healingReport.CharacterIntelligence = caster.CharacterStats.Intelligence;
            healingReport.DieUsed = caster.ActiveSpell.DiceUsed;
            healingReport.TotalDamageDealt = (int)totalHealth;
            healingReport.DiceRollReport = roll;

            return healingReport;
        }
    }
}

