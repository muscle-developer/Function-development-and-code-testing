using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//노치(다이내믹 아일랜드) 디바이스와 같은 특수 화면비(1:1 이하, 2:1 이상)에 대한 UI 안전 영역(Safe Zone) 조정을 담당한다.
public class SafeZoneModifier : MonoBehaviour
{
    [SerializeField]
    private List<CanvasScaler> canvasScalers;
    [Header("Scaling for < 1:1")]
    [SerializeField]
    private float safezoneHeight = 80f;
    [SerializeField]
    private List<RectTransform> safeZonePortraitUIList;
    [SerializeField]
    private List<RectTransform> safeZoneReversePortraitUIList;

    [Header("Scaling for > 2:1")]
    [SerializeField]
    protected float safezoneWidth = 80f;
    [SerializeField]
    private List<RectTransform> safeZoneAdjustedUIList;
    [SerializeField]
    private List<RectTransform> safeZoneReverseAdjustedUIList;
    
    private void Awake()
    {
        OnRectTransformDimensionsChange();
    }

    // 해상도 변경에 따라 UI 조절
    protected virtual void OnRectTransformDimensionsChange()
    {
        // 노치 관련 대응
        ApplySafezone();
    }

    private void ApplySafezone()
    {

        var screenRatio = (float)Screen.width / (float)Screen.height;
        // 세로 일 때 safezone 80
        if(screenRatio <= 1f)
        {
            // screenRatio = 1f / screenRatio;
            foreach(var item in safeZonePortraitUIList)
            {
                item.offsetMin = new Vector2(0f, safezoneHeight);
                item.offsetMax = new Vector2(0f, -safezoneHeight);
            }
            foreach(var item in safeZoneReversePortraitUIList)
            {
                item.offsetMin = new Vector2(-safezoneWidth, -safezoneHeight);
                item.offsetMax = new Vector2(safezoneWidth, safezoneHeight);
            }
            foreach(var item in safeZoneReverseAdjustedUIList)
            {
                item.offsetMin = new Vector2(0f, item.offsetMin.y);
                item.offsetMax = new Vector2(0f, 20.0f);
            }
        }
        // 2 : 1 이상일 때 가로 safezone 80
        if(screenRatio >= 2f)
        {
            // Apply safezone offset to deal with notch devices
            foreach(var item in safeZoneAdjustedUIList)
            {
                item.offsetMin = new Vector2(safezoneWidth, 0f);
                item.offsetMax = new Vector2(-safezoneWidth, 0f);
            }
            foreach(var item in safeZoneReverseAdjustedUIList)
            {
                item.offsetMin = new Vector2(-safezoneWidth, item.offsetMin.y);
                item.offsetMax = new Vector2(safezoneWidth, item.offsetMax.y);
            }
        }
        // 기본 값
        if(screenRatio > 1f && screenRatio < 2f)
        {
            // Revert safezone offset to deal with notch devices
            foreach(var item in safeZoneAdjustedUIList)
            {
                item.offsetMin = new Vector2(0f, 0f);
                item.offsetMax = new Vector2(0f, 0f);
            }
            foreach(var item in safeZoneReverseAdjustedUIList)
            {
                item.offsetMin = new Vector2(0f, item.offsetMin.y);
                item.offsetMax = new Vector2(0f, item.offsetMax.y);
            }
        }
    }
}
