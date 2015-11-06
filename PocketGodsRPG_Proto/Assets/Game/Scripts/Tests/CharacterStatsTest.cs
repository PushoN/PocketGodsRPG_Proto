using UnityEngine;
using System.Collections;

/// <summary>
/// Pseudo unit test to check attribute statistics if they compute as intended
/// </summary>
public class CharacterStatsTest : MonoBehaviour {

	private CharacterData character;

	// Use this for initialization
	void Start () {
		this.CharacterTestDefault();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CharacterTestDefault() {
		AttackAttribute attackAttribute = new AttackAttribute(1, 1.0f);
		DefenseAttribute defenseAttribute = new DefenseAttribute(1, 1.0f);
		HealthAttribute healthAttribute = new HealthAttribute(1,1.0f);
		SpeedAttribute speedAttribute = new SpeedAttribute(1,1.0f);
		
		this.character = new CharacterData(attackAttribute, defenseAttribute, speedAttribute, healthAttribute);

		Debug.Log ("-----Default Stats------");
		Debug.Log ("Health: " +this.character.GetHealthAttribute().GetModifiedValue() +
			" Attack: " +this.character.GetAttackAttribute().GetModifiedValue() + 
			" Defense: " +this.character.GetDefenseAttribute().GetModifiedValue() +
			" Speed: " +this.character.GetSpeedAttribute().GetModifiedValue());
		Debug.Log ("----Default Stats End----");
	}
}
