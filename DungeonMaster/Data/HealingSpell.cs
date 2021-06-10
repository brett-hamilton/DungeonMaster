/*************************************************
 * Name: DamageSpell.cs
 * Author: Hunter Page
 * Date Created: 6/2/21
 * Last Modified: 6/2/21
 *************************************************/

using System;

public class HealingSpell : Spell
{
	public double HealingFactor { get; set; }

	public HealingSpell(string spellName, SpellTypes spellType, double healingFactor)
	{
		this.SpellName = spellName;
		this.SpellType = spellType;
		this.HealingFactor = HealingFactor;
	}
}
