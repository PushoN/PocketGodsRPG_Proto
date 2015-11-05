using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The concrete attribute that all specific attributes inherit
/// </summary>
public abstract class ConcreteAttribute: AttributeBase {

	private List<AttributeBonus> attributeBonuses = new List<AttributeBonus>();
	private List<AttributeBonusPercent> bonusPercentList = new List<AttributeBonusPercent>();

	private int modifiedValue = 0;
	private bool valueUpdated = true;
	
	public ConcreteAttribute(int baseValue, float multiplier): base(baseValue, multiplier) {

	}

	public void AddAttributeBonus(AttributeBonus attributeBonus) {
		this.attributeBonuses.Add(attributeBonus);
		this.valueUpdated = true;
	}

	public void AddBonusPercent(AttributeBonusPercent bonusPercent) {
		this.bonusPercentList.Add(bonusPercent);
		this.valueUpdated = true;
	}

	public void RemoveAttributeBonus(AttributeBonus attributeBonus) {
		this.attributeBonuses.Remove(attributeBonus);
		this.valueUpdated = true;
	}

	public void RemoveBonusPercent(AttributeBonusPercent bonusPercent) {
		this.bonusPercentList.Remove(bonusPercent);
		this.valueUpdated = true;
	}

	/// <summary>
	/// Returns the modified value affected by attribute bonuses and percentages.
	/// RAW VALUE gets added together with attribute bonuses, and THEN multiplied by the total percentage.
	/// </summary>
	/// <returns>The modified value.</returns>
	public int GetModifiedValue() {

		//skip computation if value has not changed
		if(this.valueUpdated == true) {
			this.valueUpdated = false;

			int totalRawBonus = 0;
			float rawPercentage = 0.0f;
			
			foreach(AttributeBonus attributeBonus in this.attributeBonuses) {
				totalRawBonus += attributeBonus.GetBaseValueWithMultiplier();
			}
			
			foreach(AttributeBonusPercent bonusPercent in this.bonusPercentList) {
				if(bonusPercent.GetPercentType() == AttributeBonusPercent.PercentType.ATTRIBUTE_INCREASE) {
					rawPercentage += bonusPercent.GetPercentNormalized();
				}
				else {
					rawPercentage -= bonusPercent.GetPercentNormalized();
				}
			}
			
			this.modifiedValue = this.GetBaseValueWithMultiplier() + totalRawBonus; //add raw bonus
			this.modifiedValue += Mathf.RoundToInt(this.modifiedValue * rawPercentage); //add percentage added
		}

		return this.modifiedValue;


	}
}
