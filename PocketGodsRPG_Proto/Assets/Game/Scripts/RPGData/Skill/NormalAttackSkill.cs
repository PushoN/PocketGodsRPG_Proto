using UnityEngine;
using System.Collections;

/// <summary>
/// A normal attack skill representation
/// </summary>
public class NormalAttackSkill : ISkill {

	public void Perform(ControllableUnit controllableUnit) {
		Debug.Log ("Normal attack skill to " +controllableUnit);
	}
}
