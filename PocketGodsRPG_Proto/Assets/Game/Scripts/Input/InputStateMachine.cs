using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the state machine for the input handling
/// By: Neil DG
/// </summary>
public class InputStateMachine : AStateMachine {

	public const string NO_INPUT_STATE = "NO_INPUT_STATE";
	public const string MOUSE_DOWN_STATE = "MOUSE_DOWN_STATE";
	public const string DRAG_WORLD_STATE = "DRAG_WORLD_STATE";

	public const string FINGER_POINTER_KEY = "FINGER_POINTER_KEY";

	private Camera gameCamera;

	private NoInputState noInputState;
	private MouseDownState mouseDownState;
	private DragWorldState dragWorldState;

	public InputStateMachine(Camera gameCamera) {
		this.gameCamera = gameCamera;

	}

	public override void InitializeStateTransitions ()
	{
		this.noInputState = new NoInputState(NO_INPUT_STATE, this);
		this.noInputState.AssignGameCamera(this.gameCamera);
		this.SetInitialState(this.noInputState);

		this.dragWorldState = new DragWorldState(DRAG_WORLD_STATE, this);
		this.dragWorldState.AssignGameCamera(this.gameCamera);

		this.noInputState.AddTransition(DRAG_WORLD_STATE, this.dragWorldState);
		this.dragWorldState.AddTransition(NO_INPUT_STATE, this.noInputState);
	}
}
