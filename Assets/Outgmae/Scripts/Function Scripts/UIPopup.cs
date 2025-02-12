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

    [Header("Slide && Scale && Rotate")]
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    // 만들어지는 팝업에 캔버스 그룹을 추가해줘서 애니효과가 작동되도록
    public virtual void Awake()
    { 
        // None
        canvasGroup = gameObject.AddComponent<CanvasGroup>();

        // Slide && Scale
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public virtual void Open()
    {
        this.gameObject.SetActive(true);

        if(animationType == UIAnimationType.SLIDE)
            uiAnimationCoroutine = StartCoroutine(SlideInCoroutine());    
        else if(animationType == UIAnimationType.SCALE)
            uiAnimationCoroutine = StartCoroutine(ScaleInCoroutine());
        else if(animationType == UIAnimationType.ROTATE)
            uiAnimationCoroutine = StartCoroutine(RotateInCoroutine());
        else 
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
			StopCoroutine(uiAnimationCoroutine);

            if(animationType == UIAnimationType.SLIDE)
                StartCoroutine(SlideOutCoroutine());
            else if(animationType == UIAnimationType.SCALE)
                StartCoroutine(ScaleOutCoroutine());
            else if(animationType == UIAnimationType.ROTATE)
                StartCoroutine(RotateOutCoroutine());
            else 
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

    // None - Fade 애니메이션
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

    // Slide - Slide 애니메이션
    private IEnumerator SlideInCoroutine()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        // Y축 좌표는 위로 갈수록 양의 값이고, 아래로 갈수록 음의 값이기때문에 따라서, -rectTransform.rect.height를 사용하여 팝업이 화면 아래쪽으로 완전히 내려가도록 설정
        Vector2 startPosition = new Vector2(originalPosition.x, -rectTransform.rect.height); 

        rectTransform.anchoredPosition = startPosition;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // 아래서 시작(startPosition) -> 원래 위치(originalPosition = (0,0))값으로 이동
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, originalPosition, elapsedTime / duration);
            yield return null;
        }

        rectTransform.anchoredPosition = originalPosition;
    }

    private IEnumerator SlideOutCoroutine()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Vector2 endPosition = new Vector2(originalPosition.x, -rectTransform.rect.height);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            rectTransform.anchoredPosition = Vector2.Lerp(originalPosition, endPosition, elapsedTime / duration);
            yield return null;
        }

        rectTransform.anchoredPosition = endPosition;
        ClosePopup();
    }

    // Scale - Scale 애니메이션
    private IEnumerator ScaleInCoroutine()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Vector3 startScale = new Vector3(0f, 0f, 1f);
        Vector3 endScale = new Vector3(1f, 1f, 1f);

        rectTransform.localScale = startScale;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            rectTransform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            yield return null;
        }

        rectTransform.localScale = endScale;
    }

    private IEnumerator ScaleOutCoroutine()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        Vector3 startScale = new Vector3(1f, 1f, 1f);
        Vector3 endScale = new Vector3(0f, 0f, 1f);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            rectTransform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            yield return null;
        }

        rectTransform.localScale = endScale;
        ClosePopup();
    }

    // Rotate - Rotate 애니메이션
    private IEnumerator RotateInCoroutine()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        float startAngle = 0f;
        float endAngle = 360f;

        rectTransform.rotation = Quaternion.Euler(0f, 0f, startAngle);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, elapsedTime / duration);
            rectTransform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
            yield return null;
        }

        rectTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private IEnumerator RotateOutCoroutine()
    {
        float duration = 0.5f;
        float elapsedTime = 0f;
        float startAngle = 0f;
        float endAngle = -360f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, elapsedTime / duration);
            rectTransform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
            yield return null;
        }

        rectTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ClosePopup();
    }
}
