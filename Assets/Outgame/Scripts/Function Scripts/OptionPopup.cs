using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class OptionPopup : UIPopup
{
    [SerializeField]
	private TMP_Dropdown languageDropdown;

    // PlayerPrefs에 저장할 키 값 (언어 선택 인덱스 저장용)
    private const string LanguageKey = "SelectedLanguage";

    public override void Open()
    {
        base.Open();
        Refresh(); // 열릴 때 선택된 언어 업데이트
    }

    public override void Close()
    {
        base.Close();
    }

    // 언어 드롭다운 옵션 초기화 및 선택된 언어 유지
    public override void Refresh()
    {
        // 기존 옵션 초기화
        languageDropdown.ClearOptions();

        // 언어 옵션 추가
        languageDropdown.AddOptions(new List<string> { "한국어", "English", "日本語" });

        // PlayerPrefs에서 저장된 언어 인덱스 불러오기 (기본값 0)
        int savedIndex = PlayerPrefs.GetInt(LanguageKey, 0);

        // 드롭다운에서 저장된 인덱스에 맞는 언어 선택
        languageDropdown.value = savedIndex;
    }

    // 언어 변경 시 호출되는 메서드 (Dropdown의 OnValueChanged 이벤트에 연결)
    public void OnLanguageChange(int index)
    {
        string selectedLanguage = "";

        // 선택된 인덱스에 따라 언어 코드 설정
        switch (index)
        {
            case 0: selectedLanguage = "ko"; break; // 한국어
            case 1: selectedLanguage = "en"; break; // 영어
            case 2: selectedLanguage = "ja"; break; // 일본어
        }

        // 선택된 언어 인덱스를 PlayerPrefs에 저장
        PlayerPrefs.SetInt(LanguageKey, index);
        PlayerPrefs.Save();

        // LanguageManager를 통해 UI 텍스트 업데이트
        LanguageManager.Instance.LoadLanguage(selectedLanguage);
    }
}
