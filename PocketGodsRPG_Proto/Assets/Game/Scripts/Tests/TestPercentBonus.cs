using UnityEngine;
using System.Collections;

public class TestPercentBonus : MonoBehaviour {

	[SerializeField] private TestRawBonus.TargetAttribute targetAttribute;
	[SerializeField] private AttributeBonusPercent.PercentType percentType;
	[SerializeField] private float percentNormalized;

	private AttributeBonusPercent attributeBonusPercent;

	// Use this for initialization
	void Start () {
		this.attributeBonusPercent = new AttributeBonusPercent(this.percentNormalized, this.percentType);
	}

	public AttributeBonusPercent GetAttributeBonusPercent() {
		return this.attributeBonusPercent;
	}

	public TestRawBonus.TargetAttribute GetTargetAttribute() {
		return this.targetAttribute;
	}
}
