using UnityEngine;
using System.Collections;

public class TeamRosterInitSequence : ASequence {

	private BattleDataHolder battleDataHolder;

	public TeamRosterInitSequence(CyclicBarrierSequence barrierSequence, BattleDataHolder battleDataHolder) : base(barrierSequence) {
		this.battleDataHolder = battleDataHolder;
	}

	public override void Execute ()
	{
		BattleComposition.Initialize();
		this.battleDataHolder.InitializeTeamRoster();

		this.ReportFinished();
	}
}
