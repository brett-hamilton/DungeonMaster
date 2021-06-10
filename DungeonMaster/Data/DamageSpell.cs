/*************************************************
 * Name: DamageSpell.cs
 * Author: Hunter Page
 * Date Created: 6/9/21
 * Last Modified: 6/9/21
 *************************************************/

using System;

public class DamageSpell : Spell
{

	public double Damage { get; set; }


	public DamageSpell(string spellName, SpellTypes spellType, double damage)
	{
		this.SpellName = spellName;
		this.SpellType = spellType;
		this.Damage = damage;
	}
}
