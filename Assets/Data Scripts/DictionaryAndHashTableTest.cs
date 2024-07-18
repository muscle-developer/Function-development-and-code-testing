using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryAndHashTableTest : MonoBehaviour
{

}

public class DictionaryTest
{  
    public void RunTest()
    {
        // int 타입의 키와 string 타입의 값을 가지는 Dictionary를 생성.
        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        // Dictionary에 키-값 쌍을 추가.
        dictionary.Add(1, "One");
        dictionary[2] = "Two";
        dictionary.Add(3, "Three");

        // Dictionary의 모든 키-값 쌍을 출력.
        foreach (var item in dictionary)
        {
            Debug.Log($"Key: {item.Key}, Value: {item.Value}");
        }

        // 키가 2인 값을 가져오기 -  TryGetValue (Key를 통해 값을 반환)
        if (dictionary.TryGetValue(2, out string value))
        {
            Debug.Log($"Key 2 의 value값 : {value}");
        }
        else
        {
            Debug.Log("Key 2 찾을 수 없다.");
        }

        // 키값이 3이 있는지 찾기 - ContainsKey (Key 검색)
        if(dictionary.ContainsKey(3))
            Debug.Log("있음");
        else
            Debug.Log("없음");
    }
}

public class HashTableTest
{

}   
