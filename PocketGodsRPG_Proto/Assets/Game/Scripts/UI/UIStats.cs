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

	private RectTransform rectTransform;

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
		this.rectTransform = this.GetComponent<RectTransform>();
	}

	public float GetReferenceWidth() {
		return this.rectTransform.rect.width;
	}

	public float GetReferenceHeight() {
		return this.rectTransform.rect.height;
	}
}
