using UnityEngine;

public class Singleton : MonoBehaviour
{
    // 전역적으로 접근 가능한 유일한 인스턴스
    private static Singleton instance;

    public static Singleton Instance
    {
        get { return instance; }
        private set { instance = value; }
    }


    private void Awake()
    {
        // 이미 인스턴스가 존재하면 새로 생성되는 인스턴스를 제거
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 현재 인스턴스를 설정
        instance = this;
        
        // 씬이 변경되더라도 유지되도록 설정
        DontDestroyOnLoad(gameObject);
    }

    public void PrintMessage(string message)
    {
        Debug.Log(message);
    }
}

