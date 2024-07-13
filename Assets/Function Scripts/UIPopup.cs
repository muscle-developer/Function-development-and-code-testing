using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIPopup : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Coroutine uiAnimationCoroutine = null;
    public enum UIAnimationType {NONE, SLIDE, SCALE, ROTATE};
    
    [SerializeField]
	public UIAnimationType animationType = UIAnimationType.NONE;

    // 만들어지는 팝업에 캔버스 그룹을 추가해줘서 애니효과가 작동되도록
    public virtual void Awake()
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public virtual void Open()
    {
        this.gameObject.SetActive(true);

        // if(animationType == PopupAnimationType.TRANSITION || animationType == PopupAnimationType.TRANSITION_THEN_ALPHA)
		// 	animationCoroutine = StartCoroutine(RunPopupOpenTransionCoroutine(foreSkip));
		// else if(animationType == PopupAnimationType.ALPHA)
		// 	animationCoroutine = StartCoroutine(RunPopupOpenAlphaCoroutine(foreSkip));
		// else if(animationType == PopupAnimationType.SPREAD)
		// 	animationCoroutine = StartCoroutine(RunPopupOpenCoroutine(foreSkip));
		// else
		// 	animationCoroutine = StartCoroutine(RunPopupOpenCoroutine(true));

        uiAnimationCoroutine = StartCoroutine(FadeInCoroutine());
    }

    public virtual void Refresh()
	{
		// 이곳에서는 아무기능도 하지 않는다.
        // 각각의 팝업에서 알맞은 용도로 Refresh를 사용하자.
	}

    public virtual void Close()
	{
        if (uiAnimationCoroutine != null)
        {
            StartCoroutine(FadeOutCoroutine());
            uiAnimationCoroutine = null;
        }
	}

    // 닫기 기능
    protected virtual void ClosePopup(bool foreSkip = false)
    {
        // 열리고 있는중이거나, 닫히는중이면 실행하지 않는다.
        if(!this.gameObject.activeSelf)
			return;

		this.gameObject.SetActive(false);
    }

    private IEnumerator FadeInCoroutine()
    {
        float duration = 0.5f; // 지속시간
        float elapsedTime = 0f; // 경과 시간
        canvasGroup.alpha = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

    private IEnumerator FadeOutCoroutine()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        canvasGroup.alpha = 1f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(1f - (elapsedTime / duration));
            yield return null;
        }

        canvasGroup.alpha = 0f;
        ClosePopup();
    }
}
