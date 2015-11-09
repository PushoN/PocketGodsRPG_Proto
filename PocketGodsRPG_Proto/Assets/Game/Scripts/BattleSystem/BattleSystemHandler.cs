using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleSystemHandler : MonoBehaviour {

	private static BattleSystemHandler sharedInstance = null;
	public static BattleSystemHandler Instance {
		get {
			return sharedInstance;
		}
	}

	public enum BattleState {
		NONE,
		INITIALIZE,
		COMPOSE_TEAM,
		GAMEPLAY,
		RESULTS
	}

	[SerializeField] private BattleDataHolder battleDataHolder;
	
	private List<ControllableUnit> teamAUnitList = new List<ControllableUnit>();
	private List<ControllableUnit> teamBUnitList = new List<ControllableUnit>();

	private BattleState currentState = BattleState.NONE;

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
		this.currentState = BattleState.INITIALIZE;
		this.StartCoroutine(this.DelayedStart());	

	}

	public BattleState GetCurrentState() {
		return this.currentState;
	}

	private IEnumerator DelayedStart() {
		yield return new WaitForSeconds(0.01f);

		this.battleDataHolder.InitializeTeamRoster();
	}

}
