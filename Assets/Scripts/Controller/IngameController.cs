using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameController : MonoBehaviour
{
    public static IngameController Instance;


    void Awake()
    {
        Instance = this;
    }
}
