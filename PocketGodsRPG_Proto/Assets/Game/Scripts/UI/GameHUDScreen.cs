using UnityEngine;
using System.Collections;

/// <summary>
/// Temporary game hud screen
/// By: NeilDG
/// </summary>
public class GameHUDScreen : MonoBehaviour {

	public const string UNIT_POSITION_KEY = "UNIT_POSITION_KEY";

	[SerializeField] private HPBarElement hpBarPrefab;

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver(EventNames.ON_RETRIEVE_UNIT_POSITION, this.OnReceiveUnitPosition);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveObserver(EventNames.ON_RETRIEVE_UNIT_POSITION);
	}

	public void OnAttackButtonClicked() {
		BattleInputController.Instance.ActivateTargeting();
		EventBroadcaster.Instance.PostEvent(EventNames.ON_USER_SELECTED_SKILL);
	}

	private void OnReceiveUnitPosition(Parameters parameters) {
		Vector3 unitPos = (Vector3) parameters.GetObjectExtra(UNIT_POSITION_KEY);

		//instantiate hp bar prefab.
	}
}
