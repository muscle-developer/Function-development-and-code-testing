using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutgameController : MonoBehaviour
{
    public static OutgameController Instance;

    [Header("UI Popup")]
    [SerializeField]
    private List<TestPopup> testPopupList;
    [SerializeField]
    private UIViewPowerSaving uiViewPowerSaving;
    [SerializeField]
    private PressedPopup uiPressedPopup;

    private void Awake()
	{
        // 싱글톤 패턴 구현
        Instance = this;
	}

    void Start()
    {
        StartCoroutine(LogicOnEverySecondCoroutine());
    }

    private IEnumerator LogicOnEverySecondCoroutine()
    {
        // 앱이 시작된 후 경과된 실시간(초)을 정수로 저장
        var lastTime = (int)Time.realtimeSinceStartup;

        while (true) // 무한 루프를 실행
        {
            // 현재 경과된 실시간(초)을 정수로 저장
            var currentTime = (int)Time.realtimeSinceStartup;

            // 현재 시간과 마지막 시간의 차이가 1초 이상인지 확인
            if (currentTime - lastTime >= 1)
            {
                // 절전 모드가 활성화되어 있는 경우 시간 정보를 갱신
                if (uiViewPowerSaving.IsOn)
                {
                    uiViewPowerSaving.RefreshTimeInfo();
                }

                // 마지막 시간 값을 현재 시간으로 업데이트
                lastTime = currentTime;
            }

            // 다음 프레임까지 대기
            yield return null;
        }
    }


    public void OpenTestPopup()
    {
        if (testPopupList[0] != null)
            testPopupList[0].gameObject.SetActive(true);
            
        testPopupList[0].Open();
    }

    public void OpenSlideTestPopup()
    {
        if (testPopupList[1] != null)
            testPopupList[1].gameObject.SetActive(true);
            
        testPopupList[1].Open();
    }

    public void OpenScaleTestPopup()
    {
        if (testPopupList[2] != null)
            testPopupList[2].gameObject.SetActive(true);
            
        testPopupList[2].Open();
    }

    public void OpenRotateTestPopup()
    {
        if (testPopupList[3] != null)
            testPopupList[3].gameObject.SetActive(true);
            
        testPopupList[3].Open();
    }

    public void OpenPowerSavingPopup()
    {
        uiViewPowerSaving.StartPowerSavingMode();   
    }

    public void OpenPressedPopup()
    {
        uiPressedPopup.Open();   
    }
}
