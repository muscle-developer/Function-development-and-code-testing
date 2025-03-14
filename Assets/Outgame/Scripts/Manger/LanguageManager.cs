using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class UITextData
{
    public string Id;
    public string Korean;
    public string English;
    public string Japanese;
}

[System.Serializable]
public class LanguageData
{
    public List<UITextData> UI;
}

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    public TextMeshProUGUI[] textElements;

    private Dictionary<string, string> currentLanguageData = new Dictionary<string, string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLanguage(string languageCode)
    {
        string jsonPath = Application.dataPath + "/Outgame/Scripts/JsonData/test_language.json";
        string jsonData = File.ReadAllText(jsonPath);
        LanguageData data = JsonUtility.FromJson<LanguageData>(jsonData);

        currentLanguageData.Clear();

        foreach (var item in data.UI)
        {
            switch (languageCode)
            {
                case "ko":
                    currentLanguageData[item.Id] = item.Korean;
                    break;
                case "en":
                    currentLanguageData[item.Id] = item.English;
                    break;
                case "ja":
                    currentLanguageData[item.Id] = item.Japanese;
                    break;
            }
        }

        UpdateUIText();
    }

    private void UpdateUIText()
    {
        foreach (var textElement in textElements)
        {
            string key = textElement.gameObject.name; // 오브젝트 이름 기준으로 Id 매칭
            if (currentLanguageData.ContainsKey(key))
            {
                textElement.text = currentLanguageData[key];
            }
        }
    }
}
