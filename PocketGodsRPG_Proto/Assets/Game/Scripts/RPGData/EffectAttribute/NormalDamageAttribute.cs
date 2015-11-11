using UnityEngine;
using System.Collections;

public class NormalDamageAttribute : ConcreteAttribute {

	/// <summary>
	/// A normal damage attribute. Automatically negates the value.
	/// </summary>
	/// <param name="baseValue">Base value.</param>
	/// <param name="multiplier">Multiplier.</param>
	public NormalDamageAttribute(int baseValue, float multiplier): base(-baseValue, multiplier) {
		
	}
}
