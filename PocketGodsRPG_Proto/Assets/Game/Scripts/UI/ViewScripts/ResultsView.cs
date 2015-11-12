using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Represents the results view
/// By: NeilDG
/// </summary>
public class ResultsView : View {

	[SerializeField] private Text winningText;

	// Use this for initialization
	void Start () {
	
	}

	public void SetWinningTeam(ShowResultsSequence.WinningTeam winningTeam) {
		if(winningTeam == ShowResultsSequence.WinningTeam.TEAM_A) {
			this.winningText.text = "TEAM A WINS!";
		}
		else if(winningTeam == ShowResultsSequence.WinningTeam.TEAM_B) {
			this.winningText.text = "TEAM B WINS!";
		}
		else {
			this.winningText.text = "DRAW";
		}
	}

	public void OnPlayAgainClicked() {
		//RESTART LEVEL
		EventBroadcaster.Instance.RemoveAllObservers();
		Application.LoadLevel(Application.loadedLevelName);
	}
}
