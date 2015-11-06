using UnityEngine;
using System.Collections;

public class WorldInputStateController : MonoBehaviour {

	private static WorldInputStateController sharedInstance = null;
	public static WorldInputStateController Instance {
		get {
			return sharedInstance;
		}
	}

	public const float DRAG_REDUCER_FACTOR = 0.03f;
	public const float DRAG_GIVEN_TIME = 1.0f;
	public const float DRAG_SPEED = 80.0f;

	[SerializeField] private Camera gameCamera;
	
	private Vector3 currentFingerPointer;
	private Vector3 dragOrigin;
	private Vector3 velocity;
	
	private bool hasTouchedObject = false;
	private float totalTimeDrag = 0.0f;

	private InputStateMachine inputStateMachine;

	void Awake() { 
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
		this.inputStateMachine = new InputStateMachine(this.gameCamera);
		this.inputStateMachine.InitializeStateTransitions();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			this.NoInputStateAction();
		}
		else if(this.inputStateMachine.GetCurrentStateLabel() == InputStateMachine.DRAG_WORLD_STATE) {
			this.DragWorldAction();
		}

		this.gameCamera.transform.position -= this.velocity;
		this.velocity.x *= Mathf.Pow(DRAG_REDUCER_FACTOR, Time.deltaTime);
		this.velocity.y *= Mathf.Pow(DRAG_REDUCER_FACTOR, Time.deltaTime);
	}

	private void NoInputStateAction() {
		this.currentFingerPointer = gameCamera.ScreenToViewportPoint(Input.mousePosition);
		this.inputStateMachine.TransitionTo(InputStateMachine.DRAG_WORLD_STATE);
	}

	private void DragWorldAction() {
		Vector3 mousePosition = gameCamera.ScreenToViewportPoint(Input.mousePosition);
		float deltaX = mousePosition.x - this.currentFingerPointer.x;
		float deltaY = mousePosition.y - this.currentFingerPointer.y;
		this.velocity = new Vector3(deltaX * DRAG_SPEED, deltaY * DRAG_SPEED, 0);
		this.currentFingerPointer = gameCamera.ScreenToViewportPoint(Input.mousePosition);
		
		if(this.HasReachedElapsedDragTime()) {
			this.totalTimeDrag = 0.0f;
		}

		if(Input.GetMouseButtonUp(0)) {
			this.inputStateMachine.TransitionTo(InputStateMachine.NO_INPUT_STATE);
		}
	}

	private bool HasReachedElapsedDragTime() {
		this.totalTimeDrag += Time.deltaTime;
		
		return (this.totalTimeDrag >= DRAG_GIVEN_TIME);
	}
}
