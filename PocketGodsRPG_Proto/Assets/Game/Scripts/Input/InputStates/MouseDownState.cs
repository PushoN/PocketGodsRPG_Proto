using UnityEngine;
using System.Collections;

public class MouseDownState : AState {

	public MouseDownState(string stateLabel, AStateMachine stateMachine): base(stateLabel, stateMachine){
		
	}


	public override void OnEnter ()
	{
		Debug.Log("MouseDownState enter");
	}
	
	public override void OnUpdate ()
	{
		
	}
	
	public override void OnExit ()
	{
		Debug.Log ("MouseDownState exit");
	}
}
