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
        var lastTime = (int)Time.realtimeSinceStartup;
        while(true)
        {
            var currentTime = (int)Time.realtimeSinceStartup;

            if(currentTime - lastTime >= 1)
            {
                // Check battery and internet connection
                if(uiViewPowerSaving.IsOn)
                {
                    uiViewPowerSaving.RefreshTimeInfo();
                    uiViewPowerSaving.RefreshBatteryInfo();
                    uiViewPowerSaving.RefreshWifiInfo();
                }

                lastTime = currentTime;
            }

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
}
