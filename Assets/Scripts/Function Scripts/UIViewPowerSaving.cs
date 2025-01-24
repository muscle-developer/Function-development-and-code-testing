using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIViewPowerSaving : MonoBehaviour
{
    // 메인 카메라 참조
    [SerializeField]
    private Camera mainCamera;

    // 배터리 및 WiFi 아이콘을 위한 Sprite 목록
    [SerializeField]
    private List<Sprite> batterySpriteList; // 배터리 상태에 따라 변경될 스프라이트 목록
    [SerializeField]
    private Image batteryInfoIcon;         // 배터리 상태 아이콘
    [SerializeField]
    private Image batteryGaugeImage;       // 배터리 게이지 이미지
    [SerializeField]
    private TMP_Text batteryInfoText;      // 배터리 정보를 표시할 텍스트
    [SerializeField]
    private List<Sprite> wifiSignalSpriteList; // WiFi 신호 스프라이트 목록
    [SerializeField]
    private Image wifiSignalInfoIcon;      // WiFi 신호 아이콘
    [SerializeField]
    private Transform mobileDataText;      // 모바일 데이터 텍스트
    [SerializeField]
    private Slider offSlider;              // 잠금 해제 슬라이더

    // 슬라이더 조작과 잠금 상태 제어를 위한 변수
    private float unlockThreshold = 1f;    // 잠금 해제 기준 슬라이더 값
    private float resetSpeed = 1.5f;       // 슬라이더 초기화 속도
    private bool isLocked;                 // 잠금 상태 여부
    public Coroutine resetCoroutine;       // 슬라이더 초기화 코루틴 참조

    // 시간 정보를 저장하는 변수
    [SerializeField]
    private int currentHours;
    [SerializeField]
    private int currentMin;
    [SerializeField]
    private int currentTimeSec;
    [SerializeField]
    private int playTime;                  // 절전 모드에서 경과된 총 시간(초)

    [SerializeField]
    private TMP_Text powerSavingTime;      // 절전 모드의 플레이 타임 텍스트
    private bool isOn = false;             // 절전 모드 활성 상태
    public bool IsOn{
        get{
            return isOn;                   // 절전 모드 활성 여부 반환
        }
    }

    private int originalCullingMask;       // 카메라의 원래 culling mask 저장

    // 절전 모드 시작 메서드
    public void StartPowerSavingMode()
    {
        if (this.isOn) return;             // 이미 활성 상태이면 종료

        this.isOn = true;
        this.offSlider.value = 0f;         // 슬라이더 초기화
        this.isLocked = true;              // 잠금 상태 활성화

        SoundManager.Instance.MuteAll();   // 모든 사운드 음소거

        UIManager.Instance.HideCanvas("Main Canvas");     // 메인 캔버스 숨김
        UIManager.Instance.ShowCanvas("Power Saving Canvas"); // 절전 캔버스 표시

        originalCullingMask = mainCamera.cullingMask;     // 카메라의 기존 culling mask 저장
        mainCamera.cullingMask = 0;                       // 카메라 렌더링 비활성화

        Reset();                     // 초기화
        RefreshTimeInfo();           // 시간 정보 갱신
        RefreshBatteryInfo();        // 배터리 정보 갱신
        RefreshWifiInfo();           // WiFi 정보 갱신
        UpdateLockState();           // 잠금 상태 갱신
    }

    // 절전 모드 초기화
    private void Reset()
    {
        playTime = 0;   // 플레이 타임 초기화
        powerSavingTime.text = string.Format("{0:D2}", playTime); // 텍스트 갱신
    }

    // 슬라이더 값 변경 시 호출
    public void OnSliderValueChanged(float value)
    {
        UpdateLockState(); // 슬라이더 상태에 따라 잠금 상태 갱신
    }

    // 슬라이더 조작 시작 시 호출
    public void OnPointerDown()
    {
        StopCoroutine(ResetSliderValue()); // 슬라이더 초기화를 중지
    }

    // 슬라이더 조작 종료 시 호출
    public void OnPointerUp()
    {
        if (resetCoroutine == null)        // 슬라이더 초기화 코루틴이 실행 중이 아니면 시작
            resetCoroutine = StartCoroutine(ResetSliderValue());
    }

    // 잠금 상태 업데이트
    private void UpdateLockState()
    {
        if (offSlider.value >= unlockThreshold) // 슬라이더 값이 잠금 해제 기준 이상인 경우
        {
            isLocked = false;              // 잠금 해제
            if (!isLocked)                 // 잠금 해제되었으면 절전 모드 종료
                FinishPowerSavingMode();
        }
        else
            isLocked = true;               // 그렇지 않으면 잠금 유지

        if (offSlider.value < 0.05f)       // 슬라이더 값이 0.05보다 작으면 0으로 설정
            offSlider.value = 0f;
    }

    // 슬라이더 값 초기화 코루틴
    private IEnumerator ResetSliderValue()
    {
        while (offSlider.value > 0 && isLocked) // 슬라이더 값이 0보다 크고 잠금 상태일 때
        {
            float step = resetSpeed * Time.deltaTime;

            if (offSlider.value < step)
                offSlider.value = 0;       // 슬라이더 값을 0으로 설정
            else
                offSlider.value -= step;   // 슬라이더 값을 감소

            yield return null;             // 다음 프레임까지 대기
        }
        resetCoroutine = null;             // 코루틴 참조 제거
    }

    // 절전 모드 종료
    private void FinishPowerSavingMode()
    {
        this.isOn = false;  

        SoundManager.Instance.ResetAll();  // 사운드 복원

        UIManager.Instance.ShowCanvas("Main Canvas");     // 메인 캔버스 표시
        UIManager.Instance.HideCanvas("Power Saving Canvas"); // 절전 캔버스 숨김

        mainCamera.cullingMask = originalCullingMask;     // 카메라 렌더링 복원
    }

    // 배터리 정보 갱신
    public void RefreshBatteryInfo()
    {
        float batteryLevel = SystemInfo.batteryLevel; // 배터리 충전 수준

        batteryInfoText.text = $"{Mathf.FloorToInt(batteryLevel * 100)}%"; // 배터리 퍼센트 표시

        switch (SystemInfo.batteryStatus)
        {
            case BatteryStatus.Full: // 배터리 완충
                batteryInfoIcon.sprite = batterySpriteList[0];
                batteryGaugeImage.gameObject.SetActive(false);
                break;
            case BatteryStatus.Charging: // 충전 중
                batteryInfoIcon.sprite = batterySpriteList[0];
                batteryGaugeImage.gameObject.SetActive(false);
                break;
            case BatteryStatus.Discharging: // 배터리 방전 중
                if (batteryLevel > 0.99f) // 배터리 100%
                {
                    batteryInfoIcon.sprite = batterySpriteList[1];
                    batteryGaugeImage.gameObject.SetActive(false);
                }
                else if (batteryLevel >= 0.01f && batteryLevel <= 0.99f) // 1% ~ 99%
                {
                    batteryInfoIcon.sprite = batterySpriteList[2];
                    batteryGaugeImage.gameObject.SetActive(true);
                }
                else // 0%
                {
                    batteryInfoIcon.sprite = batterySpriteList[2];
                    batteryGaugeImage.gameObject.SetActive(false);
                }
                batteryGaugeImage.fillAmount = batteryLevel; // 게이지 업데이트
                break;
        }
    }

    // WiFi 정보 갱신
    public void RefreshWifiInfo()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable) // 인터넷 연결 없음
        {
            wifiSignalInfoIcon.sprite = wifiSignalSpriteList[0];
            wifiSignalInfoIcon.gameObject.SetActive(true);
            mobileDataText.gameObject.SetActive(false);
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork) // WiFi 연결
        {
            wifiSignalInfoIcon.sprite = wifiSignalSpriteList[1];
            wifiSignalInfoIcon.gameObject.SetActive(true);
            mobileDataText.gameObject.SetActive(false);
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork) // 모바일 데이터 연결
        {
            wifiSignalInfoIcon.gameObject.SetActive(false);
            mobileDataText.gameObject.SetActive(true);
        }
    }

    // 절전 모드 플레이 타임 갱신
    public void RefreshTimeInfo()
    {
        playTime++; // 플레이 타임 증가

        currentHours = (int)(playTime / 3600); // 시 계산
        currentMin = (int)(playTime / 60 % 60); // 분 계산
        currentTimeSec = (int)(playTime % 60); // 초 계산
        powerSavingTime.text = string.Format("{0:D2} : {1:D2} : {2:D2}", currentHours, currentMin, currentTimeSec); // 시간 텍스트 갱신
    }
}
