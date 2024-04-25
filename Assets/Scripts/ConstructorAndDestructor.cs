using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorAndDestructor : MonoBehaviour
{
   void Start ()
    {
        // 매개변수를 전달하여 Player 객체 생성
        Player myPlayer = new Player("John", 5);

        // 기본 생성자를 이용한 Player 객체 생성
        Player guestPlayer = new Player();

        // 생성된 Player 객체의 정보 확인
        Debug.Log($"myPlayer: {myPlayer.playerName} 레벨 {myPlayer.playerLevel}");
        Debug.Log($"guestPlayer: {guestPlayer.playerName} 레벨 {guestPlayer.playerLevel}");

        // 게임 오브젝트가 파괴되기 전에 호출될 함수 등록
        OnDestroyEvent.onDestroy += ShowDestroyMessage;
    }

    // 소멸자 (Unity)
    // 게임 오브젝트가 파괴될 때 호출되는 함수(게임 오브젝트가 파괴되기 전에 호출)
    private void OnDestroy()
    {
        // 이벤트 등록 해제
        OnDestroyEvent.onDestroy -= ShowDestroyMessage;
    }

    // 파괴될 때 호출할 함수
    private void ShowDestroyMessage()
    {
        Debug.Log("게임 오브젝트가 파괴되었습니다!");
    }
}

// 게임 오브젝트 파괴 이벤트를 정의하는 클래스
public static class OnDestroyEvent
{
    // 파괴될 때 호출할 이벤트
    public static event System.Action onDestroy;

    // OnDestroy() 메서드 호출 시 이벤트 발생
    public static void TriggerOnDestroy()
    {
        if (onDestroy != null)
        {
            onDestroy(); // 이벤트 호출
        }
    }
}

public class Player
{
    public string playerName;
    public int playerLevel;

    // 매개변수를 받는 생성자
    public Player(string name, int level)
    {
        playerName = name;
        playerLevel = level;
    }

    // 기본 생성자
    public Player()
    {
        playerName = "Guest";
        playerLevel = 1;
    }

    // 소멸자 (C#)
    // 아래 함수는 가비지 컬렉터에 의해 파괴됨
    ~Player()
    {
        Debug.Log($"Player 객체 {playerName} 파괴됨");
    }
}


