using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class AsynchronousTest : MonoBehaviour
{
    private CoroutineTest coroutineTest;
    private AsyncTest asyncTest;

    void Start()
    {
        asyncTest = new AsyncTest();
        asyncTest.LoadStart();
    }
}

#region 코루틴
public class CoroutineTest : MonoBehaviour
{   
    // 다른 코루틴 완료시 대기
    public IEnumerator MainCoroutine()
    {
        Debug.Log("메인 코루틴 시작");
        yield return StartCoroutine(OtherCoroutine()); // 여기서 멈춤
        Debug.Log("메인 코루틴 재개");
    }

    public IEnumerator OtherCoroutine()
    {
        Debug.Log("다른 코루틴 시작");
        yield return new WaitForSeconds(2f);
        Debug.Log("다른 코루틴 끝");
    }

    // 지정한 URL로 네트워크 요청을 보내고, 응답이 올 때까지 대기
    IEnumerator GetTextNew()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://example.com/data.txt");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log("응답 받음: " + request.downloadHandler.text);
        else
            Debug.Log("에러: " + request.error);
    }

    // 비동기 작업이 끝날때까지 대기
    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");

        // 로딩 완료까지 대기
        yield return asyncLoad;

        Debug.Log("씬 로딩 완료");
    }
}
#endregion

public class AsyncTest
{
    public async Task LoadData()
    {
        Debug.Log("데이터 로딩 시작");
        await Task.Delay(2000); // 2초 대기 (비동기적)
        Debug.Log("데이터 로딩 완료");
    }

    public async void LoadStart()
    {
        Debug.Log("시작");
        await LoadData();
        Debug.Log("로딩 이후 작업");
    }
}
