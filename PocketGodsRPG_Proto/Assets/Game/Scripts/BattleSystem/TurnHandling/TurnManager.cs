using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the turns for the battle system and sequencing of controllable units to use.
/// </summary>
public class TurnManager : MonoBehaviour {

	[SerializeField] private string currentTurnUnitName;
	[SerializeField] private int turnCount = 0;

	private IPlayer playerForTeamA;
	private IPlayer playerForTeamB;

	private IPlayer activePlayer;

	// Use this for initialization
	void Start () {
		this.playerForTeamA = new HumanPlayer();
	}

	void Update() {
		if(this.activePlayer != null) {
			this.activePlayer.DoAction();
		}
	}

	public void ReportTurnFinished() {
		this.turnCount++;

		if(this.IsTeamATurn()) {
			this.activePlayer.OnFinishedTurn();
			this.StartTurnForTeamA();
		}

		else if(this.IsTeamBTurn()) {
			this.activePlayer.OnFinishedTurn();
			this.StartTurnForTeamB();
		}

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

	public void StartTurnForTeamA() {
		this.activePlayer = this.playerForTeamA;

		if(this.activePlayer != null) {
			this.activePlayer.OnStartTurn();
		}
	}

	public void StartTurnForTeamB() {
		this.activePlayer = this.playerForTeamB;

		if(this.activePlayer != null) {
			this.activePlayer.OnStartTurn();
		}
	}
}
