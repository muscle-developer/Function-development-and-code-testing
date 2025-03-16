using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

// JSON 데이터 구조를 매핑하기 위한 클래스
[System.Serializable]
public class UITextData
{
    public string Id;        // UI 텍스트의 고유 ID
    public string Korean;    // 한국어 텍스트
    public string English;   // 영어 텍스트
    public string Japanese;  // 일본어 텍스트
}

// JSON 데이터 전체를 담는 클래스
[System.Serializable]
public class LanguageData
{
    public List<UITextData> UI; // UI 텍스트 데이터 리스트
}

public class LanguageManager : MonoBehaviour
{
    // 싱글톤 패턴을 위한 인스턴스 변수
    public static LanguageManager Instance;

    // UI 텍스트 요소들을 담을 배열 (Inspector에서 할당)
    public TextMeshProUGUI[] textElements;

    // 현재 선택된 언어의 텍스트 데이터를 저장할 딕셔너리
    private Dictionary<string, string> currentLanguageData = new Dictionary<string, string>();

    private void Awake()
    {
        // 싱글톤 패턴 적용 (LanguageManager 인스턴스가 하나만 존재하도록)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지되도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스는 삭제
        }
    }

    // 선택된 언어 데이터 로딩 및 적용
    public void LoadLanguage(string languageCode)
    {
        // JSON 데이터 파일 경로
        string jsonPath = Application.dataPath + "/Outgame/Scripts/JsonData/text_language.json";

        // JSON 데이터 읽기
        string jsonData = File.ReadAllText(jsonPath);

        // JSON 데이터를 LanguageData 객체로 변환
        LanguageData data = JsonUtility.FromJson<LanguageData>(jsonData);

        // 기존 언어 데이터 초기화
        currentLanguageData.Clear();

        // JSON 데이터를 언어 코드에 맞게 딕셔너리에 저장
        foreach (var item in data.UI)
        {
            switch (languageCode)
            {
                case "ko":
                    currentLanguageData[item.Id] = item.Korean; // 한국어 데이터 저장
                    break;
                case "en":
                    currentLanguageData[item.Id] = item.English; // 영어 데이터 저장
                    break;
                case "ja":
                    currentLanguageData[item.Id] = item.Japanese; // 일본어 데이터 저장
                    break;
            }
        }

        // UI 텍스트 업데이트
        UpdateUIText();
    }

    // UI 텍스트에 선택된 언어 적용
    private void UpdateUIText()
    {
        foreach (var textElement in textElements)
        {
            // UI 요소의 오브젝트 이름을 키로 사용
            string key = textElement.gameObject.name; 

            // 딕셔너리에 해당 키가 있으면 텍스트 업데이트
            if (currentLanguageData.ContainsKey(key))
            {
                textElement.text = currentLanguageData[key];
            }
        }
    }
}
