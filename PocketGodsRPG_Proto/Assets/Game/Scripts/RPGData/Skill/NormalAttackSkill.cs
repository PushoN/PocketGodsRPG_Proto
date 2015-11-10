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
		AttributeBonus damageOutcome = new AttributeBonus(-2,1);

		HealthAttribute healthAttribute = controllableUnit.GetCharacterData().GetHealthAttribute();
		healthAttribute.AddAttributeBonus(damageOutcome);

		Debug.Log ("Normal attack skill to " +controllableUnit+ ". Unit new HP is: " +controllableUnit.GetCharacterData().GetHealthAttribute().GetModifiedValue());
	}

	public void Finish() {
		Debug.Log ("Finished execution of skill");
	}

	public string GetSkillName() {
		return SkillNamesHolder.NORMAL_ATTACK_SKILL;
	}
}
