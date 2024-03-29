using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GenericCollection : MonoBehaviour
{
    // List
    void Start()
    {
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);

        numbers.Insert(0, 5);
        numbers.Remove(4);
        
        foreach(var tmp in numbers)
        {
            Debug.Log(tmp);
        }

        Debug.Log(numbers.Count);
    }
}
