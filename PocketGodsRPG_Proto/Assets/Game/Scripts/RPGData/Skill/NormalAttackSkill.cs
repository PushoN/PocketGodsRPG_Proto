using UnityEngine;
using System.Collections;

/// <summary>
/// A normal attack skill representation
/// </summary>
public class NormalAttackSkill : ISkill {

	public void Activate() {

	}

	public void Deactivate() {

	}

	public void Perform(ControllableUnit controllableUnit) {
		Debug.Log ("Normal attack skill to " +controllableUnit);
	}

	public void Finish() {
		Debug.Log ("Finished execution of skill");
	}

	public string GetSkillName() {
		return "NormalAttack";
	}
}
