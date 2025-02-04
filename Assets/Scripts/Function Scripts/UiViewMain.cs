using System.Collections;
using System.Collections.Generic;
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
        nickNameText.text = nickname;
    }

    [SerializeField]
    private Button testOpenPopupButton;

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
}
