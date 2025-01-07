using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
//using UnityEngine.Rendering.PostProcessing;

public class UIViewPowerSaving : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private TMP_Text closeInfoText;
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
    private int offCount = 3;

    [SerializeField]
    private int currentHours;
    [SerializeField]
    private int currentMin;
    [SerializeField]
    private int currentTimeSec;
    [SerializeField]
    private int playTime;
    

    // [Title("Right Side")]
    [SerializeField]
    private TMP_Text profileNicknameText;
    // private UIBar hpBar;
    // [SerializeField]
    [SerializeField]
    private TMP_Text powerSavingTime;
    private bool isOn = false;
    public bool IsOn{
        get{
            return isOn;
        }
    }

    private int originalCullingMask;

    private bool previouslyConnected = false;

    public void StartPowerSavingMode()
    {
        if(this.isOn)
            return;
            
        this.isOn = true;
        this.offCount = 3;
        this.offSlider.value = 0f;
        this.isLocked = true;

        // previouslyConnected = ChatManager.Instance.IsConnected;

        // ChatManager.Instance.Disconnect();

        SoundManager.Instance.MuteAll();

        UIManager.Instance.HideCanvas("Main Canvas");
        UIManager.Instance.ShowCanvas("Power Saving Canvas");

        originalCullingMask = mainCamera.cullingMask;
        mainCamera.cullingMask = 0;
        //postProcessLayer.enabled = false;

        // closeInfoText.text = string.Format(LanguageManager.Instance.GetTextData(LanguageDataType.UI, "button_power_saving_mode_release"), offCount);

        // thumbnailSequence.PlayAnimation();

        Reset();

        RefreshTimeInfo();
        RefreshBatteryInfo();
        RefreshWifiInfo();
        RefreshProfileInfo();
        UpdateLockState();
    }

    // 절전모드 열릴 때 값들 초기화
    private void Reset()
    {
        playTime = 0;
        powerSavingTime.text = string.Format("{0:D2}", playTime);   
    }

    public void TouchScreen()
    {
        this.offCount = this.offCount - 1;

        if(this.offCount <= 0)
            FinishPowerSavingMode();
    }

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

        // thumbnailSequence.StopAnimation();

		// SoundManager.Instance.UnmuteAll();

        UIManager.Instance.ShowCanvas("Main Canvas");
        UIManager.Instance.HideCanvas("Power Saving Canvas");

        // if(previouslyConnected)
        //     ChatManager.Instance.Connect();

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

    // 프로필 갱신
    public void RefreshProfileInfo()
    {
        // 프로필 닉네임과 랭킹
        // var userData = ServerNetworkManager.Instance.UserData;
        // var rankColor = InterSceneManager.Instance.GetColorForRank(userData.RankingPosition);

        // var ranking = "?";
        // if (userData.RankingPosition != 0)
        // {
        //     if (OptionManager.Instance.Language != OptionManager.LanguageModeType.en)
        //         ranking = userData.RankingPosition.ToString();
        //     else
        //         ranking = ChatManager.AddOrdinal(userData.RankingPosition);
        // }
        // this.profileNicknameText.text = string.Format(LanguageManager.Instance.GetTextData(LanguageDataType.UI, "ranking_format"), ranking, rankColor) + " " + ServerNetworkManager.Instance.UserData.Nickname;
        
        // 프로필 hp
        // var localCharacter = BaseIngameController.Instance.LocalPlayerCharacterIdentity;
        // hpBar.Refresh(localCharacter.LeftHPRatio, localCharacter.HP, localCharacter.MaxHP);

        // 프로필 stage
        // int currentStageProgress = ServerNetworkManager.Instance.UserData.SelectedStageProgress;
        // int currentChapterIndex = (currentStageProgress - 1) / ServerNetworkManager.Instance.Setting.MaxStageInChapter + 1;
        // int currentStageIndex = (currentStageProgress - 1) % ServerNetworkManager.Instance.Setting.MaxStageInChapter + 1;

        // string chapterStageInfo = currentChapterIndex + "-" + currentStageIndex;
        // stageText.text = chapterStageInfo;
    }

    // 플레이 중 획득한 것들을 띄우는 함수(골드, exp, 무기, 등등..)
    public void IncrementBounty(BigInteger gold, BigInteger enchantStone, BigInteger nebulaStone, int cube, BigInteger exp, bool didFindItem, bool receivedWeapon, bool receivedClass)
    {
        // 몬스터 처치시 획득하는 골드 
        // goldAmount += gold;
        // goldAcheiveText.text = LanguageManager.Instance.GetTextData(LanguageDataType.ENTITY, "gold") + "\n" +
        // string.Format(LanguageManager.Instance.NumberToString(goldAmount));

        // enchantStoneAmount += enchantStone;
        // enchantStoneAcheiveText.text = LanguageManager.Instance.GetTextData(LanguageDataType.ENTITY, "enchant_stone") + "\n" +
        // string.Format(LanguageManager.Instance.NumberToString(enchantStoneAmount));

        // nebulaStoneAmount += nebulaStone;
        // nebulaStoneAcheiveText.text = LanguageManager.Instance.GetTextData(LanguageDataType.UI, "button_tab_nebula") + "\n" +
        // string.Format(LanguageManager.Instance.NumberToString(nebulaStoneAmount));

        // cubeAmount += cube;
        // cubeAcheiveText.text = LanguageManager.Instance.GetTextData(LanguageDataType.UI, "button_tab_inventory_cube") + "\n" +
        // string.Format(LanguageManager.Instance.NumberToString(cubeAmount));

        // expAmount += exp;
        // expAcheiveText.text = LanguageManager.Instance.GetTextData(LanguageDataType.ENTITY, "exp") + "\n" +
        // string.Format(LanguageManager.Instance.NumberToString(expAmount));
    
        // if(didFindItem)
        // {
        //     if(receivedWeapon)
        //     {
        //         weaponAmount += 1;
        //         weaponAcheiveText.text = weaponAmount.ToString();
        //     }
        //     else if(receivedClass)
        //     {
        //         classAmount += 1;
        //         classAcheiveText.text = classAmount.ToString();
        //     }
        // }
    }
}