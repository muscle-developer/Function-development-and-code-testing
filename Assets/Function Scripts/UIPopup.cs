using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIPopup : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    private Coroutine uiAnimationCoroutine;

    public virtual void Open()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(FadeInCoroutine());
    }

    public virtual void Refresh()
	{
		// 이곳에서는 아무기능도 하지 않는다.
        // 각각의 팝업에서 알맞은 용도로 Refresh를 사용하자.
	}

    public virtual void Close()
	{
        StartCoroutine(FadeOutCoroutine());
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
        float duration = 0.5f;
        float elapsedTime = 0f;
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
