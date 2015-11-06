using UnityEngine;
using System.Collections;

public class TestRawBonus : MonoBehaviour {

	public enum TargetAttribute {
		HEALTH,
		ATTACK,
		DEFENSE,
		SPEED
	}

	[SerializeField] private TargetAttribute targetAttribute;
	[SerializeField] private int value;
	[SerializeField] private float multiplier;

	private AttributeBonus attributeBonus;

	// Use this for initialization
	void Start () {
		this.attributeBonus = new AttributeBonus(this.value, this.multiplier);
	}

	public AttributeBonus GetAttributeBonus() {
		return this.attributeBonus;
	}

	public TargetAttribute GetTargetAttribute() {
		return this.targetAttribute;
	}

}
