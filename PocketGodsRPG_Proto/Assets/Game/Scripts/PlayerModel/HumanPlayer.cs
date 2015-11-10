using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a human player
/// </summary>
public class HumanPlayer : IPlayer {

	private bool performAction = false;

	public HumanPlayer() {

	}

	public void OnStartTurn() {
		//activate needed managers for human player input
		EventBroadcaster.Instance.AddObserver(EventNames.ON_USER_SELECTED_SKILL, this.OnUserSelectedSkillEvent);
	}

	public void DoAction() {
		//like an update function
		if(this.performAction == true) {
			//get selected controllable unit to apply skill
			ControllableUnit controllableUnit = BattleInputController.Instance.GetLastTouchedUnit();

			if(controllableUnit != null) {
				Debug.Log("Hoooman selected " +controllableUnit);
				this.performAction = false;

				BattleSystemHandler.Instance.GetTurnManager().ReportTurnFinished();
			}
		}
	}

	public void OnFinishedTurn() {
		//deactivate managers to bar human player input
		Debug.Log("Hoooman finished his turn!");
		EventBroadcaster.Instance.RemoveObserver(EventNames.ON_USER_SELECTED_SKILL);
	}

	private void OnUserSelectedSkillEvent() {
		this.performAction = true;
	}
}
