using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPTest : MonoBehaviour
{

}

namespace OOPExample
{
    // 클래스 정의
    public abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        // 추상 메서드
        public abstract string Speak();
    }

    // Dog 클래스가 Animal 클래스를 상속받음
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override string Speak()
        {
            return $"{Name} says Woof!";
        }
    }

    // Cat 클래스가 Animal 클래스를 상속받음
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override string Speak()
        {
            return $"{Name} says Meow!";
        }
    }
}
