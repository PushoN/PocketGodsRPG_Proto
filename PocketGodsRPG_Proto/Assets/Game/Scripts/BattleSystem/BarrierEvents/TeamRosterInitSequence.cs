using UnityEngine;
using System.Collections;

public class TeamRosterInitSequence : ASequence {

	private BattleDataHolder battleDataHolder;

	private int unitCount = 0;

	public TeamRosterInitSequence(CyclicBarrierSequence barrierSequence, BattleDataHolder battleDataHolder) : base(barrierSequence) {
		this.battleDataHolder = battleDataHolder;

		EventBroadcaster.Instance.AddObserver(EventNames.ON_UNIT_INITIALIZE_SUCCESS, this.OnUnitInstantiateSuccess);
	}

	public override void Execute ()
	{
		BattleComposition.Initialize();
		this.battleDataHolder.InitializeTeamRoster();
	}

	private void OnUnitInstantiateSuccess() {
		this.unitCount++;

		if(this.unitCount == this.battleDataHolder.GetTotalNumberOfUnits()) {
			this.ReportFinished();
			EventBroadcaster.Instance.RemoveObserver(EventNames.ON_UNIT_INITIALIZE_SUCCESS);
		}
		
	}
}
