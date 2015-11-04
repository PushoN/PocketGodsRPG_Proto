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
		this.currentFingerPointer = (Vector3) this.stateMachine.RetrieveData(InputStateMachine.FINGER_POINTER_KEY);
	}
	
	public override void OnUpdate ()
	{
		Vector3 mousePosition = gameCamera.ScreenToViewportPoint(Input.mousePosition);
		float deltaX = mousePosition.x - this.currentFingerPointer.x;
		float deltaY = mousePosition.y - this.currentFingerPointer.y;
		this.velocity = new Vector3(deltaX * DRAG_SPEED, deltaY * DRAG_SPEED, 0);
		this.currentFingerPointer = gameCamera.ScreenToViewportPoint(Input.mousePosition);

		this.gameCamera.transform.position -= this.velocity;
		this.velocity.x *= Mathf.Pow(DRAG_REDUCER_FACTOR, Time.deltaTime);
		this.velocity.y *= Mathf.Pow(DRAG_REDUCER_FACTOR, Time.deltaTime);

		if(Input.GetMouseButtonUp(0)) {
			this.stateMachine.TransitionTo(InputStateMachine.NO_INPUT_STATE);
		}
	}
	
	public override void OnExit ()
	{
		Debug.Log ("DragWorldState exit");
	}
}
