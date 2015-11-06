using UnityEngine;
using System.Collections;

public class DragWorldState : AState {

	private Camera gameCamera;
	private Vector3 currentFingerPointer;
	private Vector3 velocity;

	private const float DRAG_REDUCER_FACTOR = 0.03f;
	private const float DRAG_GIVEN_TIME = 1.0f;
	private const float DRAG_SPEED = 80.0f;

	public DragWorldState(string stateLabel, AStateMachine stateMachine): base(stateLabel, stateMachine) {

	}

	public void AssignGameCamera(Camera camera) {
		this.gameCamera = camera;
	}

	public override void OnEnter ()
	{
		Debug.Log("DragWorldState enter");
	}
	
	public override void OnUpdate ()
	{

	}
	
	public override void OnExit ()
	{
		Debug.Log ("DragWorldState exit");
	}
}
