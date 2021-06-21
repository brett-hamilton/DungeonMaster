using System;


namespace DungeonMaster.Data
{
    /// <summary>
    /// Collections of methods that involve healing
    /// </summary>
    public class Heal
    {
        public void HealSelf(Character player)
        {
            player.Health += player.GetHealingSpellPower();
        }

        public AttackReport HealPlayer(Character caster, Character injuredPlayer)
        {
            injuredPlayer.Health += caster.GetHealingSpellPower();
        }
    }
}

