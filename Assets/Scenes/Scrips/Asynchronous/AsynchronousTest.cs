using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class AsynchronousTest : MonoBehaviour
{

}

#region 코루틴
public class CoroutineTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(MainCoroutine());
        else if(Input.GetKeyDown(KeyCode.W))
            StartCoroutine(GetTextNew());
        else if(Input.GetKeyDown(KeyCode.E))
            StartCoroutine(LoadScene());
    }

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

#region 비동기
public class AsyncTest : MonoBehaviour
{
    void Start()
    {
        LoadStart();
    }

    // 일반적인 예제
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
        StartGetTextAsync();
    }

    // 일반적인 예제 람다식 사용   
    /*public async void LoadStart()
    {
        Debug.Log("시작");

        await Task.Run(async () =>
        {
            Debug.Log("데이터 로딩 시작");
            await Task.Delay(2000);
            Debug.Log("데이터 로딩 완료");
        });

        Debug.Log("로딩 이후 작업");
        StartGetTextAsync();
    }*/

    // 웹 요청
    public async void StartGetTextAsync()
    {
        string url = "https://example.com/data.txt";
        string result = await GetTextAsync(url);    // GetTextAsync 함수가 완료될 때까지 대기
        Debug.Log("결과: " + result);
    }

    // 주어진 URL에서 텍스트 데이터를 비동기로 가져오는 함수
    public async Task<string> GetTextAsync(string url)
    {
        using UnityWebRequest request = UnityWebRequest.Get(url);   // UnityWebRequest를 사용하여 Get 요청 생성
        var operation = request.SendWebRequest();                   // 요청을 보내고 응답이 도착할 때까지 기다리는 비동기 작업 객체

        while (!operation.isDone)                                   // 요청이 완료될 때까지 기다림 (매 프레임마다 확인하면서 대기)
            await Task.Yield();                                     // 현재 프레임을 넘기고 다음 프레임에서 다시 계속 (유니티 프렌들리)

        if (request.result == UnityWebRequest.Result.Success)
            return request.downloadHandler.text;
        else
            return $"에러: {request.error}";
    }

    // 웹 요청 람다식 사용
    /*public async void StartGetTextAsync()
    {
        string url = "https://example.com/data.txt";

        // 람다식으로 정의한 비동기 함수: 문자열(URL)을 입력받아 문자열(결과 또는 에러 메시지)를 반환
        System.Func<string, Task<string>> getTextAsync = async (string targetUrl) =>    
        {
            using UnityWebRequest request = UnityWebRequest.Get(targetUrl);
            var operation = request.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (request.result == UnityWebRequest.Result.Success)
                return request.downloadHandler.text;
            else
                return $"에러: {request.error}";
        };

        string result = await getTextAsync(url);
        Debug.Log("결과: " + result);
    }*/
}
#endregion
