using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableReferenceTest : MonoBehaviour
{
    void Start()
    {
        int myNumber = 10;
        AddFive(ref myNumber);
        Debug.Log(myNumber); // 출력: 15
    }

    public void AddFive(ref int number)
    {
        number += 5;
    }
    
    // 테스트 커밋
//     int testA;
// TestRef(ref testA); // testA 컴파일 에러 발생.

// void TestRef(ref int a)
// {
//    a = 10;
// }
}
