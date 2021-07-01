namespace DungeonMaster.Data
{
    /// <summary>
    /// Class containing methods that allow characters to perform a variety of attack-types.
    /// 
    /// Created by: Brett Hamilton
    /// Created on: 6/2/21
    /// </summary>
    public class Attack
    {
        /// <summary>
        /// Perform a melee attack against a defending character. Depends on dice rolling to calculate
        /// whether or not the attack hits or misses.
        /// 
        /// Created by: Brett Hamilton
        /// Created on: 6/2/21
        /// </summary>
        /// <param name="attacker">The character attacking.</param>
        /// <param name="defender">The character being attacked.</param>
        /// <returns>Attack Report detailing what happened in the attack.</returns>
        public AttackReport MeleeAttack(Character attacker, Character defender, bool actionPoint)
        {

            var modifierDamage = attacker.CharacterStats.GetStrengthModifier();
            DiceRollReport actionPointRoll = Die.Roll(6, 1);
            double attackValue;

            if(attacker.ActionPoints <= 0)
            {
                actionPoint = false;
            }

            if (actionPoint)
            {
                attackValue = Die.RollD20() + attacker.IsProficient() + modifierDamage + actionPointRoll.GetDiceTotal();
                attacker.LowerActionPoint();
            }
            else
            {
                // Roll the attack dice for a value to compare to defender's armor rating
                attackValue = Die.RollD20() + attacker.IsProficient() + modifierDamage;
            }

            // Determine if the attack value is enough to hit
            bool hit = defender.CheckArmor(attackValue);

            if (hit)
            {
                // Decrease defender's health by the attacker's weapon stat

                var attackReport = attacker.ActiveWeapon.GetDamage();
                int damageAmount = attackReport.TotalDamageDealt + modifierDamage;
                attackReport.Modifier = modifierDamage;
                defender.DamagePlayer(damageAmount);
                attackReport.AttackRoll = attackValue;
                attackReport.HitCheck = hit;
                attackReport.AttackerName = attacker.Name;
                attackReport.DefenderName = defender.Name;
                attackReport.ActionPointUsed = actionPoint;
                attackReport.ActionPointDiceRoll = actionPointRoll.GetDiceTotal();

                return attackReport;
            }

            return new AttackReport
            {
                AttackRoll = attackValue,
                HitCheck = hit,
                AttackerName = attacker.Name,
                DefenderName = defender.Name
            };

        }

        /// <summary>
        /// Perform a ranged attack against the defending character. If the defender is within melee range
        /// then the attack roll is with disadvantage.
        /// Created by: Jordan DeBord
        /// Last Updated: 06/12/2021
        /// </summary>
        /// <param name="attacker">Character attacking the other.</param>
        /// <param name="defender">Character defending against the attack.</param>
        /// <param name="disadvantage">If the defending character is in melee range.</param>
        /// <returns>An attack report containing information about the attack.</returns>
        public AttackReport RangedAttack(Character attacker, Character defender, bool disadvantage, bool actionPoint)
        {
            DiceRollReport disadvatageRollReport = null;
            double attackValue;
            var modifierDamage = attacker.CharacterStats.GetDexterityModifier();
            DiceRollReport actionPointNumber = Die.Roll(6, 1);

            if (attacker.ActionPoints <= 0)
            {
                actionPoint = false;
            }

            if (disadvantage)
            {
                if (actionPoint)
                {
                    disadvatageRollReport = Die.RollD20Disadvantage();
                    attackValue = disadvatageRollReport.GetDiceTotal() + attacker.IsProficient() + modifierDamage + actionPointNumber.GetDiceTotal();
                    attacker.LowerActionPoint();
                }
                else
                {
                    disadvatageRollReport = Die.RollD20Disadvantage();
                    attackValue = disadvatageRollReport.GetDiceTotal() + attacker.IsProficient() + modifierDamage;
                }

            }
            else
            {
                if(actionPoint)
                {
                    attackValue = Die.RollD20() + attacker.IsProficient() + modifierDamage + actionPointNumber.GetDiceTotal();
                    attacker.LowerActionPoint();
                }
                else
                {
                    attackValue = Die.RollD20() + attacker.IsProficient() + modifierDamage;
                }
            }

            bool hit = defender.CheckArmor(attackValue);

            if (hit)
            {
                var attackReport = attacker.ActiveWeapon.GetDamage();
                defender.DamagePlayer(attackReport.TotalDamageDealt + modifierDamage);
                attackReport.TotalDamageDealt += modifierDamage;
                attackReport.Modifier = modifierDamage;
                attackReport.AttackRoll = attackValue;
                attackReport.HitCheck = hit;
                attackReport.AttackerName = attacker.Name;
                attackReport.DefenderName = defender.Name;
                attackReport.DisadvantageRoll = disadvatageRollReport;
                attackReport.ActionPointUsed = actionPoint;
                attackReport.ActionPointDiceRoll = actionPointNumber.GetDiceTotal();

                return attackReport;
            }

            return new AttackReport
            {
                AttackRoll = attackValue,
                HitCheck = hit,
                AttackerName = attacker.Name,
                DefenderName = defender.Name,
                DisadvantageRoll = disadvatageRollReport
            };
        }

        /// <summary>
        /// Method to attack to attack another character with a spell.
        /// </summary>
        /// <param name="caster">Character attacking.</param>
        /// <param name="receiver">Character defending.</param>
        /// <returns>A report describing the outcome of the attempt.</returns>
        public AttackReport SpellAttack(Character caster, Character receiver)
        {
            AttackReport attackReport = caster.ActiveSpell.GetSpellDamage();
            var modifierDamage = caster.CharacterStats.GetIntelligenceModifier();

            double totalDamage = attackReport.DiceRollReport.GetDiceTotal() + modifierDamage;
            

            receiver.DamagePlayer(totalDamage);

            attackReport.AttackerName = caster.Name;
            attackReport.DefenderName = receiver.Name;
            attackReport.SpellName = caster.ActiveSpell.SpellName;
            attackReport.SpellType = caster.ActiveSpell.SpellType;
            attackReport.Modifier = modifierDamage;
            attackReport.TotalDamageDealt = (int)totalDamage;

            return attackReport;
        }
    }
}
