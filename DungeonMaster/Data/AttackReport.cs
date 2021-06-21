using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Data
{
    /// <summary>
    /// Report used to transmit information to View about attack, for the log.
    /// Created by: Jordan DeBord
    /// Last Updated: 06/12/2021
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
        /// Report of attack roll if rolling with disadvantage.
        /// </summary>
        public DiceRollReport DisadvantageRoll { get; set; }


        /* NEW ADDITIONS FOR HEALTH REPORT*/

        /// <summary>
        /// How much health was administered
        /// </summary>
        public int TotalHealthDealt { get; set; }

        /// <summary>
        /// number of times the die used was rolled
        /// </summary>
        public int NumberOfRolls { get; set; }

        /// <summary>
        /// the intelligence of the caster
        /// </summary>
        public int CasterIntelligence { get; set; }

        /// <summary>
        /// Type of damage being applied.
        /// </summary>
        public string DamageType { get; set; }

        /// <summary>
        /// Returns a string containing information about the attack attempt. This is then displayed
        /// in the game log for the players.
        /// </summary>
        /// <returns></returns>
        public string GetAttackReport()
        {
            if (!HitCheck)
            {
                if (DisadvantageRoll != null) 
                {
                    return $"{AttackerName} attacked {DefenderName} from within melee distance. {AttackerName} {DisadvantageRoll.GetDiceReport()} This attack missed {DefenderName}.";
                }

                return $"{AttackerName} rolled an attack of {AttackRoll}. This attack missed {DefenderName}.";
            }

            if (DisadvantageRoll != null) 
            {
                string attackReport = $"{AttackerName} attacked {DefenderName} from within melee distance. {AttackerName} {DisadvantageRoll.GetDiceReport()} This attack hit {DefenderName}.";
                attackReport += $"\nTheir damage roll was 1 {DieUsed} {DiceRollReport.GetDiceReport()}. They dealt {WeaponBaseDamage} base damage + {DiceRollReport.GetDiceTotal()} attack roll damage = {TotalDamageDealt} total {DamageType} damage.";
                return attackReport;
            }
            else
            {
                string attackReport = $"{AttackerName} rolled an attack of {AttackRoll}. This attack hit {DefenderName}.";
                attackReport += $"\nTheir damage roll was 1 {DieUsed} {DiceRollReport.GetDiceReport()}. They dealt {WeaponBaseDamage} base damage + {DiceRollReport.GetDiceTotal()} attack roll damage = {TotalDamageDealt} total {DamageType} damage.";
                return attackReport;
            }
        }


        /// <summary>
        /// returns a string with info on healing spell use
        /// </summary>
        /// <returns>detailed report on the move</returns>
        public string GetHealingReport()
        {
            string attackReport = $"{AttackerName} rolled a heal spell of {AttackRoll}. This spell hit {DefenderName}.";

            attackReport += $"\nTheir spell roll was {DieUsed} {DiceRollReport.GetDiceReport()}. It dealt {DiceRollReport.GetDiceTotal()} roll health + {CasterIntelligence} intelligence = {TotalHealthDealt} total health.";
            return attackReport;
        }
    }
}
