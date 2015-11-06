using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the defense attribute
/// </summary>
public class DefenseAttribute : ConcreteAttribute {

	public DefenseAttribute(int baseValue, float multiplier): base(baseValue, multiplier) {
		
	}
}
