using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

/// <summary>
/// Represents the basic user interface customized for BC. Heavily referenced from Dragon Cubes UI
/// 
/// By: NeilDG
/// </summary>
public class View : MonoBehaviour {

	[SerializeField] private bool asRootScreen = false;
	[SerializeField] protected RectTransform rectTransform;
	[SerializeField] private DOTViewAnimation.EntranceType entranceType;
	[SerializeField] private DOTViewAnimation.ExitType exitType;

	private IViewAnimation viewAnimation;

	protected bool cancelable = true;
	private bool destroyable = true;
	private bool hasAttachedSounds = false;

	private List<Button> buttonList = null;

	public virtual void Show() {

		if(this.viewAnimation == null) {
			DOTViewAnimation hoViewAnimation = new DOTViewAnimation(this.rectTransform,this);
			hoViewAnimation.SetAnimationType(this.entranceType, this.exitType);
			
			this.viewAnimation = hoViewAnimation;
		}

		this.Reset();
		this.OnShowStarted();

		if(this.viewAnimation != null) {
			this.viewAnimation.PerformEntrance();
		}

	}

	public virtual void Hide() {
		this.OnHideStarted();

		if(this.viewAnimation != null) {
			this.viewAnimation.PerformExit();
		}
		else {
			this.OnHideCompleted();
		}
	}

	public void SetCancelable(bool flag) {
		this.cancelable = flag;
	}

	public bool IsCancelable() {
		return this.cancelable;
	}

	private void Reset() {
		this.SetVisibility(true);

		this.transform.position = Vector3.zero;
		this.transform.localScale = Vector3.one;
		this.transform.rotation = Quaternion.identity;

		this.rectTransform.anchorMin = Vector2.zero;
		this.rectTransform.anchorMax = Vector2.one;
		this.rectTransform.offsetMax = this.rectTransform.offsetMin = Vector2.zero;
		this.rectTransform.pivot = new Vector2(0.5f, 0.5f);
	}

	private void PopulateButtonList(Transform parent) {
		if(this.buttonList == null) {
			this.buttonList = new List<Button>();
		}

		foreach(Transform child in parent) {
			Button button = child.GetComponent<Button>();

			if(button != null) {
				this.buttonList.Add(button);
			}

			this.PopulateButtonList(child);
		}

	}

	public void ToggleAllButtons(bool flag) {
		if(this.buttonList == null) {
			return;
		}

		foreach(Button button in this.buttonList) {
			if(button == null) continue;
			button.enabled = flag;
		}
	}
	
	public string GetName() {
		return this.gameObject.name;
	}

	public bool IsRootScreen() {
		return this.asRootScreen;
	}

	public void DoNotDestroy() {
		this.destroyable = false;
	}
	
	public void MakeDestroyable() {
		this.destroyable = true;
	}
	
	public bool ShouldBeDestroyed() {
		return this.destroyable;
	}

	public void SetVisibility(bool flag) {
		this.gameObject.SetActive(flag);
	}

	/// <summary>
	/// Copies the properties from a view to the next view.
	/// </summary>
	/// <param name="view">View.</param>
	public void CopyProperty(View view) {
		this.rectTransform = view.GetComponent<RectTransform>();

		/*this.entranceType = view.entranceType;
		this.exitType = view.exitType;

		HOViewAnimation hoViewAnimation = new HOViewAnimation(this.rectTransform,this);
		hoViewAnimation.SetAnimationType(this.entranceType, this.exitType);
		
		this.viewAnimation = hoViewAnimation;*/
	}

	#region View events
	public virtual void OnShowStarted() {
		ViewHandler.Instance.RestrictUIActions();
		this.ToggleAllButtons(false);

		Debug.Log ("View show started");
	}
	public virtual void OnShowCompleted() {
		ViewHandler.Instance.AllowUIActions();
		this.ToggleAllButtons(true);

		Debug.Log ("View show completed");
	}
	public virtual void OnBackButtonPressed() {}
	public virtual void OnHideStarted() {
		ViewHandler.Instance.RestrictUIActions();
		this.ToggleAllButtons(false);

		Debug.Log ("View show hide started");
	}
	public virtual void OnHideCompleted() {
		ViewHandler.Instance.OnViewHidden(this);

		Debug.Log ("View show hide completed");
	}
	#endregion

}
