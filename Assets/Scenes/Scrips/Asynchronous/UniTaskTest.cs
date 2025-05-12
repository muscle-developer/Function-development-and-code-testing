using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;

public class UniTaskTest : MonoBehaviour
{
    public GameObject coroutineObj;
    public GameObject uniTaskObj;

    void Start()
    {
        StartCoroutine(Wait1Second());
        Wait1SecondAsync().Forget();
    }

    private IEnumerator Wait1Second()
    {
        yield return new WaitForSeconds(3f);
        coroutineObj.gameObject.SetActive(false);
        Debug.Log("코루틴 오브젝트 3초뒤 꺼짐");
    }

    public async UniTask Wait1SecondAsync()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        uniTaskObj.SetActive(false);
        Debug.Log("유니테스크 오브젝트 3초뒤 꺼짐");
    }
}
