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
		PRE_GAMEPLAY,
		GAMEPLAY,
		RESULTS
	}

	[SerializeField] private BattleDataHolder battleDataHolder;
	[SerializeField] private TurnManager turnManager;

	private BattleState currentState = BattleState.NONE;

	private CyclicBarrierSequence battleBarrierSequence = new CyclicBarrierSequence();

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
		//initialize seqeuences
		List<ASequence> initSeqList = new List<ASequence>();

		//INTIALIZE BARRIER EVENT
		TeamRosterInitSequence teamRosterInit = new TeamRosterInitSequence(this.battleBarrierSequence, this.battleDataHolder);
		initSeqList.Add(teamRosterInit);

		BarrierEvent initializeEvent = new BarrierEvent(BattleState.INITIALIZE.ToString(), initSeqList);

		List<ASequence> preGameSeqList = new List<ASequence>();
		TurnComputeSequence turnComputeSeq = new TurnComputeSequence(this.battleBarrierSequence, this.turnManager);
		preGameSeqList.Add(turnComputeSeq);

		BarrierEvent preGamePlayEvent = new BarrierEvent(BattleState.PRE_GAMEPLAY.ToString(), preGameSeqList);

		this.battleBarrierSequence.CreateMajorEvent(initializeEvent);
		this.battleBarrierSequence.CreateMajorEvent(preGamePlayEvent);

		this.StartCoroutine(this.DelayedStart());

	}

	void OnDestroy() {
		BattleComposition.Destroy();
	}

	public BattleState GetCurrentState() {
		return this.currentState;
	}

	private IEnumerator DelayedStart() {
		yield return new WaitForSeconds(0.01f);

		this.battleBarrierSequence.StartExecution();
	}

	public TurnManager GetTurnManager() {
		return this.turnManager;
	}

}
