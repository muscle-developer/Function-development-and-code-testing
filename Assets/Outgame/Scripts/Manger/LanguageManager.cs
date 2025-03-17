using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // JSON 캐싱 추가
    private LanguageData cachedLanguageData;

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
        if (cachedLanguageData == null)
        {
            TextAsset jsonFile = Resources.Load<TextAsset>("Text Sheets/text_language");
            cachedLanguageData = JsonUtility.FromJson<LanguageData>(jsonFile.text);
        }

        // 기존 언어 데이터 초기화
        currentLanguageData.Clear();

        // JSON 데이터를 언어 코드에 맞게 딕셔너리에 저장
        foreach (var item in cachedLanguageData.UI)
        {
            string textValue = item.Korean; // 기본값: 한국어

             switch (languageCode)
            {
                case "en":
                    textValue = item.English;
                break;
                case "ja":
                    textValue = item.Japanese;
                break;
            }
            
            currentLanguageData[item.Id] = textValue;
        }
    }

    public string GetTextData(string key, bool askTag = false)
    {
        if (currentLanguageData.ContainsKey(key))
        {
            return currentLanguageData[key];
        }

        Debug.LogWarning($"Key '{key}' not found in language data.");
        return key; // 키 자체를 반환 (디버깅용)
	}
}
