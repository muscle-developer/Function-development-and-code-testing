using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryAndHashTableTest : MonoBehaviour
{
    void Start()
    {
        // 테스트를 위한 클래스 생성
        DictionaryTest dictionaryTest = new DictionaryTest();
        HashTableTest hashTableTest = new HashTableTest();
        
        // 테스트 함수 실행
        dictionaryTest.RunTest();
        hashTableTest.RunTest();
    }

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
            Debug.Log("Key 2 찾을 수 없습니다.");
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
    // Hashtable 사용 예제를 실행하는 메서드.
    public void RunTest()
    {
        // 키와 값이 object 타입인 Hashtable을 생성.
        Hashtable hashtable = new Hashtable();

        // Hashtable에 키-값 쌍을 추가.
        hashtable.Add(1, "One");
        hashtable[2] = "Two";
        hashtable.Add(3, "Three");

        // Hashtable의 모든 키-값 쌍을 출력.
        Debug.Log("Hashtable Test:");
        foreach (DictionaryEntry item in hashtable)
        {
            Debug.Log($"Key: {item.Key}, Value: {item.Value}");
        }

        // 키가 2인 값을 가져와서 출력.
        if (hashtable.ContainsKey(2))
        {
            string value = (string)hashtable[2];
            Debug.Log($"Key 2 가지고 있는 값: {value}");
        }
        else
        {
            Debug.Log("Key 2 값을 찾을 수 없습니다.");
        }
    }
}   
