using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 로드 시 초기화가 필요하면 이곳에 코드를 추가
        Debug.Log("New scene loaded: " + scene.name);
    }

    private void OnDestroy()
    {
        // 씬 매니저 이벤트 등록 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
