using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GenericCollection : MonoBehaviour
{
    // List
    /*void Start()
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
    }*/

    // Dictionary
    void Start()
    {
        Dictionary<string, int> nameAndAges = new Dictionary<string, int>();
        nameAndAges.Add("철수", 30);
        nameAndAges.Add("영희", 25);
        nameAndAges.Add("유리", 35);

        foreach (var tmp in nameAndAges) 
        { 
            Debug.Log($"{tmp.Key} {tmp.Value}");
        } 

        foreach (var key in nameAndAges.Keys) 
        { 
            Debug.Log(key); 
        } 

        foreach (var value in nameAndAges.Values) 
        { 
            Debug.Log(value); 
        } 
                
        Debug.Log($"{nameAndAges["영희"]}"); 
    }
}
