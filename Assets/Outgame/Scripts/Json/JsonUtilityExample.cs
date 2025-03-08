using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;

public class JsonUtilityExample : MonoBehaviour
{
    void Start()
    {
        // JsonTest jsonTest = new JsonTest(); // JsonTest 클래스의 인스턴스를 생성
        // string jsonData = JsonUtility.ToJson(jsonTest); // JsonTest 인스턴스를 JSON 문자열로 변환(직렬화)
        // Debug.Log(jsonData);    // 변환된 JSON 문자열을 Unity 콘솔에 출력

        // JsonTest jsonTest1 = JsonUtility.FromJson<JsonTest>(jsonData);  // JSON 문자열을 다시 JsonTest 객체로 변환(역직렬화)
        // jsonTest1.Print();  // 역직렬화된 객체의 데이터를 출력

        // JsonVectorTest jsonVectorTest = new JsonVectorTest();
        // string jsonData = JsonUtility.ToJson(jsonVectorTest);
        // Debug.Log(jsonData);

        // 첫 번째 GameObject 생성 및 JSON 직렬화
        GameObject obj = new GameObject();
        NewtonsoftTestMono originalComponent = obj.AddComponent<NewtonsoftTestMono>();

        string jsonData = JsonUtility.ToJson(originalComponent);
        Debug.Log("Serialized JSON: " + jsonData);

        // 두 번째 GameObject 생성
        GameObject obj2 = new GameObject();
        NewtonsoftTestMono newComponent = obj2.AddComponent<NewtonsoftTestMono>();

        // FromJsonOverwrite를 사용하여 newComponent의 값 덮어쓰기
        JsonUtility.FromJsonOverwrite(jsonData, newComponent);

        // 결과 확인
        Debug.Log($"Deserialized: i={newComponent.i}, f={newComponent.f}, b={newComponent.b}, v={newComponent.v}");
    }
}


