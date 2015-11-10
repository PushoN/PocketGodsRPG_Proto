using UnityEngine;
using System.Collections;

/// <summary>
/// Handles input such as targeting when any of the UI skills has been clicked
/// </summary>
public class BattleInputController : MonoBehaviour {

	private static BattleInputController sharedInstance = null;
	public static BattleInputController Instance {
		get {
			return sharedInstance;
		}
	}

	[SerializeField] private Camera gameCamera;

	private bool activated = false;
	private ControllableUnit controllableUnit;

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.activated == false) {
			return;
		}

		if(Input.GetMouseButtonDown(0)) {
			Ray ray = this.gameCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				this.ProcessMouseDown(hit.collider);
			}
			else {
				this.ProcessMouseDown(null);
			}
		}
	}

	public void ActivateTargeting() {
		this.activated = true;
	}

	public void DeactivateTargeting() {
		this.activated = false;
	}

	private void ProcessMouseDown(Collider hitObject) {
		if(hitObject != null) {

			ControllableUnit controllableUnit = hitObject.gameObject.GetComponent<ControllableUnit>();

			if(controllableUnit != null) {
				this.controllableUnit = controllableUnit;
				this.activated = false;
			}

		}
		else {
			Debug.Log ("No object hit. Deactivating input controller.");
			this.activated = false;
		}

	}

	public ControllableUnit GetLastTouchedUnit() {
		return this.controllableUnit;
	}

	public bool HasTouchedControllableUnit() {
		return (this.controllableUnit != null);
	}
}
