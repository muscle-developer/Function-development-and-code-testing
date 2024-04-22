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
    // ~Player()
    // {
    //     Debug.Log($"Player 객체 {playerName} 파괴됨");
    // }

    // 소멸자 (Unity)
    private void OnDestroy()
    {
        // 게임 오브젝트가 파괴되기 전에 호출됩니다.
        // 여기에 리소스 해제나 후처리 작업을 수행할 수 있습니다.
        Debug.Log($"Player 객체 {playerName} 파괴됨");

        // 예: 리소스 해제
        // Destroy(someObject);
    }

    public class DestroyExample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("DestroyExample script has started.");
        }

        private void OnDestroy()
        {
            Debug.Log("DestroyExample script is being destroyed!");

            // 파괴되기 전에 후처리 작업 수행 예시
            CleanupResources();
        }

        private void CleanupResources()
        {
            // 여기에 리소스 해제 등의 후처리 작업을 수행할 수 있습니다.
            Debug.Log("Cleaning up resources...");
        }
    }
}

