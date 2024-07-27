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

        // 다양한 타입을 저장할 수 있지만, 저장할 때 주의가 필요하다.
        hashtable.Add(1, "One");    // 키: int, 값: string
        hashtable.Add("Two", 2);    // 키: string, 값: int
        hashtable.Add(3, 3.14);     // 키: int, 값: double  <---- (컴파일 오류 없음, 런타임 오류 발생 가능성 있음)

        // Hashtable의 모든 키-값 쌍을 출력.
        Debug.Log("Hashtable Test:");
        foreach (DictionaryEntry item in hashtable)
        {
            Debug.Log($"Key: {item.Key}, Value: {item.Value}");
        }

        // 키가 2인 값을 가져와서 출력. 타입을 명시적으로 변환하여 안전하게 처리.
        if (hashtable.ContainsKey(2))
        {
            // 객체를 int로 캐스팅하고, 다시 문자열로 변환
            // Hashtable에서 int 값을 저장할 때는 적절한 타입으로 변환해야 함  (언박싱 필요)
            int value = (int)hashtable[2];
            Debug.Log($"Key 2가 가지고 있는 값: {value}");
        }
        else
        {
            Debug.Log("Key 2 값을 찾을 수 없습니다.");
        }
    }
}   
