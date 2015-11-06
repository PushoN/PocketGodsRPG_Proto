using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharTestComponent : MonoBehaviour {

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

	[SerializeField] private string testLabel = "Test 1";
	[SerializeField] private HealthDefaultValue healthDefaultValue;
	[SerializeField] private AttackDefaultValue attackDefaultValue;
	[SerializeField] private DefenseDefaultValue defenseDefaultValue;
	[SerializeField] private SpeedDefaultValue speedDefaultValue;

	[SerializeField] private TestRawBonus[] testRawBonuses;
	[SerializeField] private TestPercentBonus[] testPercentBonuses;


	private CharacterData character;
	private Dictionary<TestRawBonus.TargetAttribute, ConcreteAttribute> attributeTable = new Dictionary<TestRawBonus.TargetAttribute, ConcreteAttribute>();

	// Use this for initialization
	void Start () {
		this.character = new CharacterData(new AttackAttribute(this.attackDefaultValue.value, this.attackDefaultValue.multiplier), 
		                                       new DefenseAttribute(this.defenseDefaultValue.value, this.defenseDefaultValue.multiplier), 
		                                       new SpeedAttribute(this.speedDefaultValue.value, this.speedDefaultValue.multiplier), 
		                                       new HealthAttribute(this.healthDefaultValue.value, this.healthDefaultValue.multiplier));
	
		this.attributeTable.Add(TestRawBonus.TargetAttribute.HEALTH, this.character.GetHealthAttribute());
		this.attributeTable.Add(TestRawBonus.TargetAttribute.SPEED, this.character.GetSpeedAttribute());
		this.attributeTable.Add(TestRawBonus.TargetAttribute.ATTACK, this.character.GetAttackAttribute());
		this.attributeTable.Add(TestRawBonus.TargetAttribute.DEFENSE, this.character.GetDefenseAttribute());

		this.CheckEquipment();
		this.PrintCharacterStats();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CheckEquipment() {
		this.testRawBonuses = this.GetComponentsInChildren<TestRawBonus>();
		this.testPercentBonuses = this.GetComponentsInChildren<TestPercentBonus>();

		foreach(TestRawBonus testRawBonus in this.testRawBonuses) {
			AttributeBonus attributeBonus = testRawBonus.GetAttributeBonus();

			this.attributeTable[testRawBonus.GetTargetAttribute()].AddAttributeBonus(attributeBonus);
		}

		foreach(TestPercentBonus testPercentBonus in this.testPercentBonuses) {
			AttributeBonusPercent attributeBonusPercent = testPercentBonus.GetAttributeBonusPercent();
			this.attributeTable[testPercentBonus.GetTargetAttribute()].AddBonusPercent(attributeBonusPercent);
		}
	}

	private void PrintCharacterStats() {
		Debug.Log ("------"+this.testLabel+ "------");
		Debug.Log (@"Health: " +this.character.GetHealthAttribute().GetModifiedValue() +
		           @" Attack: " +this.character.GetAttackAttribute().GetModifiedValue() + 
		           " Defense: " +this.character.GetDefenseAttribute().GetModifiedValue() +
		           " Speed: " +this.character.GetSpeedAttribute().GetModifiedValue());
		Debug.Log ("------END OF STATS------");
	}
}
