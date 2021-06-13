using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Report used to transmit information to View about attack, for the log.
    /// </summary>
    public class AttackReport
    {
        /// <summary>
        /// Report about the result of the dice rolled.
        /// </summary>
        public DiceRollReport DiceRollReport { get; set; }

        /// <summary>
        /// Die result from rolling the attack.
        /// </summary>
        public double AttackRoll { get; set; }

        /// <summary>
        /// Base damage of the attacking weapon.
        /// </summary>
        public int WeaponBaseDamage { get; set; }

        /// <summary>
        /// Base damage and die damage roll total to be deducted from the other player.
        /// </summary>
        public int TotalDamageDealt { get; set; }

        /// <summary>
        /// If the attack was successful or not.
        /// </summary>
        public bool HitCheck { get; set; }

        /// <summary>
        /// Name of the attacking character.
        /// </summary>
        public string AttackerName { get; set; }

        /// <summary>
        /// Name of the defending character.
        /// </summary>
        public string DefenderName { get; set; }

        /// <summary>
        /// Die being rolled for damage.
        /// </summary>
        public Dice DieUsed { get; set; }

        /// <summary>
        /// Returns a string containing information about the attack attempt. This is then displayed
        /// in the game log for the players.
        /// </summary>
        /// <returns></returns>
        public string GetAttackReport()
        {
            if (!HitCheck)
            {
                return $"{AttackerName} rolled an attack of {AttackRoll}. This attack missed {DefenderName}.";
            }
            else 
            {
                string attackReport = $"{AttackerName} rolled an attack of {AttackRoll}. This attack hit {DefenderName}.";
                attackReport += $"\nTheir damage roll was 1 {DieUsed} {DiceRollReport.GetDiceReport()}. They dealt {WeaponBaseDamage} base damage + {DiceRollReport.GetDiceTotal()} attack roll damage = {TotalDamageDealt} total damage.";
                return attackReport;
            }
        }
    }
}
