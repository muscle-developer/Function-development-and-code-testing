using System.Collections.Generic;
using UnityEngine;

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
    private static LanguageManager instance;
    public static LanguageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LanguageManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("LanguageManager");
                    instance = obj.AddComponent<LanguageManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    // 현재 선택된 언어의 텍스트 데이터를 저장할 딕셔너리
    private Dictionary<string, string> currentLanguageData = new Dictionary<string, string>();

    // JSON 캐싱 추가 (불러온 언어 데이터를 캐시하여 성능 향상)
    private LanguageData cachedLanguageData;

    // 언어 변경 이벤트 선언 (언어가 변경될 때 발생)
    public static event System.Action OnLanguageChanged;

    private void Awake()
    {
        // 싱글톤 패턴 적용 (LanguageManager 인스턴스가 하나만 존재하도록)
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지되도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스는 삭제
        }

        // 기본 언어 설정
        LoadLanguage("ko");
    }

    // 선택된 언어 데이터 로딩 및 적용
    public void LoadLanguage(string languageCode)
    {
        // 캐시된 언어 데이터가 없다면, 리소스에서 JSON 파일을 불러와서 파싱
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

            // 선택된 언어 코드에 맞는 텍스트 값 설정
             switch (languageCode)
            {
                case "en":
                    textValue = item.English;
                break;
                case "ja":
                    textValue = item.Japanese;
                break;
            }
            
            // 각 텍스트 ID에 맞는 언어 데이터를 딕셔너리에 저장
            currentLanguageData[item.Id] = textValue;
        }

        // 언어 변경 이벤트 발생
        OnLanguageChanged?.Invoke();
    }

    // 주어진 키에 해당하는 텍스트를 반환
    public string GetTextData(string key)
    {
        // 딕셔너리에 해당 키가 존재하면 텍스트를 반환
        if (currentLanguageData.ContainsKey(key))
        {
            return currentLanguageData[key];
        }

        return key; // 키 자체를 반환
	}
}
