using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private OptionPopup uiOptionPopup;
    [Header("Block Text")]
    [SerializeField]
	private List<TextAsset> filterTextList = null; // 필터링할 단어들이 포함된 TextAsset 리스트
    private List<string> filterlist = null; // 필터링할 단어들을 저장하는 문자열 리스트

    private void Awake()
	{
        // 싱글톤 패턴 구현
        Instance = this;
	}

    void Start()
    {
        if(SceneManager.GetActiveScene().name != "LobbyScene")
        {
            StartCoroutine(LogicOnEverySecondCoroutine());
        }
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

    public void OpenOptionPopup()
    {
        uiOptionPopup.Open();
    }

    public bool CheckBlockText(string text)
    {
        // 필터링할 단어들을 저장하는 문자열 리스트가 아직 초기화되지 않았다면
        if (filterlist == null)
        {
            filterlist = new List<string>(); // 새로운 리스트 생성

            // filterTextList에 포함된 각 TextAsset을 순회하며 필터링 단어들을 추가
            foreach (var tmp in filterTextList)
            {
                // 현재 리스트와 새로운 리스트를 합친 후 중복 제거하여 filterlist에 저장
                filterlist = filterlist.Union(tmp.text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        // 입력된 텍스트를 소문자로 변환하여 비교
        text = text.ToLowerInvariant();

        // 필터링 리스트에 있는 단어가 포함되어 있는지 확인
        foreach (var bannedWord in filterlist)
        {
            if (text.Contains(bannedWord.ToLowerInvariant()))
            {
                return true; // 금지어가 포함된 경우 true 반환
            }
        }

        return false; // 금지어가 포함되지 않은 경우 false 반환
    }
}
