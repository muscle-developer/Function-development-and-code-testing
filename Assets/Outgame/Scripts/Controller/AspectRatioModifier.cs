using UnityEngine;

// AspectRatioModifier은 게임 화면 내 UI 조정 - 메인 화면에 보이는 UI조정
public class AspectRatioModifier : MonoBehaviour
{
    [SerializeField]
    private float safezonePadding = 80f; // 가로/세로 공통 패딩값
    [SerializeField]
    private RectTransform infoImage;   // 정보창
    [SerializeField]
    private RectTransform profileInfoImage; // 플레이어 정보창

    private void Awake()
    {
        OnRectTransformDimensionsChange();
    }

    // 해상도 변경에 따라 UI 조절
    private void OnRectTransformDimensionsChange()
    {
        // 화면이 가로형인지 세로형인지 자동 판별
        bool isLandscape = Screen.width >= Screen.height; // 가로 모드인지 확인

        // 현재 화면이 가로 모드인지 세로 모드인지에 따라 화면 비율(screenRatio) 계산
        float screenRatio = isLandscape 
            ? (float)Screen.width / Screen.height  // 가로형 게임
            : (float)Screen.height / Screen.width; // 세로형 게임

        float screenRatioWithSafezone = screenRatio;

        // 만약 화면 비율이 2:1 이상 (넓은 화면, 예: 울트라 와이드, 다이내믹 아일랜드 등)이라면
        if (screenRatio >= 2f)
        {
            screenRatioWithSafezone = isLandscape 
                ? (float)(Screen.width - safezonePadding * 2f) / Screen.height  // 가로 모드에서 패딩을 빼고 다시 계산
                : (float)(Screen.height - safezonePadding * 2f) / Screen.width; // 세로 모드에서 패딩을 빼고 다시 계산
        }

        // 와이드 화면 (예: 17:10 이상)
        if (screenRatioWithSafezone > 1.7f)
        {
            infoImage.sizeDelta = new Vector2(200, 100);
            profileInfoImage.sizeDelta = new Vector2(500, 310);
        }
        // 일반 화면 (예: 16:10 이하)
        else
        {
            infoImage.sizeDelta = new Vector2(300, 200);
            profileInfoImage.sizeDelta = new Vector2(300, 310);
        }

        // 정보창 위치 조정
        // 가로 모드: 중앙 유지
        if (isLandscape)
        {
            infoImage.anchorMin = new Vector2(0.5f, 1f);
            infoImage.anchorMax = new Vector2(0.5f, 1f);
            infoImage.pivot = new Vector2(0.5f, 1f);
            infoImage.anchoredPosition = new Vector2(0, 0); // 상단에서 safezonePadding만큼 아래로 내림
            infoImage.sizeDelta = new Vector2(300, 200);
        }
        // 세로 모드: 우측 상단 고정
        else
        {
            infoImage.anchorMin = new Vector2(1f, 1f);
            infoImage.anchorMax = new Vector2(1f, 1f);
            infoImage.pivot = new Vector2(1f, 1f);
            infoImage.anchoredPosition = new Vector2(-safezonePadding, -safezonePadding); // 우측 상단 여백
            infoImage.sizeDelta = new Vector2(200, 100);
        }
    }
}
