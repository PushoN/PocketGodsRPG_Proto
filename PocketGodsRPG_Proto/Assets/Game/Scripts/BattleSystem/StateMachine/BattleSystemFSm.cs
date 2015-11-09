using UnityEngine;
using System.Collections;

public class BattleSystemFSM : AStateMachine {

	private InitializeTeamState initializeState;

	public override void InitializeStateTransitions ()
	{
		this.initializeState = new InitializeTeamState("InitializeTeam", this);
		this.SetInitialState(this.initialState);
	}
}
