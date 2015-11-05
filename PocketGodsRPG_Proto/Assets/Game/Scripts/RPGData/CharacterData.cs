using UnityEngine;
using System.Collections;

/// <summary>
/// The very base character data. 1 character data = 1 attribute info for the UI for example.
/// 
/// By: NeilDG
/// </summary>
public class CharacterData {

	private AttackAttribute attackAttribute;
	private DefenseAttribute defenseAttribute;
	private SpeedAttribute speedAttribute;
	private HealthAttribute HealthAttribute;


	public CharacterData(AttackAttribute attackAttribute, DefenseAttribute defenseAttribute, SpeedAttribute speedAttribute, HealthAttribute healthAttribute) {
		this.attackAttribute = attackAttribute;
		this.defenseAttribute = defenseAttribute;
		this.speedAttribute = speedAttribute;
		this.HealthAttribute = healthAttribute;
	}

	public AttackAttribute GetAttackAttribute() {
		return this.attackAttribute;
	}

	public DefenseAttribute GetDefenseAttribute() {
		return this.defenseAttribute;
	}

	public SpeedAttribute GetSpeedAttribute() {
		return this.speedAttribute;
	}

	public HealthAttribute GetHealthAttribute() {
		return this.HealthAttribute;
	}
}
