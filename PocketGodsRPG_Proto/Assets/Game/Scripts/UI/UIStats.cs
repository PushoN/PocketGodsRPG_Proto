using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Holds reference for needed statistics
/// </summary>
public class UIStats : MonoBehaviour {
	private static UIStats sharedInstance = null;
	public static UIStats Instance {
		get {
			return sharedInstance;
		}
	}

	[SerializeField] private Canvas mainUICanvas;
	[SerializeField] private CanvasScaler canvasScaler;

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
	
	}

	public float GetReferenceWidth() {
		return this.canvasScaler.referenceResolution.x;
	}

	public float GetReferenceHeight() {
		return this.canvasScaler.referenceResolution.y;
	}
}
