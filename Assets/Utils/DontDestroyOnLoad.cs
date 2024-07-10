using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad instance;

    private void Awake()
    {
        // 중복된 인스턴스가 있는지 확인
        if (instance == null)
        {
            // 인스턴스가 없으면 이 오브젝트를 인스턴스로 설정
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 이미 인스턴스가 있으면 새로운 오브젝트를 파괴
            Destroy(gameObject);
        }
    }
}
