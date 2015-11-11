using UnityEngine;
using System.Collections;

/// <summary>
/// Holds arbitrary data for the battle system. Handles initialization of rosters
/// </summary>
public class BattleDataHolder : MonoBehaviour {

	[SerializeField] private int teamASize = 1;
	[SerializeField] private int teamBSize = 1;

	[SerializeField] private ControllableUnit[] teamAUnitRoster;
	[SerializeField] private ControllableUnit[] teamBUnitRoster;

	[SerializeField] private Transform teamAPosition;
	[SerializeField] private Transform teamBPosition;



	// Use this for initialization
	void Start () {
	
	}

	public void InitializeTeamRoster() {

		foreach(ControllableUnit controllableUnit in this.teamAUnitRoster) {
			ControllableUnit unitInstance = GameObject.Instantiate(controllableUnit) as ControllableUnit;

			unitInstance.transform.localPosition = this.teamAPosition.localPosition;
			unitInstance.transform.SetParent(BattleSystemHandler.Instance.transform, false);

			BattleComposition.Instance.AddUnitsForTeamA(unitInstance);
		}

		foreach(ControllableUnit controllableUnit in this.teamBUnitRoster) {
			ControllableUnit unitInstance = GameObject.Instantiate(controllableUnit) as ControllableUnit;
			unitInstance.transform.localPosition = this.teamBPosition.localPosition;
			unitInstance.transform.SetParent(BattleSystemHandler.Instance.transform, false);

			BattleComposition.Instance.AddUnitsForTeamB(unitInstance);
		}
	}

	public int GetTotalNumberOfUnits() {
		return (this.teamAUnitRoster.Length + this.teamBUnitRoster.Length);
	}
}
