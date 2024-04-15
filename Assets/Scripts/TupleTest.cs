using UnityEngine;
using System;

public class TupleTest : MonoBehaviour
{
    void Start ()
    {
        // Tuple을 생성하는 방법
        var person = Tuple.Create(1, "John", true);
        // Tuple 요소에 접근하는 방법
        Debug.Log($"ID: {person.Item1}, Name: {person.Item2}, Active: {person.Item3}");

        // Tuple 분해 (Deconstruction)
        var (id, name, active) = person;
        Debug.LogWarning($"ID: {id}, Name: {name}, Active: {active}");

        Debug.Log(person.Item1); // returns 1
        Debug.Log(person.Item2); // returns "John"
        Debug.Log(person.Item3); // returns true

        var numbers = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9, 10, 11, 12, 13));
        Debug.Log(numbers.Item1); // returns 1
        Debug.Log(numbers.Item7); // returns 7
        Debug.Log(numbers.Rest.Item1); //returns (8, 9, 10, 11, 12, 13)
        Debug.Log(numbers.Rest.Item1.Item1); //returns 8
        Debug.Log(numbers.Rest.Item1.Item2); //returns 9
<<<<<<< HEAD
<<<<<<< HEAD
        // 깃 잔디 테스트 4 / 13일
=======
>>>>>>> e14a5ca ([자료구조] - 튜플에 관하여)
=======
        // 깃 잔디 테스트
>>>>>>> a4c187c (깃 허브 잔디 테스트)
    }
}
