using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Represents an HP bar that will be referenced to a controllable unit
/// 
/// By: Neil DG
/// </summary>
public class HPBarElement : MonoBehaviour {

	public const string UNIT_REFERENCE_KEY = "UNIT_REFERENCE_KEY";

	[SerializeField] private ControllableUnit assignedUnit;
	[SerializeField] private Slider uiSlider;

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver(EventNames.ON_UNIT_CHANGED_HP, this.OnUnitChangedHP);
	}

	void Destroy() {
		EventBroadcaster.Instance.RemoveObserver(EventNames.ON_UNIT_CHANGED_HP);
	}

	public void AssignControllableUnit(ControllableUnit unit) {
		this.assignedUnit = unit;
	}

	private void OnUnitChangedHP(Parameters parameters) {
		ControllableUnit unitRef = (ControllableUnit) parameters.GetObjectExtra(UNIT_REFERENCE_KEY);

		//update HP if event thrown came from the ref unit
		if(this.assignedUnit == unitRef) {
			HealthAttribute healthAttribute = this.assignedUnit.GetCharacterData().GetHealthAttribute();
			float normalizedHP = healthAttribute.GetModifiedValue() * 1.0f / healthAttribute.GetMaxValue() * 1.0f;

			this.uiSlider.value = normalizedHP;
		}
	}
}
