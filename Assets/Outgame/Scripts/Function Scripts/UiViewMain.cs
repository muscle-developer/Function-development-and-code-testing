using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiViewMain : MonoBehaviour
{
    [SerializeField]
    private TMP_Text nickNameText;
    private string nickname;

    void Start()
    {
        nickname = PlayerPrefs.GetString("Nickname", "Player");
        nickNameText.text = LanguageManager.Instance.GetTextData("common_nickName") + nickname;
    }

    [SerializeField]
    private Button pressedOpenPopupButton;

    public void OpenTestPopupButtonClicked()
    {
        OutgameController.Instance.OpenTestPopup();
    }

    public void OpenSlideTestPopupButtonClicked()
    {
        OutgameController.Instance.OpenSlideTestPopup();
    }

    public void OpenScaleTestPopupButtonClicked()
    {
        OutgameController.Instance.OpenScaleTestPopup();
    }

    public void OpenRotateTestPopupButtonClicked()
    {
        OutgameController.Instance.OpenRotateTestPopup();
    }

    public void OpenPowerSavingButtonClicked()
    {
        OutgameController.Instance.OpenPowerSavingPopup();
    }

    public void OpenPressedPopupButtonClicked()
    {
        OutgameController.Instance.OpenPressedPopup();
    }

    public void OpenOptionPopupButtonClicked()
    {
        OutgameController.Instance.OpenOptionPopup();   
    }
}
