using UnityEngine;
using System.Collections;

public interface ITouchable {
	void OnTouch();
}

public interface IMoveable {
	void OnDragged(float deltaX, float deltaY);
	void OnReleased();
}
