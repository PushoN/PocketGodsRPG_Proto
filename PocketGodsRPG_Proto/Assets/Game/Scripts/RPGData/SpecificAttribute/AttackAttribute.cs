using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the attack attribute
/// </summary>
public class AttackAttribute : ConcreteAttribute {

	public AttackAttribute(int baseValue, float multiplier): base(baseValue, multiplier) {

	}
}
