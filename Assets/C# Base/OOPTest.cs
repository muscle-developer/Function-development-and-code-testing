using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPTest : MonoBehaviour
{
#region 클래스 정의
    // 클래스 정의(사람)
    public class Person
    {
        // 속성 정의 (Attributes)
        public string Name { get; set; }
        public int Age { get; set; }

        // 생성자
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // 메서드 정의 (Methods)
        public void Speak()
        {
            Debug.Log($"{Name} is speaking.");
        }

        public void Walk()
        {
            Debug.Log($"{Name} is walking.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Person 객체 생성
            Person person1 = new Person("Alice", 30);
            Person person2 = new Person("Bob", 25);

            // 속성 출력
            Debug.Log($"Person 1: {person1.Name}, {person1.Age} years old");
            Debug.Log($"Person 2: {person2.Name}, {person2.Age} years old");

            // 메서드 호출
            person1.Speak();  // Alice is speaking.
            person1.Walk();   // Alice is walking.

            person2.Speak();  // Bob is speaking.
            person2.Walk();   // Bob is walking.
        }
    }
#endregion

#region 추상화 정의
    public abstract class Animal
    {
        public abstract void MakeSound();
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Debug.Log("멍멍!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Debug.Log("야옹!");
        }
    }

#endregion

#region 상속 정의
#endregion
}
