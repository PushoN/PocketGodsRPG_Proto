using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class DOTViewAnimation : IViewAnimation {

	private const float POSITION_OFFSET = 1000.0f;
	private const float HIDE_SPEED = 0.5f;
	private const Ease TWEEN_EASE_TYPE = Ease.InCubic;

	public enum EntranceType
	{
		FROM_TOP,
		FROM_MID,
		FROM_BOT,
		FROM_RIGHT,
		FROM_LEFT,
		NONE
	}
	
	public enum ExitType
	{
		TO_TOP,
		TO_MID,
		TO_BOT,
		TO_RIGHT,
		TO_LEFT,
		NONE
	}

	private RectTransform rectTransform;
	private View view;
	private EntranceType entranceType;
	private ExitType exitType;

	public void SetAnimationType(EntranceType entranceType, ExitType exitType) {
		this.entranceType = entranceType;
		this.exitType = exitType;
	}

	public DOTViewAnimation(RectTransform rectTransform, View view) {
		this.rectTransform = rectTransform;
		this.view = view;
	}

	public void PerformEntrance() {
		
		switch(this.entranceType)
		{
		case EntranceType.FROM_TOP   : this.ShowFromTop(); 	 break;
		case EntranceType.FROM_MID   : this.ShowFromCenter(); break;
		case EntranceType.FROM_BOT   : this.ShowFromBottom(); break;
		case EntranceType.FROM_RIGHT : this.ShowFromRight();  break;
		case EntranceType.FROM_LEFT  : this.ShowFromLeft();   break;
		default: 
			this.view.OnShowStarted();
			Debug.Log(this.rectTransform.name + " does not have a defined default entrance!"); break;
		}
		
	}
	
	public void PerformExit() {
		switch(this.exitType)
		{
		case ExitType.TO_TOP   : this.HideToTop();	 break;
		case ExitType.TO_MID   : this.HideToCenter(); break;
		case ExitType.TO_BOT   : this.HideToBottom(); break;
		case ExitType.TO_RIGHT : this.HideToRight();  break;
		case ExitType.TO_LEFT  : this.HideToLeft();   break;
		default: 
			this.view.OnShowCompleted();
			Debug.Log(this.rectTransform.name + " does not have a defined default exit!"); break;
		}
	}

	protected virtual void ShowFromTop(bool triggerOnComplete = true) {
		Vector3 targetPos = this.rectTransform.anchoredPosition3D;

		this.rectTransform.anchoredPosition3D = new Vector3(0.0f, POSITION_OFFSET, 0.0f);
		this.rectTransform.localScale = Vector3.one;

		Tweener tweener = this.rectTransform.DOMove(targetPos, HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();

		if(triggerOnComplete) {
			tweener.OnComplete(this.view.OnShowCompleted);
		}
	}

	protected virtual void ShowFromCenter(bool triggerOnComplete = true)
	{
		this.rectTransform.anchoredPosition3D = Vector3.zero;
		this.rectTransform.localScale = Vector3.zero;
		
		Tweener tweener = this.rectTransform.DOScale(Vector3.one,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();

		if(triggerOnComplete)
		{
			tweener.OnComplete(this.view.OnShowCompleted);
		}

	}

	protected virtual void ShowFromBottom(bool triggerOnComplete = true)
	{
		Vector3 targetPos = this.rectTransform.anchoredPosition3D;

		this.rectTransform.anchoredPosition3D = new Vector3(0.0f, -POSITION_OFFSET, 0.0f);
		this.rectTransform.localScale = Vector3.one;
		
		Tweener tweener = this.rectTransform.DOMove(targetPos,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();
		
		if(triggerOnComplete)
		{
			tweener.OnComplete(this.view.OnShowCompleted);
		}

	}

	protected virtual void ShowFromRight(bool triggerOnComplete = true)
	{
		Vector3 targetPos = this.rectTransform.anchoredPosition3D;

		this.rectTransform.anchoredPosition3D = new Vector3(POSITION_OFFSET, 0.0f, 0.0f);
		this.rectTransform.localScale = Vector3.one;

		Tweener tweener = this.rectTransform.DOMove(targetPos,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();

		if(triggerOnComplete) {
			tweener.OnComplete(this.view.OnShowCompleted);
		}
	}

	protected virtual void ShowFromLeft(bool triggerOnComplete = true)
	{
		Vector3 targetPos = this.rectTransform.anchoredPosition3D;

		this.rectTransform.anchoredPosition3D = new Vector3(-POSITION_OFFSET, 0.0f, 0.0f);
		this.rectTransform.localScale = Vector3.one;

		Tweener tweener = this.rectTransform.DOMove(targetPos,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();

		if(triggerOnComplete) {
			tweener.OnComplete(this.view.OnShowCompleted);
		}
	}

	protected virtual void HideToTop(bool triggerOnComplete = true)
	{
		int pos = Mathf.FloorToInt(this.rectTransform.anchoredPosition3D.y);
		if(pos >= Mathf.FloorToInt(POSITION_OFFSET))
		{
			if(triggerOnComplete)
			{
				this.view.OnHideCompleted();
			}
			
			return;
		}
		
		Vector3 hidePos = new Vector3(0.0f, POSITION_OFFSET, 0.0f);
		this.rectTransform.anchoredPosition3D = Vector3.zero;

		Tweener tweener = this.rectTransform.DOMove(hidePos,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();

		
		if(triggerOnComplete)
		{
			tweener.OnStepComplete(this.view.OnHideCompleted);
		}
	}

	protected virtual void HideToCenter(bool triggerOnComplete = true)
	{
		int scale = Mathf.FloorToInt(this.rectTransform.localScale.x);
		if(scale <= 0)
		{
			if(triggerOnComplete)
			{
				this.view.OnHideCompleted();
			}
			
			return;
		}
		
		this.rectTransform.anchoredPosition3D = Vector3.zero;
		this.rectTransform.localScale = Vector3.one;
		
		Tweener tweener = this.rectTransform.DOScale(Vector3.zero,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();
		
		if(triggerOnComplete)
		{
			tweener.OnStepComplete(this.view.OnHideCompleted);
		}

	}

	protected virtual void HideToBottom(bool triggerOnComplete = true)
	{
		int pos = Mathf.FloorToInt(this.rectTransform.anchoredPosition3D.y);
		if(pos <= -Mathf.FloorToInt(POSITION_OFFSET))
		{
			if(triggerOnComplete)
			{
				this.view.OnHideCompleted();
			}
			
			return;
		}
		
		Vector3 hidePos = new Vector3(0.0f, -POSITION_OFFSET, 0.0f);
		this.rectTransform.anchoredPosition3D = Vector3.zero;
		
		Tweener tweener = this.rectTransform.DOMove(hidePos,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();
		
		if(triggerOnComplete)
		{
			tweener.OnStepComplete(this.view.OnHideCompleted);
		}

	}

	protected virtual void HideToRight(bool triggerOnComplete = true)
	{
		int pos = Mathf.FloorToInt(this.rectTransform.anchoredPosition3D.x);
		if(pos >= Mathf.FloorToInt(POSITION_OFFSET))
		{
			if(triggerOnComplete)
			{
				this.view.OnHideCompleted();
			}
			
			return;
		}
		
		Vector3 hidePos = new Vector3(POSITION_OFFSET, 0.0f, 0.0f);
		this.rectTransform.anchoredPosition3D = Vector3.zero;

		Tweener tweener = this.rectTransform.DOMove(hidePos,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();
		
		if(triggerOnComplete)
		{
			tweener.OnStepComplete(this.view.OnHideCompleted);
		}

	}
	
	protected virtual void HideToLeft(bool triggerOnComplete = true)
	{
		int pos = Mathf.FloorToInt(this.rectTransform.anchoredPosition3D.x);
		if(pos <= -Mathf.FloorToInt(POSITION_OFFSET))
		{
			if(triggerOnComplete)
			{
				this.view.OnHideCompleted();
			}
			
			return;
		}
		
		Vector3 hidePos = new Vector3(-POSITION_OFFSET, 0.0f, 0.0f);
		this.rectTransform.anchoredPosition3D = Vector3.zero;
		
		Tweener tweener = this.rectTransform.DOMove(hidePos,HIDE_SPEED).SetEase(TWEEN_EASE_TYPE);
		tweener.Play();
		
		if(triggerOnComplete)
		{
			tweener.OnStepComplete(this.view.OnHideCompleted);
		}
	}


}
