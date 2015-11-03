using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a moveable object like buildings. Automatically has the ITouchable implementation alongside
/// IMoveable
/// 
/// By: NeilDG
/// </summary>
public class MoveableObject : MonoBehaviour, ITouchable, IMoveable {

	// Use this for initialization
	void Start () {
	
	}

	public void OnTouch() {
		Debug.Log(this.gameObject.name + " was touched!");
	}

	public void OnDragged(float deltaX, float deltaY) {
		Vector3 objectPos = this.transform.localPosition;
		objectPos.x += deltaX;
		objectPos.y += deltaY;

		this.transform.localPosition = objectPos;
	}

	public void OnReleased() {
		Debug.Log(this.gameObject.name + " was released!");
	}
}
