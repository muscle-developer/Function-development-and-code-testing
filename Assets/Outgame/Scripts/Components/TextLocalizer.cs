using UnityEngine;
using TMPro;

public class TextLocalizer : MonoBehaviour
{
    public string key = "";  // UI 텍스트의 고유 ID (LanguageManager에서 텍스트를 찾기 위한 키)
    public string formatArgument = "";  // 텍스트 포맷에 추가될 인자

    // 컴포넌트가 활성화될 때 언어 변경 이벤트를 활성화
    private void OnEnable()
    {
        LanguageManager.OnLanguageChanged += UpdateText; 
    }

    // 컴포넌트가 비활성화될 때 언어 변경 이벤트 구독 비활성화
    private void OnDisable()
    {
        LanguageManager.OnLanguageChanged -= UpdateText; 
    }

    private void Start()
    {
        UpdateText(); // 초기 UI 세팅
    }

    // 언어 변경 시 호출되어 UI 텍스트를 업데이트하는 메서드
    public void UpdateText()
    {
        // LanguageManager가 초기화되어 있고, 텍스트 키가 비어 있지 않으면
        if (LanguageManager.Instance != null && !string.IsNullOrEmpty(key))
        {
            // 텍스트 컴포넌트를 가져와서 텍스트를 업데이트
            var textComponent = GetComponent<TMP_Text>();
            string formattedText = LanguageManager.Instance.GetTextData(key);

            // 텍스트에 추가 사용 인자가 있으면, 그 인자를 넣어서 텍스트를 포맷
            if (!string.IsNullOrEmpty(formatArgument))
            {
                formattedText = string.Format(formattedText, formatArgument);
            }

            // 최종적으로 텍스트를 화면에 표시
            textComponent.text = formattedText;
        }
    }

    // 추가 데이터 인자 설정 후 텍스트를 즉시 업데이트하는 메서드
    public void SetFormatArgument(string argument)
    {
        formatArgument = argument;  // 새로운 인자 설정
        UpdateText();  // 텍스트 업데이트
    }
}
