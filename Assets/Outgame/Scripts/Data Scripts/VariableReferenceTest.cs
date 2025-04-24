using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableReferenceTest : MonoBehaviour
{
    void Start()
    {
        // ref 예시
        int myNumber = 10;
        AddFive(ref myNumber);
        Debug.Log(myNumber); // 출력: 15

        // out 예시
        int result;
        CreateNumber(out result);
        Debug.Log(result); // 출력: 42
    }
    
    // ref 예시 함수
    public void AddFive(ref int number)
    {
        number += 5;
    }

    // out 예시 함수
    void CreateNumber(out int number)
    {
        number = 42; // 반드시 값을 할당해야 함
    }
}
