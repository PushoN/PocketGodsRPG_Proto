using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// An instantiable/inheritable state machine reusable for complex components.
/// By: NeilDG
/// </summary>
public abstract class AStateMachine {

	protected Dictionary<string, object> dataTable = new Dictionary<string, object>();

	protected AState initialState = null;
	protected AState currentState = null;

	private bool halted = false;
	private bool started = false;

	public void SetInitialState(AState state) {
		this.initialState = state;
	}

	/// <summary>
	/// Puts arbitrary data in the state machine. This is the lookup table for other states to get needed data.
	/// Replaces the data if a key provided is already existing.
	/// </summary>
	/// <param name="key">Key.</param>
	/// <param name="value">Value.</param>
	public void PutData(string key, object value) {
		if(this.dataTable.ContainsKey(key)) {
			this.dataTable.Remove(key);
		}

		this.dataTable.Add(key,value);
	}
	
	public object RetrieveData(string key) {
		if(this.dataTable.ContainsKey(key)) {
			return this.dataTable[key];
		}
		else {
			Debug.LogError(key+ " does not exist in the state machine data table!");
			return null;
		}
	}


	public void StartMachine() {
		this.currentState = this.initialState;

		if(this.currentState != null) {
			this.started = true;
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
	public void TransitionTo(string stateLabel) {
		this.currentState.OnExit();

		if(this.currentState.HasTransition(stateLabel)) {
			this.currentState = this.currentState.GetTransitionState(stateLabel);
			this.currentState.OnEnter();
		}
		else {
			Debug.LogError("Transition state " +stateLabel+ " does not exist in " +this.currentState.GetLabel());
		}
	}

	/// <summary>
	/// Put all state initialization and state transitions here!
	/// </summary>
	public abstract void InitializeStateTransitions();
}
