using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Public 접근 제한자
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
#endregion

#region Protcted 접근 제한자
public class ProtectedPlayer : MonoBehaviour
{
    protected int health = 200;

    // Protected 메서드, 해당 클래스와 파생 클래스에서만 접근 가능
    protected void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        Debug.Log("Health after damage: " + health);
    }

    // Public 메서드, health 값을 외부에서 읽을 수 있도록 함
    public int GetHealth()
    {
        return health;
    }
}
public class Warrior : ProtectedPlayer
{
    // Public 메서드, 다른 클래스에서 접근 가능
    public void ApplyDamage(int damage)
    {
        // 상속받은 protected 메서드 호출
        TakeDamage(damage);
    }

    // Public 메서드, health 값을 설정할 수 있도록 함
    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
}
#endregion

#region Internal 접근 제한자
internal class InternalPlayer : MonoBehaviour
{
    // Internal 변수, 같은 어셈블리 내에서 접근 가능
    internal int health = 100;

    // Internal 메서드, 같은 어셈블리 내에서 접근 가능
    internal void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        Debug.Log("Health after damage: " + health);
    }

    // Public 메서드, health 값을 외부에서 읽을 수 있도록 함
    public int GetHealth()
    {
        return health;
    }
}
#endregion
