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
        /// Modifier to be added to damage or heals.
        /// </summary>
        public int Modifier { get; set; }

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

        /// <summary>
        /// Type of damage being applied.
        /// </summary>
        public string DamageType { get; set; }

        /// <summary>
        /// Name of the Spell used
        /// </summary>
        public string SpellName { get; set; }

        /// <summary>
        /// THe type of Spell
        /// </summary>
        public SpellTypes SpellType { get; set; }

        /// <summary>
        /// if the user used an action point to enhance their attack roll, it will be true
        /// </summary>
        public bool ActionPointUsed { get; set; }

        /// <summary>
        /// The number the die rolled for the action point
        /// </summary>
        public int ActionPointDiceRoll { get; set; }

        /// <summary>
        /// Returns a string containing information about the attack attempt. This is then displayed
        /// in the game log for the players.
        /// </summary>
        /// <returns> String containing representation of the report.</returns>
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
                if(ActionPointUsed)
                {
                    string attackReport = $"{AttackerName} attacked {DefenderName} from within melee distance. {AttackerName} used an Action Point for a 1 D6 roll on their attack roll. " +
                        $"Their attack roll was {DisadvantageRoll.GetDiceReport()} + {ActionPointDiceRoll} Action Point roll. This attack hit {DefenderName}.";
                    attackReport += $"\nTheir damage roll was 1 {DieUsed} {DiceRollReport.GetDiceReport()}. They dealt {Modifier} modifier damage + {DiceRollReport.GetDiceTotal()} attack roll damage = {TotalDamageDealt} total {DamageType.ToLower()} damage.";
                    return attackReport;
                }
                else
                {
                    string attackReport = $"{AttackerName} attacked {DefenderName} from within melee distance. {AttackerName} {DisadvantageRoll.GetDiceReport()} This attack hit {DefenderName}.";
                    attackReport += $"\nTheir damage roll was 1 {DieUsed} {DiceRollReport.GetDiceReport()}. They dealt {Modifier} modifier damage + {DiceRollReport.GetDiceTotal()} attack roll damage = {TotalDamageDealt} total {DamageType.ToLower()} damage.";
                    return attackReport;
                }
                
            }
            else
            {
                if(ActionPointUsed)
                {
                    string attackReport = $"{AttackerName} used an Action Point for a 1 D6 roll on their attack roll. {AttackerName} rolled an attack of {AttackRoll} + {ActionPointDiceRoll}. This attack hit {DefenderName}.";
                    attackReport += $"\nTheir damage roll was 1 {DieUsed} {DiceRollReport.GetDiceReport()}. They dealt {Modifier} modifier damage + {DiceRollReport.GetDiceTotal()} attack roll damage = {TotalDamageDealt} total {DamageType.ToLower()} damage.";
                    return attackReport;
                }
                else
                {
                    string attackReport = $"{AttackerName} rolled an attack of {AttackRoll}. This attack hit {DefenderName}.";
                    attackReport += $"\nTheir damage roll was 1 {DieUsed} {DiceRollReport.GetDiceReport()}. They dealt {Modifier} modifier damage + {DiceRollReport.GetDiceTotal()} attack roll damage = {TotalDamageDealt} total {DamageType.ToLower()} damage.";
                    return attackReport;
                }
                
            }
        }

        /// <summary>
        /// Method to build a report about the healing attempt, and return it.
        /// </summary>
        /// <returns> A string containing information about the heal attempt. </returns>
        public string GetHealingReport()
        {
            return $"{AttackerName} rolled a healing spell for {Modifier} modifier health bonus + {DiceRollReport.GetDiceTotal()} rolled health = {TotalDamageDealt} total health added. This healed {DefenderName}." +
                $"They rolled {DieUsed} {DiceRollReport.GetDiceReport()}.";
        }

        /// <summary>
        /// Method to build a report about the spell attack attempt
        /// </summary>
        /// <returns></returns>
        public string GetSpellAttackReport()
        {
            return $"{AttackerName} rolled the attack spell {SpellName}. The attack was {Modifier} intelligence bonus + {DiceRollReport.GetDiceTotal()} roll damage = {TotalDamageDealt}." +
                $"This damaged {DefenderName}. The roll was {DieUsed}, with {DiceRollReport.GetDiceReport()} {SpellType.ToString().ToLower()} damage.";

        }
    }
}
