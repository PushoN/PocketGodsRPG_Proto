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

	private CyclicBarrierSequence battleInitializeSequence = new CyclicBarrierSequence();
	private CyclicBarrierSequence postBattleSequence = new CyclicBarrierSequence();

	private ShowResultsSequence showResultsSeq;

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {

		//INTIALIZE BARRIER EVENT
		TeamRosterInitSequence teamRosterInit = new TeamRosterInitSequence(this.battleInitializeSequence, this.battleDataHolder);
		BarrierEvent initializeEvent = new BarrierEvent(BattleState.INITIALIZE.ToString());
		initializeEvent.AddSequence(teamRosterInit);

		TurnComputeSequence turnComputeSeq = new TurnComputeSequence(this.battleInitializeSequence, this.turnManager);
		TempSkillInitSequence initSkillSeq = new TempSkillInitSequence(this.battleInitializeSequence);
		InitHPBarSequence initHPBarSequence = new InitHPBarSequence(this.battleInitializeSequence);

		BarrierEvent preGamePlayEvent = new BarrierEvent(BattleState.PRE_GAMEPLAY.ToString());
		preGamePlayEvent.AddSequence(turnComputeSeq);
		preGamePlayEvent.AddSequence(initHPBarSequence);
		preGamePlayEvent.AddSequence(initSkillSeq);

		BarrierEvent gamePlayEvent = new BarrierEvent(BattleState.GAMEPLAY.ToString());
		//empty game event for the meantime

		this.battleInitializeSequence.CreateMajorEvent(initializeEvent);
		this.battleInitializeSequence.CreateMajorEvent(preGamePlayEvent);
		this.battleInitializeSequence.CreateMajorEvent(gamePlayEvent);

		//INITIALIZE POST BATTLE EVENT
		this.showResultsSeq = new ShowResultsSequence(this.postBattleSequence);
		BarrierEvent gameplayWrapUpEvent = new BarrierEvent(BattleState.RESULTS.ToString());
		gameplayWrapUpEvent.AddSequence(this.showResultsSeq);

		this.postBattleSequence.CreateMajorEvent(gameplayWrapUpEvent);


		EventBroadcaster.Instance.AddObserver(EventNames.ON_CHECK_TEAM_UNITS, this.OnCheckTeamUnitsEvent);
		this.StartCoroutine(this.DelayedStart());

	}

	void OnDestroy() {
		BattleComposition.Destroy();
		EventBroadcaster.Instance.RemoveObserver(EventNames.ON_CHECK_TEAM_UNITS);
	}

	private IEnumerator DelayedStart() {
		yield return new WaitForSeconds(0.01f);

		this.battleInitializeSequence.StartExecution();
	}

	public TurnManager GetTurnManager() {
		return this.turnManager;
	}

	public BattleState GetCurrentState() {
		return (BattleState) System.Enum.Parse(typeof(BattleState),this.battleInitializeSequence.GetCurrentBarrierName());
	}

	private void OnCheckTeamUnitsEvent() {
		//verify if either TEAM A or TEAM B has all units killed
		List<ControllableUnit> teamAUnits = BattleComposition.Instance.GetAllTeamAUnits();
		List<ControllableUnit> teamBUnits = BattleComposition.Instance.GetAllTeamBUnits();

		bool teamAOutcome = true; bool teamBOutcome = true;
		//check if all team A units are dead
		foreach(ControllableUnit unit in teamAUnits) {
			if(unit.IsDead() == false) {
				teamAOutcome = false;
				break;
			}
		}

		if(teamAOutcome == true) {
			this.showResultsSeq.SetWinningTeam(ShowResultsSequence.WinningTeam.TEAM_A);
			this.postBattleSequence.StartExecution();
		}

		//check if all team B units are dead
		foreach(ControllableUnit unit in teamBUnits) {
			if(unit.IsDead() == false) {
				teamBOutcome = false;
				break;
			}
		}

		if(teamBOutcome == true) {
			this.showResultsSeq.SetWinningTeam(ShowResultsSequence.WinningTeam.TEAM_B);
			this.postBattleSequence.StartExecution();
		}
	}
}
