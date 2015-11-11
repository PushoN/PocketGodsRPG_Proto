using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Temporary game hud screen
/// By: NeilDG
/// </summary>
public class GameHUDScreen : MonoBehaviour {

	public const string CONTROLLABLE_UNIT_KEY = "CONTROLLABLE_UNIT_KEY";
	public const string UNIT_POSITION_KEY = "UNIT_POSITION_KEY";

	[SerializeField] private HPBarElement hpBarPrefab;

	[SerializeField] private List<HPBarElement> hpBarList;
	// Use this for initialization
	void Start () {
		this.hpBarList = new List<HPBarElement>();
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
		Vector3 viewportPos = (Vector3) parameters.GetObjectExtra(UNIT_POSITION_KEY);
		Vector3 unitPos = Vector3.zero;
		unitPos.x = viewportPos.x * UIStats.Instance.GetReferenceWidth();
		unitPos.y = viewportPos.y * UIStats.Instance.GetReferenceHeight();

		ControllableUnit unit = (ControllableUnit) parameters.GetObjectExtra(CONTROLLABLE_UNIT_KEY);

		//instantiate hp bar prefab.
		HPBarElement hpBar = GameObject.Instantiate(hpBarPrefab) as HPBarElement;
		hpBar.transform.gameObject.name = this.hpBarPrefab.name;
		hpBar.transform.localPosition = unitPos;
		hpBar.transform.SetParent(this.transform, false);
		hpBar.AssignControllableUnit(unit);

		this.hpBarList.Add(hpBar);

	}
}
