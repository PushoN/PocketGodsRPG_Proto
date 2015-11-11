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
		if(this.performAction == false) {
			return;
		}

		//get selected controllable unit to apply skill
		ControllableUnit controllableUnit = BattleInputController.Instance.GetLastTouchedUnit();
		ControllableUnit selectedUnit = BattleComposition.Instance.GetUnitAtTeamA(0); //select 1st unit for the meantime.

		if(controllableUnit != null && controllableUnit != selectedUnit) {
			Debug.Log("Hoooman selected " +controllableUnit);
			this.performAction = false;

			ISkill normalSkill = SkillsManager.Instance.GetSkill(selectedUnit.GetUnitIdentity(),SkillNamesHolder.NORMAL_ATTACK_SKILL);
			normalSkill.AddOnFinishAction(this.OnSkillFinished);
			normalSkill.Perform(selectedUnit,controllableUnit);

			BattleInputController.Instance.ReleaseTouchedUnit();

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

	private void OnSkillFinished() {
		BattleSystemHandler.Instance.GetTurnManager().ReportTurnFinished();
	}
}
