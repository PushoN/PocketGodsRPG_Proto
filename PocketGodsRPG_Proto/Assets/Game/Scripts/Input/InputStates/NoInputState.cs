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
		if(Input.GetMouseButtonDown(0)) {
			this.ValidateMouseDown();
		}
	}

	public override void OnExit ()
	{
		Debug.Log ("NoInputState exit");
	}

	private void ValidateMouseDown() {
		Vector3 currentFingerPointer = this.gameCamera.ScreenToViewportPoint(Input.mousePosition);

		this.stateMachine.PutData(InputStateMachine.FINGER_POINTER_KEY, currentFingerPointer);

		Vector3 positionStored = (Vector3) this.stateMachine.RetrieveData(InputStateMachine.FINGER_POINTER_KEY);
		this.stateMachine.TransitionTo(InputStateMachine.DRAG_WORLD_STATE);
	}
}
