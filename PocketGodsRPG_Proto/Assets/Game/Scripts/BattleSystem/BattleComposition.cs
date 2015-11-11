using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// This represents the battle composition of the game where it has access to team A and team B.
/// 
/// By: NeilDG
/// </summary>
public class BattleComposition {

	private static BattleComposition sharedInstance = null;
	public static BattleComposition Instance {
		get{
			return sharedInstance;
		}
	}

	private Dictionary<string, ControllableUnit> teamAUnits = new Dictionary<string,ControllableUnit>();
	private Dictionary<string, ControllableUnit> teamBUnits = new Dictionary<string,ControllableUnit>();

	public static void Initialize() {
		sharedInstance = new BattleComposition();
	}

	public static void Destroy() {
		sharedInstance = null;
	}


	public void AddUnitsForTeamA(ControllableUnit controllableUnit) {
		if(this.teamAUnits.ContainsKey(controllableUnit.GetUnitName())) {
			Debug.LogError("Cannot add " +controllableUnit.GetUnitName()+ ". It already exists for team A roster.");
		}
		else {
			this.teamAUnits.Add(controllableUnit.GetUnitName(), controllableUnit);
		}

	}

	public void AddUnitsForTeamB(ControllableUnit controllableUnit) {
		if(this.teamBUnits.ContainsKey(controllableUnit.GetUnitName())) {
			Debug.LogError("Cannot add " +controllableUnit.GetUnitName()+ ". It already exists for team B roster.");
		}
		else {
			this.teamBUnits.Add(controllableUnit.GetUnitName(), controllableUnit);
		}
	}

	public ControllableUnit GetUnitAtTeamA(string unitName) {
		if(this.teamAUnits.ContainsKey(unitName)) {
			return this.teamAUnits[unitName];
		}
		else {
			Debug.LogError(unitName + " does not exist in team A.");
			return null;
		}
	}

	public ControllableUnit GetUnitAtTeamB(string unitName) {
		if(this.teamBUnits.ContainsKey(unitName)) {
			return this.teamBUnits[unitName];
		}
		else {
			Debug.LogError(unitName + " does not exist in team B.");
			return null;
		}
	}

	public List<ControllableUnit> GetAllTeamAUnits() {
		return this.teamAUnits.Values.ToList();
	}

	public List<ControllableUnit> GetAllTeamBUnits() {
		return this.teamBUnits.Values.ToList();
	}

	public ControllableUnit GetUnitAtTeamA(int index) {
		return this.GetAllTeamAUnits()[index];
	}

	public ControllableUnit GetUnitAtTeamB(int index) {
		return this.GetAllTeamBUnits()[index];
	}


}
