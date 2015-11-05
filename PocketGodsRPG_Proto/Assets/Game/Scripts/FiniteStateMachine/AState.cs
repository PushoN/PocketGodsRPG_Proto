using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Representation of a FSM state
/// 
/// By: NeilDG
/// </summary>
public abstract class AState  {

	private string stateLabel = null;
	private Dictionary<string, AState> transitionStates = new Dictionary<string, AState>();

	protected AStateMachine stateMachine;
	
	public abstract void OnEnter();
	public abstract void OnUpdate();
	public abstract void OnExit();

	public AState(string stateLabel, AStateMachine stateMachine) {
		this.stateLabel = stateLabel;
		this.stateMachine = stateMachine;
	}

	public string GetLabel() {
		return this.stateLabel;
	}

	public void AddTransition(string stateLabel, AState state) {
		if(this.transitionStates.ContainsKey(stateLabel) == false) {
			this.transitionStates.Add(stateLabel, state);
		}
		else {
			Debug.LogError(stateLabel + " already exists as a transition state from " +this.stateLabel+ ".");
		}
	}

	public AState GetTransitionState(string stateLabel) {
		if(this.HasTransition(stateLabel)) {
			return this.transitionStates[stateLabel];
		}
		else {
			Debug.LogError(stateLabel + " not found as transition state in " +this.stateLabel+ ".");
			return null;
		}
	}

	public bool HasTransition(string stateLabel) {
		return (this.transitionStates.ContainsKey(stateLabel));
	}
}
