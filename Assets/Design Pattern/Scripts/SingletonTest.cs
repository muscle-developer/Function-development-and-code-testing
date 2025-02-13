using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTest : MonoBehaviour
{
    void Start()
    {
        Singleton.Instance.PrintMessage("싱글톤 적용 메시지!");
    }
}
