using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class ChatFunction : MonoBehaviour
{
    private bool isChating;
    private int chatIndex = 0; // 클릭할 때마다 바꿀 인덱스
    [SerializeField]
    private Image speechBubble;
    [SerializeField]
    private TMP_Text chatText;

    void Start()
    {
        // 언어 변경 시 OnLocaleChanged 호출
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;

        speechBubble.gameObject.SetActive(false);
        chatText.gameObject.SetActive(false);
    }

    public void Say()
    {
        if (isChating)
            return;

        StartCoroutine(SayChatbot());
    }

    private void OnLocaleChanged(Locale newLocale)
    {
        // 채팅이 표시된 상태에서 언어가 변경되면 즉시 번역된 내용으로 갱신
        if (isChating)
        {
            UpdateChatText();
        }
    }

    IEnumerator SayChatbot()
    {
        isChating = true;
        UpdateChatText(); // 채팅 UI 갱신

        chatText.gameObject.SetActive(true);
        speechBubble.gameObject.SetActive(true);


        yield return new WaitForSeconds(5f); // 5초 후 사라짐

        chatText.gameObject.SetActive(false);
        speechBubble.gameObject.SetActive(false);

        // 채팅이 끝난 후 chatIndex 증가
        chatIndex = (chatIndex + 1) % 2;

        isChating = false;
    }

    private void UpdateChatText()
    {
        Locale currentLanguage = LocalizationSettings.SelectedLocale;

        // chatIndex에 따라 다른 키 사용
        string chatKey = (chatIndex == 0) ? "UI-Chat-Hello" : "UI-Chat-1";

        chatText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Local Table", chatKey, currentLanguage);
    }
}
