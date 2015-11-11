using UnityEngine;
using System.Collections;

public class SimpleEnemyPlayer : IPlayer {

	private bool actionPermitted = true;

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

		ControllableUnit enemyUnit = BattleComposition.Instance.GetUnitAtTeamB(0); 
		ControllableUnit playerUnit = BattleComposition.Instance.GetUnitAtTeamA(0);//TODO: just get first player unit

		ISkill normalSkill = SkillsManager.Instance.GetSkill(enemyUnit.GetUnitIdentity(),SkillNamesHolder.NORMAL_ATTACK_SKILL);
		normalSkill.AddOnFinishAction(this.OnSkillFinished);
		normalSkill.Perform(enemyUnit, playerUnit);

		this.actionPermitted = false;
	}

	public void OnFinishedTurn() {
		Debug.Log ("Enemy has finished its turn!");
	}

	private void OnSkillFinished() {
		BattleSystemHandler.Instance.GetTurnManager().ReportTurnFinished();
	}
}
