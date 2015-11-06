using UnityEngine;
using System.Collections;

public class NoInputState : AState {

	private Camera gameCamera;

	public NoInputState(string stateLabel, AStateMachine stateMachine): base(stateLabel, stateMachine) {
		
	}

	public void AssignGameCamera(Camera camera) {
		this.gameCamera = camera;
	}


	public override void OnEnter ()
	{
		Debug.Log("NoInputState enter");
	}

	public override void OnUpdate ()
	{

	}

	public override void OnExit ()
	{
		Debug.Log ("NoInputState exit");
	}
}
