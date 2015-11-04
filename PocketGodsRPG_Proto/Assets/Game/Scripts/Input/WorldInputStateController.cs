using UnityEngine;
using System.Collections;

public class WorldInputStateController : MonoBehaviour {

	private static WorldInputHandler sharedInstance = null;
	public static WorldInputHandler Instance {
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

	// Use this for initialization
	void Start () {
		this.inputStateMachine = new InputStateMachine(this.gameCamera);
		this.inputStateMachine.InitializeStateTransitions();
		this.inputStateMachine.StartMachine();
	}
	
	// Update is called once per frame
	void Update () {
		this.inputStateMachine.OnUpdate();
	}
}
