using UnityEngine;
using System.Collections;

/// <summary>
/// Handles input for the world. Dragging, picking up structures, and click events for sprites excluding UI
/// </summary>
public class WorldInputHandler : MonoBehaviour {

	private static WorldInputHandler sharedInstance = null;
	public static WorldInputHandler Instance {
		get {
			return sharedInstance;
		}
	}

	public enum InputState {
		STARTED,
		DRAGGED,
		ENDED,
		RESTRICTED,
		NONE,
	}

	private const float DRAG_REDUCER_FACTOR = 0.03f;
	private const float DRAG_GIVEN_TIME = 1.0f;
	private const float DRAG_SPEED = 80.0f;

	[SerializeField] private Camera gameCamera;

	private InputState currentState = InputState.NONE;

	private Vector3 currentFingerPointer;
	private Vector3 velocity;

	private bool hasTouchedObject = false;
	private float totalTimeDrag = 0.0f;

	// Use this for initialization
	void Start () {
		this.currentFingerPointer = Vector3.zero;
		this.velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if(this.currentState == InputState.RESTRICTED)
			return;
		
		if (Input.GetMouseButtonDown(0)){
			this.currentState = InputState.STARTED;
		}
		
		if(Input.GetMouseButtonUp(0)) {
			this.currentState = InputState.ENDED;
		}

		this.HandleMouseState();
		this.UpdateCamera(this.gameCamera.transform);
		this.velocity.x *= Mathf.Pow(DRAG_REDUCER_FACTOR, Time.deltaTime);
		this.velocity.y *= Mathf.Pow(DRAG_REDUCER_FACTOR, Time.deltaTime);
	}

	private void HandleMouseState() {
		switch(this.currentState) {
		case InputState.STARTED: 
			this.currentFingerPointer = gameCamera.ScreenToViewportPoint(Input.mousePosition);
			this.currentState = InputState.DRAGGED;
			break;
			
		case InputState.DRAGGED:
			Vector3 mousePosition = gameCamera.ScreenToViewportPoint(Input.mousePosition);
			float deltaX = mousePosition.x - this.currentFingerPointer.x;
			float deltaY = mousePosition.y - this.currentFingerPointer.y;
			this.velocity = new Vector3(deltaX * DRAG_SPEED, deltaY * DRAG_SPEED, 0);
			this.currentFingerPointer = gameCamera.ScreenToViewportPoint(Input.mousePosition);
			
			if(this.HasReachedElapsedDragTime()) {
				this.totalTimeDrag = 0.0f;
			}
			break;

		case InputState.ENDED: 
			this.currentState = InputState.NONE;
			this.totalTimeDrag = 0.0f;
			break;
			
		case InputState.RESTRICTED:
		case InputState.NONE: break;
		}
	}

	private bool HasReachedElapsedDragTime() {
		this.totalTimeDrag += Time.deltaTime;
		
		return (this.totalTimeDrag >= DRAG_GIVEN_TIME);
	}

	private void UpdateCamera(Transform transform) {
		transform.position -= this.velocity;
		
		/*Vector3 computedScale = ComputedScaleHolder.sharedInstance.uiComputedScale;
		
		Vector3 newLowerBoundPos = this.lowerBoundScroll.position;
		Vector3 newUpperBoundPos = this.upperBoundScroll.position;
		
		Vector3 clampedPos = transform.position;
		clampedPos.y = Mathf.Clamp(clampedPos.y, newLowerBoundPos.y * computedScale.y, newUpperBoundPos.y * computedScale.y);
		
		transform.position = clampedPos;*/
		
	}
}
