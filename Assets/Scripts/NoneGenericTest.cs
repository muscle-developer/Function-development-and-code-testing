using System;
using System.Collections;
using UnityEngine;

// None Generic 테스트 코드
public class NoneGenericTest : MonoBehaviour
{
    private void Start()
    {   
        // None Generic의 경우
        MyList intList = new MyList();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.PrintAll();

        MyList stringList = new MyList();
        stringList.Add("Hello");
        stringList.Add("World");
        stringList.PrintAll();
    }
}
class MyList
{
    private ArrayList internalList = new ArrayList();

    public void Add(object item)
    {
        internalList.Add(item);
    }

    public void PrintAll()
    {
        foreach (object item in internalList)
        {
            Debug.Log(item);
        }
    }
}

