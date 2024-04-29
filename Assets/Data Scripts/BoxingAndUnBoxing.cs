using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingAndUnBoxing : MonoBehaviour
{
    void Start()
    {
        // Boxing
        int number = 10;
        object boxedNumber = number; // 박싱 발생

        Debug.Log(number);
        Debug.Log(boxedNumber);

        // UnBoxing
        object boxedObject = 123;
        int unboxedNumber = (int)boxedObject; // 언박싱 발생

        Debug.LogWarning(boxedObject);
        Debug.LogWarning(unboxedNumber);
    }    
}
