using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
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

        // 액션 케이스
        ActionExample actionExample = new ActionExample();
        actionExample.onCalculateAction = actionExample.PlayerInfo;
        actionExample.onCalculateAction(80, 100);

        // 액션 람다식 사용
        actionExample.onCalculateAction = (hp, mp) => Debug.Log("HP: " + hp + ", MP: " + mp);
        actionExample.onCalculateAction(80, 100);  // HP: 80 출력

        // Fun 케이스
        FuncExample funcExample = new FuncExample();
        funcExample.onCalculateFun = funcExample.Add;
        int addResult = funcExample.onCalculateFun(3, 5);
        Debug.Log(addResult);

        funcExample.onCalculateFun = funcExample.Multiply;
        int multiplyResult = funcExample.onCalculateFun(3, 5);
        Debug.Log(multiplyResult);

        // Fun 람다식 사용
        funcExample.onCalculateFun = (a, b) => a + b;
        Debug.Log(funcExample.onCalculateFun(3, 5)); // 8

        funcExample.onCalculateFun = (a, b) => a * b;
        Debug.Log(funcExample.onCalculateFun(3, 5)); // 15
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

#region 액션 사용
public class ActionExample
{
    // Action 선언
    public System.Action<int, int> onCalculateAction;

    public void PlayerInfo(int hp, int mp)
    {
        Debug.Log("HP: " + hp);
        Debug.Log("MP:" + mp);
    }
}
#endregion

#region Fun사용
public class FuncExample : MonoBehaviour
{
    // Func 선언
    public System.Func<int, int, int> onCalculateFun;  //(int 2개 입력 받고 마지막 int를 반환)

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