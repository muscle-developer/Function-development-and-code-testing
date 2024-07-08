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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 현재 오브젝트를 파괴
        }
	}

    public void OpenTestPopup()
    {
        if (testPopup != null)
            testPopup.gameObject.SetActive(true);
            
        testPopup.Open();
    }
}
