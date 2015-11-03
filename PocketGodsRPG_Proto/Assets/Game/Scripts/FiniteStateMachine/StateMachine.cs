using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// An instantiable/inheritable state machine reusable for complex components.
/// By: NeilDG
/// </summary>
public abstract class StateMachine {

	private AState initialState = null;
	private AState finalState = null;
	private AState currentState = null;

	private bool halted = false;
	private bool started = false;

	public void SetInitialState(AState state) {
		this.initialState = state;
	}

	public void SetFinalState(AState state) {
		this.finalState = state;
	}

	public void StartMachine() {
		this.currentState = this.initialState;

		if(this.currentState != null) {
			this.currentState.OnEnter();
		}
		else {
			Debug.LogError("Missing initial state. Are you sure you have added an initial state?");
		}
	}

	/// <summary>
	/// Immediately halts this machine.
	/// </summary>
	public void Halt() {
		this.halted = true;
	}

	/// <summary>
	/// Update function that can be put into Unity's update function
	/// </summary>
	public void OnUpdate() {
		if(this.started == false) {
			Debug.LogError("State machine has not been started! Call StartMachine() first!");
			return;
		}

		if(this.halted == true) {
			Debug.Log("Machine halted.");
			return;
		}

		if(this.currentState != null) {
			this.currentState.OnUpdate();
		}
	}

	/// <summary>
	/// Transitions the current state to its next state. Will not transition if the current state do not have any next state!
	/// </summary>
	public void Transition() {
		this.currentState.OnExit();

		if(this.currentState.HasNextState()) {
			this.currentState = this.currentState.GetNextState();
			this.currentState.OnEnter();
		}
	}

	/// <summary>
	/// Transitions the current state to its previous state. By theory, FSMs do not move back to its previous state (one should point the next state
	/// towards its supposedly previous state). Use with caution.
	/// </summary>
	public void MoveBack() {
		this.currentState.OnExit();

		if(this.currentState.HasPreviousState()) {
			this.currentState = this.currentState.GetPreviousState();
			this.currentState.OnEnter();
		}
	}

	/// <summary>
	/// Put all state initialization and state transitions here!
	/// </summary>
	public abstract void InitializeStateTransitions();
}
