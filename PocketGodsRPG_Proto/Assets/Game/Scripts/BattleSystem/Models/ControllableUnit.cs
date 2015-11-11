using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Represents the controllable unit
/// </summary>
public class ControllableUnit : MonoBehaviour {

	[Serializable]
	private struct HealthDefaultValue {
		public int value;
		public int multiplier;
	}
	[Serializable]
	
	private struct AttackDefaultValue {
		public int value;
		public int multiplier;
	}
	
	[Serializable]
	private struct DefenseDefaultValue {
		public int value;
		public int multiplier;
	}
	
	[Serializable]
	private struct SpeedDefaultValue {
		public int value;
		public int multiplier;
	}
	
	[SerializeField] private string unitName = "Default";
	[SerializeField] private HealthDefaultValue healthDefaultValue;
	[SerializeField] private AttackDefaultValue attackDefaultValue;
	[SerializeField] private DefenseDefaultValue defenseDefaultValue;
	[SerializeField] private SpeedDefaultValue speedDefaultValue;
	
	private CharacterData characterData;
	private UnitIdentity unitID;
	
	void Start() {
		this.characterData = new CharacterData(new AttackAttribute(this.attackDefaultValue.value, this.attackDefaultValue.multiplier), 
		                                   new DefenseAttribute(this.defenseDefaultValue.value, this.defenseDefaultValue.multiplier), 
		                                   new SpeedAttribute(this.speedDefaultValue.value, this.speedDefaultValue.multiplier), 
		                                   new HealthAttribute(this.healthDefaultValue.value, this.healthDefaultValue.multiplier));

		this.unitID = new UnitIdentity(this.unitName);
		this.PrintCharacterStats();

		EventBroadcaster.Instance.PostEvent(EventNames.ON_UNIT_INITIALIZE_SUCCESS);
	}

	public void PrintCharacterStats() {
		Debug.Log ("------"+this.unitName+ "------");
		Debug.Log (@"Health: " +this.characterData.GetHealthAttribute().GetModifiedValue() +
		           @" Attack: " +this.characterData.GetAttackAttribute().GetModifiedValue() + 
		           " Defense: " +this.characterData.GetDefenseAttribute().GetModifiedValue() +
		           " Speed: " +this.characterData.GetSpeedAttribute().GetModifiedValue());
		Debug.Log ("------END OF STATS------");
	}

	public CharacterData GetCharacterData() {
		return this.characterData;
	}

	public string GetUnitName() {
		return this.unitName;
	}

	public UnitIdentity GetUnitIdentity() {
		return this.unitID;
	}

}
