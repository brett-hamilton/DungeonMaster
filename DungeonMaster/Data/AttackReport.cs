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
        public DiceRollReport DiceRollReport { get; set; }

        public double AttackRoll { get; set; }

        public double ArmorValue { get; set; }

        public int WeaponBaseDamage { get; set; }

        public int TotalDamageDealt { get; set; }

        public bool HitCheck { get; set; }

        public string AttackerName { get; set; }

        public string DefenderName { get; set; }

        public Dice DieUsed { get; set; }


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
