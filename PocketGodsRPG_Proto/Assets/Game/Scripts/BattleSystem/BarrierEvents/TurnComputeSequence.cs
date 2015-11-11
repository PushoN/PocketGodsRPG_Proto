using UnityEngine;
using System.Collections;

public class TurnComputeSequence : ASequence {

	private TurnManager turnManager;

	public TurnComputeSequence(CyclicBarrierSequence barrierSequence, TurnManager turnManager) : base(barrierSequence) {
		this.turnManager = turnManager;
	}
	
	public override void Execute ()
	{
		this.turnManager.StartTurnForTeamA();
		this.ReportFinished();
	}
}