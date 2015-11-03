using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a touchable object. Normally seen on touchable structures but cannot be moved! Like trees in CoC.
/// By: NeilDG
/// </summary>
public class TouchableObject : MonoBehaviour, ITouchable {

	// Use this for initialization
	void Start () {
	
	}


	public void OnTouch() {
		Debug.Log (this.gameObject.name+ " was touched.");
	}
}
