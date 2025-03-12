using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 노치(다이내믹 아일랜드) 디바이스와 같은 특수 화면비(1:1 이하, 2:1 이상)에 대한 UI 안전 영역(Safe Zone) 조정을 담당한다.
public class SafeZoneModifier : MonoBehaviour
{
    [SerializeField]
    private List<CanvasScaler> canvasScalers; // UI 스케일링을 적용할 CanvasScaler 목록

    [Header("Scaling for < 1:1 - 세로 모드")]
    [SerializeField]
    private float safezoneHeight = 80f; // 세로 모드에서 적용할 Safe Zone 높이 값
    [SerializeField]
    private List<RectTransform> safeZonePortraitUIList; // 세로 모드에서 Safe Zone을 적용할 UI 요소 목록

    [Header("Scaling for > 2:1 - 가로 모드")]
    [SerializeField]
    protected float safezoneWidth = 80f; // 가로 모드에서 적용할 Safe Zone 너비 값
    [SerializeField]
    private List<RectTransform> safeZoneAdjustedUIList; // 가로 모드에서 Safe Zone을 적용할 UI 요소 목록

    private void Awake()
    {
        // 화면이 변경될 경우 Safe Zone을 적용한다.
        OnRectTransformDimensionsChange();
    }

    // 해상도 변경 감지 시 UI 조정
    protected virtual void OnRectTransformDimensionsChange()
    {
        // 노치 대응을 위해 Safe Zone 적용
        ApplySafezone();
    }

    // 화면 비율에 따라 Safe Zone을 적용하는 함수
    private void ApplySafezone()
    {
        var screenRatio = (float)Screen.width / (float)Screen.height; // 현재 화면의 가로 세로 비율 계산

        // 세로 모드 (1:1 이하)
        if (screenRatio <= 1f)
        {
            // Safe Zone을 적용하여 UI가 너무 화면 모서리에 붙지 않도록 조정
            foreach (var item in safeZonePortraitUIList)
            {
                item.offsetMin = new Vector2(0f, safezoneHeight);  // 아래쪽 여백 추가
                item.offsetMax = new Vector2(0f, -safezoneHeight); // 위쪽 여백 추가
            }
        }

        // 가로 모드 (2:1 이상)
        if (screenRatio >= 2f)
        {
            // 노치가 있는 기기에서 UI가 가려지는 것을 방지하기 위해 좌우 여백을 적용
            foreach (var item in safeZoneAdjustedUIList)
            {
                item.offsetMin = new Vector2(safezoneWidth, 0f);  // 왼쪽 여백 추가
                item.offsetMax = new Vector2(-safezoneWidth, 0f); // 오른쪽 여백 추가
            }
        }

        // 일반적인 화면 비율 (1:1 초과 ~ 2:1 미만)
        if (screenRatio > 1f && screenRatio < 2f)
        {
            // Safe Zone을 초기화하여 UI가 기본 위치로 돌아가도록 설정
            foreach (var item in safeZoneAdjustedUIList)
            {
                item.offsetMin = new Vector2(0f, 0f);
                item.offsetMax = new Vector2(0f, 0f);
            }
        }
    }
}
