using UnityEngine;
using System.Collections;
using DG.Tweening;

/// <summary>
/// A normal attack skill representation
/// </summary>
public class NormalAttackSkill : ISkill {

	private System.Action onFinishAction = null;
	private ControllableUnit targetUnit;

	public void Activate() {

	}

	public void Deactivate() {

	}

	public void Perform(ControllableUnit sourceUnit, ControllableUnit targetUnit) {

		this.targetUnit = targetUnit;

		AttributeBonus damageOutcome = new AttributeBonus(-2,1);
		
		HealthAttribute healthAttribute = targetUnit.GetCharacterData().GetHealthAttribute();
		healthAttribute.AddAttributeBonus(damageOutcome);
		
		Debug.Log ("Normal attack skill to " +targetUnit+ ". Unit new HP is: " +targetUnit.GetCharacterData().GetHealthAttribute().GetModifiedValue());


		this.PerformAnimation(sourceUnit, targetUnit);

	}

	public void Finish() {
		Parameters parameters = new Parameters();
		parameters.PutObjectExtra(HPBarElement.UNIT_REFERENCE_KEY, this.targetUnit);

		EventBroadcaster.Instance.PostEvent(EventNames.ON_UNIT_CHANGED_HP,parameters);
		Debug.Log ("Finished execution of skill");

		if(this.onFinishAction != null) {
			this.onFinishAction();
		}
	}

	public void AddOnFinishAction(System.Action action) {
		this.onFinishAction = action;
	}

	public string GetSkillName() {
		return SkillNamesHolder.NORMAL_ATTACK_SKILL;
	}



	/// <summary>
	/// Perform animation for the controllable units here
	/// </summary>
	private void PerformAnimation(ControllableUnit sourceUnit, ControllableUnit targetUnit) {
		//sourceUnit.transform.DOMove(targetUnit.transform,1.0f).SetEase(Ease.
		Vector3 originalSourcePos = sourceUnit.transform.localPosition;
		Vector3 targetPos = targetUnit.transform.localPosition;

		Sequence tweenSequence = DOTween.Sequence();
		tweenSequence.Append(sourceUnit.transform.DOMove(targetPos, 1.0f).SetEase(Ease.OutExpo));
		tweenSequence.Append(sourceUnit.transform.DOMove(originalSourcePos, 1.0f).SetEase(Ease.OutExpo));
		tweenSequence.OnComplete(this.Finish);

		tweenSequence.Play();

	}
	

}
