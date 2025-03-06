using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; // Newtonsoft를 사용하기 위해 네임스페이스 생성

public class NewtonsoftJsonExample : MonoBehaviour
{
    void Start()
    {        
        JsonTest jTest = new JsonTest(); // JsonTest 클래스의 인스턴스를 생성
        string jsonData = JsonConvert.SerializeObject(jTest);   // JsonTest 인스턴스를 JSON 문자열로 변환(직렬화)
        Debug.Log(jsonData); // 변환된 JSON 문자열을 Unity 콘솔에 출력

        JsonTest jsonTest1 = JsonConvert.DeserializeObject<JsonTest>(jsonData); // JSON 문자열을 다시 JsonTest 객체로 변환(역직렬화)
        jsonTest1.Print();  // 역직렬화된 객체의 데이터를 출력
    }


    // JSON 변환을 테스트할 클래스
    public class JsonTest
    {
        public int i;
        public float f;
        public bool b;
        public string str;
        public int[] iArray;
        public List<int> iList = new List<int>();
        public Dictionary<string, float> fDictionary = new Dictionary<string, float>();
        public IntVector2 iVector;

        // 생성자: 객체가 생성될 때 실행됨
        public JsonTest()
        {
            i = 10;
            f = 99.9f;
            b = true;
            str = "JSON Test String";
            iArray = new int[] { 1, 1, 2, 3, 5, 8, 12, 21, 34, 55 };
            for (int idx = 0; idx < 5; idx++)
            {
                iList.Add(2 * idx);
            }
            fDictionary.Add ("PIE", Mathf.PI);
            fDictionary.Add("Epsilon", Mathf.Epsilon);
            fDictionary.Add ("Sqrt(2)", Mathf.Sqrt(2));
            iVector = new IntVector2(3,2);
        }

        // 객체의 필드 값을 출력하는 함수
        public void Print()
        {
            Debug.Log("i = " + i);
            Debug.Log("f = " + f);
            Debug.Log("b = " + b);
            Debug.Log("str = " + str);

            for(i = 0; i < iArray.Length; i++)
            {
                Debug.Log(string.Format("iArray[(0)] = {1}", i, iArray[i]));
            }

            for(i = 0; i < iList.Count; i++)
            {
                Debug.Log(string.Format("iList[(0)] = {1}", i, iList[i]));
            }

            foreach(var data in fDictionary)
            {
                Debug.Log(string.Format("fDictionary[(0)] = {1}", data.Key, data.Value));
            }

            Debug.Log("iVector = " + iVector.x + "," + iVector.y);
        }

        // 2차원 정수 벡터를 나타내는 클래스
        public class IntVector2
        {
            public int x; // x 좌표
            public int y; // y 좌표

            // 생성자: x, y 값을 설정
            public IntVector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
