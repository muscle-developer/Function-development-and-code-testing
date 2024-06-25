using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayAndListTest : MonoBehaviour
{    
    public void Start()
    {
        ArrayTest arrayTest = new ArrayTest();
        arrayTest.Main();

        ListTest listTest = new ListTest();
        listTest.Main();
    }
}

public class ArrayTest : ArrayAndListTest
{
    public void Main()
    {
        // 배열 선언과 초기화
        int[] numbers = { 1, 2, 3, 4, 5 };

        // 배열 요소 접근
        Debug.Log("첫 번째 요소: " + numbers[0]);

        // 배열 요소 수정
        numbers[1] = 10;
        Debug.Log("수정된 두 번째 요소: " + numbers[1]);

        // 배열의 길이
        Debug.Log("배열의 길이: " + numbers.Length);

        // 배열의 반복 처리
        Debug.Log("배열 요소:");
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }
    }    
}

public class ListTest : ArrayAndListTest
{   
    public void Main()
    {
        // 리스트 선언과 초기화
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // 리스트 요소 접근
        Debug.Log("첫 번째 요소: " + numbers[0]);

        // 리스트 요소 수정
        numbers[1] = 10;
        Debug.Log("수정된 두 번째 요소: " + numbers[1]);

        // 리스트의 길이
        Debug.Log("리스트의 길이: " + numbers.Count);

        // 리스트에 요소 추가
        numbers.Add(6);
        Debug.Log("추가된 요소: " + numbers[5]);

        // 리스트의 반복 처리
        Debug.Log("리스트 요소:");
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }
    }   
}
