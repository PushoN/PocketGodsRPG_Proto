using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// TEMPORARY sequence included in initialization for skills. Future should read from data.
/// </summary>
public class TempSkillInitSequence : ASequence {

	public TempSkillInitSequence(CyclicBarrierSequence barrierSequence) : base(barrierSequence) {

	}

	public override void Execute ()
	{
		SkillsManager.Initialize();

		List<ControllableUnit> teamAUnits = BattleComposition.Instance.GetAllTeamAUnits();
		List<ControllableUnit> teamBUnits = BattleComposition.Instance.GetAllTeamBUnits();

		//all units get NORMAL skill
		foreach(ControllableUnit unit in teamAUnits) {
			UnitIdentity unitID = unit.GetUnitIdentity();
			NormalAttackSkill normalAttack = new NormalAttackSkill();

			SkillsManager.Instance.AddSkill(unitID,normalAttack.GetSkillName(), normalAttack);
			Debug.Log ("Skill added to " +unitID.GetUnitName() + " Skill Name: " +normalAttack.GetSkillName());
		}

		//all units get NORMAL skill
		foreach(ControllableUnit unit in teamBUnits) {
			UnitIdentity unitID = unit.GetUnitIdentity();
			NormalAttackSkill normalAttack = new NormalAttackSkill();
			
			SkillsManager.Instance.AddSkill(unitID,normalAttack.GetSkillName(), normalAttack);
			Debug.Log ("Skill added to " +unitID.GetUnitName() + " Skill Name: " +normalAttack.GetSkillName());
		}

		this.ReportFinished();
	}
}
