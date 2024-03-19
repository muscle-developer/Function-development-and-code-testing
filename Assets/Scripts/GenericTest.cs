using UnityEngine;
using System.Collections.Generic;

public class GenericTest : MonoBehaviour
{
    void Start()
    {
        MyGenericList<int> intList = new MyGenericList<int>();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.PrintAll();

        MyGenericList<string> stringList = new MyGenericList<string>();
        stringList.Add("Hello");
        stringList.Add("World");
        stringList.PrintAll();
    }
}
public class MyGenericList<T>
{
    private List<T> internalList = new List<T>();

    public void Add(T item)
    {
        internalList.Add(item);
    }

    public void PrintAll()
    {
        foreach (T item in internalList)
        {
            Debug.Log(item);
        }
    }
}
