using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutgameController : MonoBehaviour
{
    public static OutgameController Instance;

    [Header("UI Popup")]
    [SerializeField]
    private TestPopup testPopup;

    private void Awake()
	{
        // 싱글톤 패턴 구현
        Instance = this;
	}

    public void OpenTestPopup()
    {
        if (testPopup != null)
            testPopup.gameObject.SetActive(true);
            
        testPopup.Open();
    }
}
