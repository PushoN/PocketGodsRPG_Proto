using UnityEngine;
using System.Collections;

/// <summary>
/// Class to handle game cleanup of components or resetting of states. This happens after the game
/// By: Neil DG
/// </summary>
public class PostGameCleanup : ASequence {

	public PostGameCleanup(CyclicBarrierSequence barrierSequence) : base(barrierSequence) {

	}

	public override void Execute ()
	{
		//disable game input
		BattleInputController.Instance.DeactivateTargeting();
		BattleInputController.Instance.enabled = false;
	}
}
