using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class UIViewPowerSaving : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private List<Sprite> batterySpriteList;
    [SerializeField]
    private Image batteryInfoIcon;
    [SerializeField]
    private Image batteryGaugeImage;
    [SerializeField]
    private TMP_Text batteryInfoText;
    [SerializeField]
    private List<Sprite> wifiSignalSpriteList;
    [SerializeField]
    private Image wifiSignalInfoIcon;
    [SerializeField]
    private Transform mobileDataText;
    [SerializeField]
    private Slider offSlider;
    private float unlockThreshold = 1f;
    private float resetSpeed = 1.5f;
    private bool isLocked;
    public Coroutine resetCoroutine;

    [SerializeField]
    private int currentHours;
    [SerializeField]
    private int currentMin;
    [SerializeField]
    private int currentTimeSec;
    [SerializeField]
    private int playTime;

    [SerializeField]
    private TMP_Text powerSavingTime;
    private bool isOn = false;
    public bool IsOn{
        get{
            return isOn;
        }
    }

    private int originalCullingMask;

    public void StartPowerSavingMode()
    {
        if(this.isOn)
            return;
            
        this.isOn = true;
        this.offSlider.value = 0f;
        this.isLocked = true;

        SoundManager.Instance.MuteAll();

        UIManager.Instance.HideCanvas("Main Canvas");
        UIManager.Instance.ShowCanvas("Power Saving Canvas");

        originalCullingMask = mainCamera.cullingMask;
        mainCamera.cullingMask = 0;

        Reset();

        RefreshTimeInfo();
        RefreshBatteryInfo();
        RefreshWifiInfo();
        UpdateLockState();
    }

    // 절전모드 열릴 때 값들 초기화
    private void Reset()
    {
        playTime = 0;
        powerSavingTime.text = string.Format("{0:D2}", playTime);   
    }

    // public void TouchScreen()
    // {
    //     this.offCount = this.offCount - 1;

    //     if(this.offCount <= 0)
    //         FinishPowerSavingMode();
    // }

    public void OnSliderValueChanged(float value)
    {
        UpdateLockState();
    }

    public void OnPointerDown()
    {
        StopCoroutine(ResetSliderValue());
    }

    public void OnPointerUp()
    {
        if(resetCoroutine == null)
            resetCoroutine = StartCoroutine(ResetSliderValue());
    }

    private void UpdateLockState()
    {
        if(offSlider.value >= unlockThreshold)
        {
            isLocked = false;
            if(!isLocked)
                FinishPowerSavingMode();
        }
        else
            isLocked = true;

        if(offSlider.value < 0.05f)
            offSlider.value = 0f;
    }

    /*private IEnumerator ResetSliderValue()
    {
        while(offSlider.value > 0 && isLocked)
        {
            offSlider.value = Mathf.Lerp(offSlider.value, 0, Time.deltaTime * resetSpeed);
            yield return null;
        }
        resetCoroutine = null;
    }*/

    private IEnumerator ResetSliderValue()
    {
        while(offSlider.value > 0 && isLocked)
        {
            float step = resetSpeed * Time.deltaTime;

            if (offSlider.value < step)
                offSlider.value = 0;
            else
                offSlider.value -= step;

            yield return null;
        }
        resetCoroutine = null;
    }

    private void FinishPowerSavingMode()
    {
        this.isOn = false;

        UIManager.Instance.ShowCanvas("Main Canvas");
        UIManager.Instance.HideCanvas("Power Saving Canvas");

        mainCamera.cullingMask = originalCullingMask;
    }
    public void RefreshBatteryInfo()
    {
        float batteryLevel = SystemInfo.batteryLevel;

        batteryInfoText.text = $"{Mathf.FloorToInt(batteryLevel * 100)}%";

        switch(SystemInfo.batteryStatus)
        {
            // 케이블 연결 o 배터리 가득인 경우
            case BatteryStatus.Full:
                batteryInfoIcon.sprite = batterySpriteList[0];
                batteryGaugeImage.gameObject.SetActive(false);
            break;
            // 케이블 연결 o 충전 중 인경우
            case BatteryStatus.Charging:
                batteryInfoIcon.sprite = batterySpriteList[0];
                batteryGaugeImage.gameObject.SetActive(false);
            break;
            // 케이블 연결 x 충전 x
            case BatteryStatus.Discharging:
                if(batteryLevel > 0.99f)                                        // 배터리 100 % 일 때
                {
                    batteryInfoIcon.sprite = batterySpriteList[1];
                    batteryGaugeImage.gameObject.SetActive(false);
                }
                else if(batteryLevel >= 0.01f && batteryLevel <= 0.99f )        // 배터리 1 ~ 99 % 일 때
                {
                    batteryInfoIcon.sprite = batterySpriteList[2];
                    batteryGaugeImage.gameObject.SetActive(true);
                }
                else                                                            // 배터리 0 % 일 때
                {
                    batteryInfoIcon.sprite = batterySpriteList[2];              
                    batteryGaugeImage.gameObject.SetActive(false);
                }
                batteryGaugeImage.fillAmount = batteryLevel;
            break;
        }
    }

    public void RefreshWifiInfo()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            wifiSignalInfoIcon.sprite = wifiSignalSpriteList[0];
            wifiSignalInfoIcon.gameObject.SetActive(true);
            mobileDataText.gameObject.SetActive(false);
        }
        else if(Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            wifiSignalInfoIcon.sprite = wifiSignalSpriteList[1];
            wifiSignalInfoIcon.gameObject.SetActive(true);
            mobileDataText.gameObject.SetActive(false);
        }
        else if(Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            wifiSignalInfoIcon.gameObject.SetActive(false);
            mobileDataText.gameObject.SetActive(true);
        }
    }

    // 절전모드가 열릴 때 절전모드의 플레이 타임
    public void RefreshTimeInfo()
    {
        playTime ++;

        currentHours = (int)(playTime / 3600);
        currentMin = (int)(playTime / 60 % 60);
        currentTimeSec = (int)(playTime % 60);
        powerSavingTime.text = string.Format("{0:D2} : {1:D2} : {2:D2}", currentHours, currentMin, currentTimeSec);
    }

}