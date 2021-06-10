/*************************************************
 * Name: Spell.cs
 * Author: Hunter Page
 * Date Created: 6/9/21
 * Last Modified: 6/9/21
 *************************************************/

using System;

public class Spell
{

	public string SpellName { get; set; }

	public SpellTypes SpellType { get; set; }

	public Spell(string spellName, SpellTypes spellType)
	{
		this.SpellName = spellName;
		this.SpellType = spellType;
	}
}
