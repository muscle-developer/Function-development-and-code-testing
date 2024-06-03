using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class OOPTest : MonoBehaviour
{
}

// 클래스 정의
public class ClassTest : MonoBehaviour
{
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
}

// 캡슐화 정의
public class EncapsulationClass : MonoBehaviour
{
    public class BankAccount
    {
        // private 필드
        private decimal balance;

        // public 속성
        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        // 생성자
        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        // 메서드
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
        }
    }
}

// 추상화 정의
public class AbstractionClass : MonoBehaviour
{
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
}

// 상속 정의
public class InheritanceClass : MonoBehaviour
{
    public class Animal
    {
        public string Name { get; set; }

        public void Eat()
        {
            Debug.Log($"{Name} 먹는다.");
        }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Debug.Log($"{Name} 짖는다!");
        }
    }
}

// 다형성 정의
public class PolymorphismClass : MonoBehaviour
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Debug.Log("각 타입에 맞게 소리를 낸다.");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Debug.Log("멍멍 소리를 내며 짖는다!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Debug.Log("야옹 소리를 내며 운다!");
        }
    }
}
