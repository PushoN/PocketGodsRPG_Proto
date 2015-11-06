using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// An instantiable/inheritable state machine reusable for complex components. Only acts as a data structure
/// By: NeilDG
/// </summary>
public abstract class AStateMachine {

	protected AState initialState = null;
	protected AState currentState = null;

	public void SetInitialState(AState initialState) {
		this.initialState = initialState;
		this.currentState = initialState;
	}

	/// <summary>
	/// Transitions the current state to its next state. Will not transition if the current state do not have any next state!
	/// </summary>
	public void TransitionTo(string stateLabel) {
		if(this.currentState.HasTransition(stateLabel)) {
			this.currentState.OnExit();
			this.currentState = this.currentState.GetTransitionState(stateLabel);
			this.currentState.OnEnter();
		}
		else {
			Debug.LogError("Transition state " +stateLabel+ " does not exist in " +this.currentState.GetLabel());
		}
	}

	/// <summary>
	/// Raises the update event. Call this if you want this state machine to perform actions on Unity Update
	/// </summary>
	public void OnUpdate() {
		this.currentState.OnUpdate();
	}

	public AState GetCurrentState() {
		return this.currentState;
	}

	public string GetCurrentStateLabel() {
		return this.currentState.GetLabel();
	}

	/// <summary>
	/// Put all state initialization and state transitions here!
	/// </summary>
	public abstract void InitializeStateTransitions();
}
