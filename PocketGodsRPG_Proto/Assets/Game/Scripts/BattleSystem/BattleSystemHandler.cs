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

	private CyclicBarrierSequence battleBarrierSequence = new CyclicBarrierSequence();

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {

		//INTIALIZE BARRIER EVENT
		TeamRosterInitSequence teamRosterInit = new TeamRosterInitSequence(this.battleBarrierSequence, this.battleDataHolder);
		BarrierEvent initializeEvent = new BarrierEvent(BattleState.INITIALIZE.ToString());
		initializeEvent.AddSequence(teamRosterInit);

		TurnComputeSequence turnComputeSeq = new TurnComputeSequence(this.battleBarrierSequence, this.turnManager);
		TempSkillInitSequence initSkillSeq = new TempSkillInitSequence(this.battleBarrierSequence);

		BarrierEvent preGamePlayEvent = new BarrierEvent(BattleState.PRE_GAMEPLAY.ToString());
		preGamePlayEvent.AddSequence(turnComputeSeq);
		preGamePlayEvent.AddSequence(initSkillSeq);

		this.battleBarrierSequence.CreateMajorEvent(initializeEvent);
		this.battleBarrierSequence.CreateMajorEvent(preGamePlayEvent);

		this.StartCoroutine(this.DelayedStart());

	}

	void OnDestroy() {
		BattleComposition.Destroy();
	}

	private IEnumerator DelayedStart() {
		yield return new WaitForSeconds(0.01f);

		this.battleBarrierSequence.StartExecution();
	}

	public TurnManager GetTurnManager() {
		return this.turnManager;
	}

}
