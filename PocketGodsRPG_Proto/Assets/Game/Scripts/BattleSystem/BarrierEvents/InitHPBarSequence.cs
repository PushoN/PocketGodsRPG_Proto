using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Creates and assigns placements of HP bar on enemies
/// </summary>
public class InitHPBarSequence : ASequence {
	
	public InitHPBarSequence(CyclicBarrierSequence barrierSequence) : base(barrierSequence) {
		
	}

	public override void Execute ()
	{
		List<ControllableUnit> teamAList = BattleComposition.Instance.GetAllTeamAUnits();
		List<ControllableUnit> teamBList = BattleComposition.Instance.GetAllTeamBUnits();

		foreach(ControllableUnit unit in teamAList) {
			Parameters parameters = new Parameters();
			parameters.PutObjectExtra(GameHUDScreen.UNIT_POSITION_KEY, unit.transform.position);

			EventBroadcaster.Instance.PostEvent(EventNames.ON_RETRIEVE_UNIT_POSITION, parameters);
		}

		foreach(ControllableUnit unit in teamBList) {
			Parameters parameters = new Parameters();
			parameters.PutObjectExtra(GameHUDScreen.UNIT_POSITION_KEY, unit.transform.position);
			
			EventBroadcaster.Instance.PostEvent(EventNames.ON_RETRIEVE_UNIT_POSITION, parameters);
		}
	}
}
