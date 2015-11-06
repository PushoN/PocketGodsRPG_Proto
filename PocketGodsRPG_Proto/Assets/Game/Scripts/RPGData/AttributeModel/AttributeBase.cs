using UnityEngine;
using System.Collections;

/// <summary>
/// A base attribute. All attributes inherit this
/// 
/// By: NeilDG
/// </summary>
public abstract class AttributeBase {
	private int baseValue = 0;
	private float multiplier = 1.0f;

	private int multipliedValue = 0;

	/// <summary>
	/// Initializes a new instance of the <see cref="AttributeBase"/> class.
	/// </summary>
	/// <param name="value">Value = default value of the attribute</param>
	/// <param name="multiplier">Multiplier = should be greater than 1.0f</param>
	public AttributeBase(int value, float multiplier) {
		this.baseValue = value;
		this.multiplier = multiplier;

		this.multipliedValue = Mathf.RoundToInt(this.baseValue * this.multiplier);
	}

	public int GetBaseValue() {
		return this.baseValue;
	}

	public float GetMultiplier() {
		return this.multiplier;
	}

	/// <summary>
	/// Returns the value * multiplier rounded to int.
	/// </summary>
	/// <returns>The value with multiplier.</returns>
	public int GetBaseValueWithMultiplier() {
		return this.multipliedValue;
	}
}
