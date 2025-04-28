using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    void Start()
    {
        EventDelegate eventDelegate = new EventDelegate();
        eventDelegate.DelegateAdd();        // 델리게이트에 Add 메서드를 할당하고 실행
        eventDelegate.DelegateMultiply();   // 델리게이트에 Multiply 메서드를 할당하고 실행
    }
}

#region 델리게이트 사용
public class EventDelegate
{
    public delegate int MyDelegate(int x, int y); // 델리게이트 선언
    public MyDelegate myDelegate;               // 델리게이트 타입의 변수 선언

    public void DelegateAdd()                    // 델리게이트에 Add 메서드를 연결하고 호출
    {
        myDelegate = Add;                       // Add 메서드를 델리게이트에 할당
        int result = myDelegate(3, 5);
        Debug.Log(result);
    }

    public void DelegateMultiply()              // 델리게이트에 Multiply 메서드를 연결하고 호출
    {
        myDelegate = Multiply;                  // Multiply 메서드를 델리게이트에 할당
        int result = myDelegate(3, 5);
        Debug.Log(result);
    }

    int Add(int a, int b)
    {
        return a + b;
    }

    int Multiply(int a, int b)
    {
        return a * b;
    }
}
# endregion
