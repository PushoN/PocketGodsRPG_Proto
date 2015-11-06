using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A simple state machine to setup the city building game. Serves as a main() program.
/// 
/// By: NeilDG
/// </summary>
public class BuilderSetupHandler : MonoBehaviour {

	public const string ON_SETUP_TILE_EVENT = "ON_SETUP_TILE_EVENT";
	public const string ON_SETUP_STRUCTURE_EVENT = "ON_SETUP_STRUCTURE_EVENT";
	public const string ON_GAME_PROPER_EVENT = "ON_GAME_PROPER_EVENT";
	public const string ON_GAME_EXIT_EVENT = "ON_GAME_EXIT_EVENT";

	private static BuilderSetupHandler sharedInstance = null;
	public static BuilderSetupHandler Instance {
		get {
			return sharedInstance;
		}
	}

	public enum BuilderStateType {
		NONE,
		SETUP_TILE,
		SETUP_STRUCTURE,
		GAME_PROPER,
		GAME_EXIT
	}

	private BuilderStateType currentState;
	private Dictionary<BuilderStateType, string> stateTable;

	void Awake() {
		sharedInstance = this;
		this.currentState = BuilderStateType.NONE;
		this.InitializeStateTable();
	}

	void Start() {
		this.StartCoroutine(this.DelayedMain());
	}

	void OnDestroy() {
		foreach(string eventName in this.stateTable.Values) {
			EventBroadcaster.Instance.RemoveObserver(eventName);
		}

	}

	private IEnumerator DelayedMain() {
		yield return null;
		this.SetState(BuilderStateType.SETUP_TILE);
	}

	public void InitializeStateTable() {
		this.stateTable = new Dictionary<BuilderStateType, string>();

		this.stateTable.Add(BuilderStateType.SETUP_TILE, ON_SETUP_TILE_EVENT);
		this.stateTable.Add(BuilderStateType.SETUP_STRUCTURE, ON_SETUP_STRUCTURE_EVENT);
		this.stateTable.Add(BuilderStateType.GAME_PROPER, ON_GAME_PROPER_EVENT);
		this.stateTable.Add(BuilderStateType.GAME_EXIT, ON_GAME_EXIT_EVENT);
	}

	public BuilderStateType GetCurrentState() {
		return this.currentState;
	}

	public void SetState(BuilderStateType stateType) {
		this.currentState = stateType;

		EventBroadcaster.Instance.PostEvent(this.stateTable[this.currentState]);
	}

	/// <summary>
	/// Convenience function that attaches an event receiver via event broadcaster system by specifying
	/// the corresponding build state. Does not accept parameters.
	/// </summary>
	/// <param name="builderState">Builder state.</param>
	/// <param name="action">Action.</param>
	public static void RegisterEventReceiver(BuilderStateType builderState, System.Action action) {
		if(sharedInstance == null) {
			Debug.LogError("BuilderSetupHandler not properly setup!");
			return;
		}

		if(sharedInstance.stateTable == null) {
			Debug.LogError("State table not properly initialized!");
			return;
		}

		EventBroadcaster.Instance.AddObserver(sharedInstance.stateTable[builderState], action);
	}

	public static void RemoveEventReceiver(BuilderStateType builderState) {
		if(sharedInstance == null) {
			Debug.LogError("BuilderSetupHandler not properly setup!");
			return;
		}
		
		if(sharedInstance.stateTable == null) {
			Debug.LogError("State table not properly initialized!");
			return;
		}

		EventBroadcaster.Instance.RemoveObserver(sharedInstance.stateTable[builderState]);
	}

}
