using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a human player
/// </summary>
public class HumanPlayer : IPlayer {

	private bool performAction = false;

	private ControllableUnit friendlyUnit;
	private ControllableUnit targetUnit;

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
		this.targetUnit = BattleInputController.Instance.GetLastTouchedUnit();
		this.friendlyUnit = BattleComposition.Instance.GetUnitAtTeamA(0); //select 1st unit for the meantime.

		if(this.targetUnit != null && this.targetUnit != this.friendlyUnit ) {
			Debug.Log("Hoooman selected " +this.targetUnit);
			this.performAction = false;

			ISkill normalSkill = SkillsManager.Instance.GetSkill(this.friendlyUnit.GetUnitIdentity(),SkillNamesHolder.NORMAL_ATTACK_SKILL);
			normalSkill.AddOnFinishAction(this.OnSkillFinished);
			normalSkill.Perform(this.friendlyUnit ,this.targetUnit);

			BattleInputController.Instance.ReleaseTouchedUnit();

		}

	}

	public void OnFinishedTurn() {
		//deactivate managers to bar human player input
		Debug.Log("Hoooman finished his turn!");

		this.targetUnit.UpdateLifeStatus();
		EventBroadcaster.Instance.PostEvent(EventNames.ON_CHECK_TEAM_UNITS);
		EventBroadcaster.Instance.RemoveObserver(EventNames.ON_USER_SELECTED_SKILL);
	}

	private void OnUserSelectedSkillEvent() {
		this.performAction = true;
	}

	private void OnSkillFinished() {
		BattleSystemHandler.Instance.GetTurnManager().ReportTurnFinished();
	}
}
