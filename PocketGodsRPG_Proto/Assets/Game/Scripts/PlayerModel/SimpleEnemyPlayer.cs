using UnityEngine;
using System.Collections;

public class SimpleEnemyPlayer : IPlayer {

	public SimpleEnemyPlayer() {

	}

	public void OnStartTurn() {
		Debug.Log ("Simple enemy starts turn");
	}

	public void DoAction() {
		ControllableUnit enemyUnit = BattleComposition.Instance.GetUnitAtTeamB(0); 
		ControllableUnit playerUnit = BattleComposition.Instance.GetUnitAtTeamA(0);//TODO: just get first player unit

		ISkill normalSkill = SkillsManager.Instance.GetSkill(enemyUnit.GetUnitIdentity(),SkillNamesHolder.NORMAL_ATTACK_SKILL);
		normalSkill.Perform(playerUnit);


		BattleSystemHandler.Instance.GetTurnManager().ReportTurnFinished();

	}

	public void OnFinishedTurn() {
		Debug.Log ("Enemy has finished its turn!");
	}
}
