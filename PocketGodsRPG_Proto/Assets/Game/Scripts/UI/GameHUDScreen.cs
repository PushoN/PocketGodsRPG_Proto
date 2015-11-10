using UnityEngine;
using System.Collections;

/// <summary>
/// Temporary game hud screen
/// By: NeilDG
/// </summary>
public class GameHUDScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void OnAttackButtonClicked() {
		BattleInputController.Instance.ActivateTargeting();
		EventBroadcaster.Instance.PostEvent(EventNames.ON_USER_SELECTED_SKILL);
	}
}
