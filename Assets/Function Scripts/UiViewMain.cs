using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiViewMain : MonoBehaviour
{
    [SerializeField]
    private Button testOpenPopupButton;
    [SerializeField]
    private TestPopup testPopup;


    public void TestOpenPopupButtonClikced()
    {
        if (testOpenPopupButton != null)
            testOpenPopupButton.gameObject.SetActive(true);

        testPopup.Open();
    }
}
