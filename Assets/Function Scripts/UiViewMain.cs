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
}
