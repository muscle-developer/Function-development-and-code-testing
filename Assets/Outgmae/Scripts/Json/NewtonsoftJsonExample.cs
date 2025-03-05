using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; // Newtonsoft를 사용하기 위해 네임스페이스 생성

public class NewtonsoftJsonExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class JsonTest
    {
        public int i;
        public float f;
        public bool b;
        public string s;
        public int[] iArray;
        public List<int> iList = new List<int>();
        public Dictionary<string, float> fDictionary = new Dictionary<string, float>();

        public class intVector2
        {
            public int x;
            public int y;

            public intVector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
