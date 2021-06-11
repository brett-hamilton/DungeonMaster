/*****************************
 * File: Effect.cs
 * Author: Hunter Page
 * Last Modified: 6/9/21
 ***************************** */

using System;


/// <summary>
/// a modifier to a weapon that can add more damage to a weapon
/// </summary>
public class Effect
{
	/// <summary>
    /// the type of effect it is
    /// </summary>
	public EffectTypes EffectType { get; set; }

	/// <summary>
    /// name of the effect
    /// </summary>
	public string Name { get; set; }

	/// <summary>
    /// the amount of damage the effect will do
    /// </summary>
	public int Damage { get; set; }

	/// <summary>
    /// overloaded constructor of the Effect class
    /// </summary>
    /// <param name="name"></param>
    /// <param name="effectType"></param>
    /// <param name="damage"></param>
	public Effect(string name, EffectTypes effectType, int damage)
	{
        this.Name = name;
        this.EffectType = effectType;
        this.Damage = damage;
	}
}
