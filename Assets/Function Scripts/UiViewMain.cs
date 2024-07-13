using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiViewMain : MonoBehaviour
{
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
}
