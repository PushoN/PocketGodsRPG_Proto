using UnityEngine;
using System.Collections;

/// <summary>
/// Representation of a FSM state
/// 
/// By: NeilDG
/// </summary>
public abstract class AState  {

	private AState previousState = null;
	private AState nextState = null;

	private string stateLabel = null;

	public abstract void OnEnter();
	public abstract void OnUpdate();
	public abstract void OnExit();

	public void SetLabel(string name) {
		this.stateLabel = name;
	}

	public string GetLabel() {
		return this.stateLabel;
	}

	public void AddTransition(AState previousState, AState nextState) {
		this.previousState = previousState;
		this.nextState = nextState;
	}

	public AState GetNextState() {
		return this.nextState;
	}

	public AState GetPreviousState() {
		return this.previousState;
	}

	public bool HasNextState() {
		return (this.nextState != null);
	}

	public bool HasPreviousState() {
		return (this.previousState != null);
	}
}
