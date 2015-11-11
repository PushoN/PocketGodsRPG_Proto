using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a unique identity for a controllable unit
/// 
/// By: NeilDG
/// </summary>
public class UnitIdentity {

	private string unitName;

	public UnitIdentity(string givenName) {
		this.unitName = givenName;
	}

	public string GetUnitName() {
		return this.unitName;
	}

}
