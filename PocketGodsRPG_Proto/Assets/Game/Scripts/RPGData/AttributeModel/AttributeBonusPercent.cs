using UnityEngine;
using System.Collections;

/// <summary>
/// Attribute bonus percent representation. Example. 40% increase/decrease to attribute base.
/// 
/// By: NeilDG
/// </summary>
public class AttributeBonusPercent {

	public enum PercentType {
		ATTRIBUTE_INCREASE,
		ATTRIBUTE_DECREASE
	}

	private float percentNormalized = 0.0f;
	private PercentType percentType;

	/// <summary>
	/// Parameter value should be 0.0 - 1.0f.
	/// Percent type should be INCREASING/DECREASING.
	/// </summary>
	/// <param name="percentNormalized">Percent normalized.</param>
	public AttributeBonusPercent(float percentNormalized, PercentType percentType) {
		this.percentNormalized = percentNormalized;
		this.percentType = percentType;
	}

	public float GetPercentNormalized() {
		return this.percentNormalized;
	}

	/// <summary>
	/// Returns the percent in displayable form as string
	/// </summary>
	/// <returns>The percent string.</returns>
	public string GetPercentString() {
		string formatted = this.percentNormalized.ToString("0.##\\%"); 
		return formatted;
	}

	public PercentType GetPercentType() {
		return this.percentType;
	}
}
