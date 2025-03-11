using UnityEngine;
using UnityEngine.UI;

// AspectRatioModifier은 게임 화면 내 UI 조정 - 메인 화면에 보이는 UI조정
public class AspectRatioModifier : MonoBehaviour
{
    [SerializeField]
    private float safezonePadding = 80f; // 가로/세로 공통 패딩값
    [SerializeField]
    private RectTransform infoImage;
    [SerializeField]
    private RectTransform hpBar;
    [SerializeField]
    private RectTransform nickNameImage;

    private void Awake()
    {
        OnRectTransformDimensionsChange();
    }

    // 해상도 변경에 따라 UI 조절
    private void OnRectTransformDimensionsChange()
    {
        // 화면이 가로형인지 세로형인지 자동 판별
        bool isLandscape = Screen.width >= Screen.height; // 가로 모드인지 확인

        float screenRatio = isLandscape 
            ? (float)Screen.width / Screen.height  // 가로형 게임
            : (float)Screen.height / Screen.width; // 세로형 게임

        float screenRatioWithSafezone = screenRatio;

        if (screenRatio >= 2f)
        {
            screenRatioWithSafezone = isLandscape 
                ? (float)(Screen.width - safezonePadding * 2f) / Screen.height 
                : (float)(Screen.height - safezonePadding * 2f) / Screen.width;
        }

        // 와이드 화면 (예: 17:10 이상)
        if (screenRatioWithSafezone > 1.7f)
        {
            infoImage.sizeDelta = new Vector2(300, 200);
            hpBar.sizeDelta = new Vector2(500, 100);
            nickNameImage.sizeDelta = new Vector2(400, 200);
        }
        // 일반 화면 (예: 16:10 이하)
        else
        {
            infoImage.sizeDelta = new Vector2(200, 100);
            hpBar.sizeDelta = new Vector2(300, 100);
            nickNameImage.sizeDelta = new Vector2(300, 200);
        }
    }
}
