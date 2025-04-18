using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class NewtonsoftTestMono : MonoBehaviour
{
    public int i = 10;
    public float f = 5.0f;
    public bool b = true;
    public Vector3 v = new Vector3(5f, 15f, 20f);


    [JsonIgnore] // GameObject 같은 직렬화 불가능한 필드 제외
    public GameObject obj;
}
