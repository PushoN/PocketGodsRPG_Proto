using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Represents an HP bar that will be referenced to a controllable unit
/// 
/// By: Neil DG
/// </summary>
public class HPBarElement : MonoBehaviour {

	[SerializeField] private ControllableUnit assignedUnit;
	[SerializeField] private Slider uiSlider;

	// Use this for initialization
	void Start () {
	
	}

	public void AssignControllableUnit(ControllableUnit unit) {
		this.assignedUnit = unit;
	}

}
