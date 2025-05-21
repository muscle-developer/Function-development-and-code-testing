using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;   // UniTask 관련 네임스페이스
using UnityEngine.UI;
using System.Threading;         // UniTask 취소를 위한 네임스페이스
using DG.Tweening;

public class UniTaskTest : MonoBehaviour
{
    public GameObject coroutineObj;
    public GameObject uniTaskObj;

    void Start()
    {
        // n초후 비활성화
        // StartCoroutine(Wait1Second());
        // Wait1SecondAsync().Forget();

        // 비동기 작업 취소 케이스
        coroutine = StartCoroutine(OffObjectCoroutine());
        OffObjectAsync().Forget();

        // 특정 조건이 되었을 때
        StartCoroutine(Wait3Count());
        Wait3CountAsync().Forget();

        // DoTween 사용
        WaitMove().Forget();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            count += 1;
            if(count >= 4)
                count = 0;
        }
        // 비동기 작업 취소
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            StopCoroutine(coroutine);
            source.Cancel();
        }
    }

#region n초후 오브젝트 비활성화(코루틴, UniTask)
    private IEnumerator Wait1Second()
    {
        yield return new WaitForSeconds(3f);
        coroutineObj.gameObject.SetActive(false);
        Debug.Log("코루틴 오브젝트 3초뒤 꺼짐");
    }

    public async UniTaskVoid Wait1SecondAsync()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        uniTaskObj.SetActive(false);
        Debug.Log("유니테스크 오브젝트 3초뒤 꺼짐");
    }
#endregion

#region 비동기 작업 취소

    // 코루틴 제어를 위한 변수 추가
    private Coroutine coroutine;
    private IEnumerator OffObjectCoroutine()
    {
        yield return new WaitForSeconds(3f);
        coroutineObj.gameObject.SetActive(false);
        Debug.Log("코루틴 오브젝트 3초뒤 꺼짐");
    }

    // UniTaks 작업 취소를 위한 변수 추가 (CancellationTokenSource 케이스)
    private CancellationTokenSource source = new();
    private async UniTaskVoid OffObjectAsync()
    {
        try
        {
            // 3초 대기, 도중에 source.Cancel() 되면 TaskCanceledException 발생
            await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: source.Token);
            uniTaskObj.gameObject.SetActive(false);
            Debug.Log("유니테스크 오브젝트 3초뒤 꺼짐");
        }
        catch (OperationCanceledException)
        {
            Debug.LogWarning("유니테스크 취소됨");
        }
    }

    private async UniTaskVoid DestoyedObjectAsync()
    {
        try
        {
            // 3초 대기, 도중에 오브젝트가 삭제 되면 자동적으로 task종료
            await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: this.GetCancellationTokenOnDestroy());
            uniTaskObj.gameObject.SetActive(false);
            Debug.Log("유니테스크 오브젝트 3초뒤 꺼짐");
        }
        catch (OperationCanceledException)
        {
            Debug.LogWarning("유니테스크 삭제됨");
        }
    }
#endregion 

#region 특정 조건이 되었을 때
    [SerializeField]
    private int count = 0;

    private IEnumerator Wait3Count()
    {
        yield return new WaitUntil(() => count == 3);
        Debug.Log("Coroutine의 Count의 갯수 가" + count.ToString() + "이 되었습니다");
    }

    private async UniTaskVoid Wait3CountAsync()
    {
        await UniTask.WaitUntil(() => count == 3);
        Debug.Log("UniTask의 Count의 갯수 가" + count.ToString() + "이 되었습니다");
    }
#endregion

#region 서드파티 DoTween 연계 사용
    private async UniTaskVoid WaitMove()
    {
        await uniTaskObj.transform.DOMove(new Vector3(0, 3, 3), 3);
    }
#endregion

}

#region UniTaskVoid 와 UniTask
public class UniTaskAsyncTest : MonoBehaviour
{
    private Button button;

    // Unity의 Start() 함수도 async로 정의 가능 (주의: void가 아니라 Task)
    async Task Start()
    {
        await LoadSceneAsync();                             // 씬을 비동기로 로드하며 완료까지 기다림
        button.onClick.AddListener(() => OnButtonClick());  // 버튼이 클릭되었을 때 비동기 함수 실행 - 이벤트 헨들러 방식
        OnButtonClick().Forget();                           // UniTaskVoid 사용: fire-and-forget 방식 - Forget사용 방식
    }

    // UniTask 사용: 비동기 함수이며 예외 처리 가능
    public async UniTask LoadSceneAsync()
    {
        try
        {
            await SceneManager.LoadSceneAsync("Game").ToUniTask();
            Debug.Log("씬 로딩 완료");
        }
        catch (Exception e)
        {
            Debug.LogError($"에러 발생: {e.Message}");
        }
    }

    // UniTaskVoid 사용: 버튼 클릭처럼 결과를 기다릴 필요 없는 이벤트 핸들러에 사용
    public async UniTaskVoid OnButtonClick()
    {
        await UniTask.Delay(1000);
        Debug.Log("버튼 클릭 후 1초 지남");
    }
}
#endregion
