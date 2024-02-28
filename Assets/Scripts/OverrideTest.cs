using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideTest : MonoBehaviour
{
    void Start()
    {
        // 부모 클래스의 인스턴스 생성
        Animal animal = new Animal();
        // 부모 클래스의 MakeSound 메서드 호출
        animal.AnimalSound();

        // 자식 클래스의 인스턴스 생성
        Dog dog = new Dog();
        // 자식 클래스에서 재정의된 MakeSound 메서드 호출
        dog.AnimalSound();

        // 다형성을 통해 각각의 동작을 실행
        PlayerController player = new PlayerController();
        player.MoveUpdate();

        EnemyController enemy = new EnemyController();
        enemy.MoveUpdate();
    }
}

// 부모 클래스
public class BaseController : MonoBehaviour
{
    public virtual void MoveUpdate()
    {
        // 기본 로직 캐릭터 움직이기
        Debug.Log("캐릭터 동작 : 기본 움직이기");
    }
}

// 자식 클래스 1
public class PlayerController : BaseController
{
    // 부모 클래스에서 상속받은 Update 메서드를 재정의
    public override void MoveUpdate()
    {
        base.MoveUpdate(); // 부모 클래스의 동작 실행
        Debug.Log("플레이어 동작 : 플레이어는 달리기가 가능하다!"); // 추가적인 동작 수행
    }
}

// 자식 클래스 2
public class EnemyController : BaseController
{
    // 부모 클래스에서 상속받은 Update 메서드를 재정의
    public override void MoveUpdate()
    {
        base.MoveUpdate(); // 부모 클래스의 동작 실행
        Debug.Log("적 동작: 적은 점프가 가능하다!"); // 추가적인 동작 수행
    }
}

public class Animal : MonoBehaviour
{
    // 부모는 virtual로 선언
    public virtual void AnimalSound()
    {
        Debug.Log("동물소리");
    }
}

public class Dog : Animal
{
    // 자식은 override로 선언
    public override void AnimalSound()
    {
        Debug.Log("강아지 : 멍멍");
    }
}




