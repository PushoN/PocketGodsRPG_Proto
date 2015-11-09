using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the turns for the battle system and sequencing of controllable units to use.
/// </summary>
public class TurnManager : MonoBehaviour {

	[SerializeField] private string currentTurnUnitName;
	[SerializeField] private int turnCount = 0;

	// Use this for initialization
	void Start () {
	
	}

	public void ReportTurnFinished() {
		this.turnCount++;
	}

	public void Reset() {
		this.turnCount = 0;
	}

	public bool IsTeamATurn() {
		return (this.turnCount % 2 == 0);
	}

	public bool IsTeamBTurn() {
		return (this.turnCount % 2 != 0);
	}
}
