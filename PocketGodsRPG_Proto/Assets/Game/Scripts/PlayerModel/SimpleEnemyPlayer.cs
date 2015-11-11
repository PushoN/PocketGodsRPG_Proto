using UnityEngine;
using System.Collections;

public class SimpleEnemyPlayer : IPlayer {

	private bool actionPermitted = true;
	private ControllableUnit friendlyUnit;
	private ControllableUnit targetUnit;

	public SimpleEnemyPlayer() {

	}

	public void OnStartTurn() {
		this.actionPermitted = true;
		Debug.Log ("Simple enemy starts turn");
	}

	/// <summary>
	/// This is like an update function
	/// </summary>
	public void DoAction() {
		if(this.actionPermitted == false) {
			return;
		}

		this.friendlyUnit = BattleComposition.Instance.GetUnitAtTeamB(0); 
		this.targetUnit = BattleComposition.Instance.GetUnitAtTeamA(0);//TODO: just get first player unit

		ISkill normalSkill = SkillsManager.Instance.GetSkill(this.friendlyUnit.GetUnitIdentity(),SkillNamesHolder.NORMAL_ATTACK_SKILL);
		normalSkill.AddOnFinishAction(this.OnSkillFinished);
		normalSkill.Perform(this.friendlyUnit, this.targetUnit);

		this.actionPermitted = false;
	}

	public void OnFinishedTurn() {
		Debug.Log ("Enemy has finished its turn!");

		this.targetUnit.UpdateLifeStatus();
		EventBroadcaster.Instance.PostEvent(EventNames.ON_CHECK_TEAM_UNITS);
	}

	private void OnSkillFinished() {
		BattleSystemHandler.Instance.GetTurnManager().ReportTurnFinished();
	}
}
