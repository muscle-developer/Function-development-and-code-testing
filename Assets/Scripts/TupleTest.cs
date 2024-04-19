<<<<<<< HEAD
=======
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
        // 깃 잔디 테스트 4 / 13일
=======
>>>>>>> c00c90ee65924e40e93a980262bd54b23bacf343
    }
}
>>>>>>> bbbceff (튜플 관련 수정)
