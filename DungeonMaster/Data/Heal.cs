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
            caster.Health += caster.ActiveSpell.GetHealingSpellPower().GetDiceTotal() + caster.CharacterStats.GetIntelligenceModifier();
        }

        /// <summary>
        /// Allows a caster to heal another Character
        /// </summary>
        /// <param name="caster">Person performing the spell</param>
        /// <param name="receiver">Character receiving the Spell</param>
        public AttackReport HealCharacter(Character caster, Character receiver)
        {
            DiceRollReport roll = caster.ActiveSpell.GetHealingSpellPower();
            var modifierAmount = caster.CharacterStats.GetIntelligenceModifier();

            double totalHealth = roll.GetDiceTotal() + modifierAmount;
            receiver.HealPlayer(totalHealth); 

            AttackReport healingReport = new AttackReport();

            healingReport.AttackerName = caster.Name;
            healingReport.DefenderName = receiver.Name;
            healingReport.Modifier = modifierAmount;
            healingReport.DieUsed = caster.ActiveSpell.DiceUsed;
            healingReport.TotalDamageDealt = (int)totalHealth;
            healingReport.DiceRollReport = roll;

            return healingReport;
        }
    }
}

