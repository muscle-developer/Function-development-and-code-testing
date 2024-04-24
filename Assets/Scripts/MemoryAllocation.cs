using UnityEngine;
using System;

public class MemoryAllocation : MonoBehaviour
{
    void Start ()
    {

    }
}

class ProgramValue
{
    static void Main()
    {
        int a = 10;
        int b = a; // a의 값이 b로 복사됨 (복사 동작)

        Console.WriteLine($"a: {a}, b: {b}");

        a = 20; // a의 값 변경
        Console.WriteLine($"a: {a}, b: {b}"); // b는 여전히 10을 가짐  
    }
}

class Person
{
    public string Name { get; set; }
}

class ProgramReference
{
    static void Main()
    {
        // // person3 = null;  // 널(Null) 값

        // // Person 객체 생성 및 초기화
        // person1 = new Person();
        // person1.Name = "엘리스";

        // // person1이 참조하는 객체를 person2도 참조
        // person2 = person1;

        // // 결과 출력
        // Debug.Log($"person1 Name: {person1.Name}, person2 Name: {person2.Name}");

        // // person1의 객체의 속성 변경
        // person1.Name = "존슨";

        // // 변경된 결과 출력
        // Debug.Log($"person1 Name: {person1.Name}, person2 Name: {person2.Name}");
    }
}

