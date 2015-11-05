using UnityEngine;
using System.Collections;

/// <summary>
/// Represents an attribute bonus that has a direct effect on the attribute base. Assigned to items.
/// 
/// By: NeilDG
/// </summary>
public class AttributeBonus: AttributeBase  {
	public AttributeBonus(int value, float multiplier):base(value, multiplier){

	}
}
