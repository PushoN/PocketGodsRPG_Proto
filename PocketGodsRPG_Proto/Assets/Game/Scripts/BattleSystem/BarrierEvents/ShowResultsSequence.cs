using UnityEngine;
using System.Collections;

/// <summary>
/// Class that handles any processing and showing of results
/// By: Neil DG
/// </summary>
public class ShowResultsSequence : ASequence {

	public enum WinningTeam {
		DRAW,
		TEAM_A,
		TEAM_B
	}

	private WinningTeam winningTeam = WinningTeam.DRAW;

	public ShowResultsSequence(CyclicBarrierSequence barrierSequence) : base(barrierSequence) {
	
	}

	public void SetWinningTeam(WinningTeam team) {
		this.winningTeam = team;
	}

	public override void Execute ()
	{
		if(this.winningTeam == WinningTeam.TEAM_A) {
			Debug.Log("TEAM A WINS!!");
		}
		else {
			Debug.Log("TEAM B WINS!!");
		}
	}
}
