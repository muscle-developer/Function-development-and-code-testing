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

    // 소멸자
    // ~Player()
    // {
    //     Debug.Log($"Player 객체 {playerName} 파괴됨");
    // }
}

