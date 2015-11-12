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

			Vector3 unitScreenPos = Camera.main.WorldToViewportPoint(unit.transform.position);

			Parameters parameters = new Parameters();
			parameters.PutObjectExtra(GameHUDView.UNIT_POSITION_KEY, unitScreenPos);
			parameters.PutObjectExtra(GameHUDView.CONTROLLABLE_UNIT_KEY, unit);

			EventBroadcaster.Instance.PostEvent(EventNames.ON_RETRIEVE_UNIT_POSITION, parameters);
		}

		foreach(ControllableUnit unit in teamBList) {

			Vector3 unitScreenPos = Camera.main.WorldToViewportPoint(unit.transform.position);

			Parameters parameters = new Parameters();
			parameters.PutObjectExtra(GameHUDView.UNIT_POSITION_KEY, unitScreenPos);
			parameters.PutObjectExtra(GameHUDView.CONTROLLABLE_UNIT_KEY, unit);
			
			EventBroadcaster.Instance.PostEvent(EventNames.ON_RETRIEVE_UNIT_POSITION, parameters);
		}
	}
}
