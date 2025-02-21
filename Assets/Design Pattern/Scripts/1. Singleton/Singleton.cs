using UnityEngine;

public class Singleton : MonoBehaviour
{
    // 전역적으로 접근 가능한 유일한 인스턴스
    private static Singleton instance;

    // 하나의 싱글턴만 사용하기 위해 (중복 되지 않게)
    public static Singleton Instance
    {
        get {
                // 인스턴스가 없으면 새로 생성
                if (instance == null)
                {
                    instance = FindObjectOfType<Singleton>();

                    // 씬에 싱글톤이 없으면 새로 생성
                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject("Singleton");
                        instance = singletonObject.AddComponent<Singleton>();
                    }
                }
                return instance; 
            }
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

