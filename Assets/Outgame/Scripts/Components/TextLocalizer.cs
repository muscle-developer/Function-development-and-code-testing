using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextLocalizer : MonoBehaviour
{
    public string key = "";

    private void Start()
    {
        UpdateText(); // 초기 UI 세팅
    }

    public void UpdateText()
    {
        if (LanguageManager.Instance != null && !string.IsNullOrEmpty(key))
        {
            var textComponent = GetComponent<TMP_Text>();
            textComponent.text = LanguageManager.Instance.GetTextData(key);
        }
    }
}
