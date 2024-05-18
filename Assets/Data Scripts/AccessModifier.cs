using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessModifier : MonoBehaviour
{
    public PublicPlayer player;
    void Awake()
    {
        player = GameObject.FindObjectOfType<PublicPlayer>();
    }

    void Update()
    {   
        if(!player)
            return;

        if(Input.GetKeyDown(KeyCode.A))
        {
            // Public 변수 접근 및 변경
            Debug.Log("Initial Health: " + player.health);
            player.health = 80;
            Debug.Log("Updated Health: " + player.health);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            // Public 메서드 호출
            player.TakeDamage(30);
            Debug.Log("Health after damage: " + player.health);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            // 더 큰 피해를 입히기
            player.TakeDamage(100);
            Debug.Log("Health after massive damage: " + player.health);
        }
    }
}

public class PublicPlayer : MonoBehaviour
{
    // Public 변수, 모든 클래스에서 접근 가능
    public int health = 100;

    // Public 메서드, 모든 클래스에서 접근 가능
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }
}
