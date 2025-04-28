using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    void Start()
    {
        // 델리게이트 케이스
        EventDelegate eventDelegate = new EventDelegate();
        eventDelegate.DelegateAdd();        // 델리게이트에 Add 메서드를 할당하고 실행
        eventDelegate.DelegateMultiply();   // 델리게이트에 Multiply 메서드를 할당하고 실행

        // 이벤트 케이스
        EventExample eventExample = new EventExample();
        
        // 이벤트에 메서드를 등록(구독)
        eventExample.OnCalculate += eventExample.Add;
        eventExample.OnCalculate += eventExample.Multiply;

        // 이벤트 실행
        eventExample.InvokeEvent(3, 5);

        // Multiply 메서드를 이벤트에서 제거(해제)
        eventExample.OnCalculate -= eventExample.Multiply;

        // 이벤트 다시 실행
        eventExample.InvokeEvent(3, 5);
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

#region 이벤트 사용
// EventExample : 이벤트를 활용한 일반 C# 클래스
public class EventExample
{
    public delegate int MyDelegate(int x, int y);
    public event MyDelegate OnCalculate;    // 이벤트 선언: 외부에서는 +=, -= 만 가능하고 직접 호출은 불가

    // 이벤트를 실행하는 메서드
    public void InvokeEvent(int a, int b)
    {
        if (OnCalculate != null)
        {
            foreach (MyDelegate del in OnCalculate.GetInvocationList())
            {
                int result = del(a, b); // 각각 등록된 메서드를 호출
                Debug.Log(result);
            }
        }
    }

    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }
}
#endregion
