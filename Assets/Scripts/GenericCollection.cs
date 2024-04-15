using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GenericCollection : MonoBehaviour
{
<<<<<<< HEAD
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            List();
        else if(Input.GetKeyDown(KeyCode.W))
            Dictionary();
        else if(Input.GetKeyDown(KeyCode.E))
            Queue();
        else if(Input.GetKeyDown(KeyCode.R))
            Stack();
    }

    // List
    void List()
=======
    // List
    void Start()
>>>>>>> 868fea7 (자료구조 - Generic Collection - List에 관한 코드 추가)
    {
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);

        numbers.Insert(0, 5);
        numbers.Remove(4);
        
        foreach(var tmp in numbers)
        {
            Debug.Log(tmp);
        }

        Debug.Log(numbers.Count);
    }
<<<<<<< HEAD

    // Dictionary
    void Dictionary()
    {
        Dictionary<string, int> nameAndAges = new Dictionary<string, int>();
        nameAndAges.Add("철수", 30);
        nameAndAges.Add("영희", 25);
        nameAndAges.Add("유리", 35);

        foreach (var tmp in nameAndAges) 
        { 
            Debug.Log($"{tmp.Key} {tmp.Value}");
        } 

        foreach (var key in nameAndAges.Keys) 
        { 
            Debug.Log(key); 
        } 

        foreach (var value in nameAndAges.Values) 
        { 
            Debug.Log(value); 
        } 
                
        Debug.Log($"{nameAndAges["영희"]}"); 
    }

    // Queue
    void Queue()
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1번 블록");
        queue.Enqueue("2번 블록");
        queue.Enqueue("3번 블록");

        foreach (var tmp in queue) 
        { 
            Debug.Log(tmp); 
        } 

        queue.Dequeue(); 

        foreach (var tmp in queue) 
        { 
            Debug.LogWarning(tmp); 
        } 
    }

    // Stack
    void Stack()
    {
        Stack<string> stack = new Stack<string>(); 
        stack.Push("1 번째"); 
        stack.Push("2 번째"); 
        stack.Push("3 번째"); 

        foreach (var tmp in stack) 
        { 
            Debug.Log(tmp); 
        } 

        // Stack<T>의 맨 위에서 개체를 제거하지 않고 반환
        Debug.Log(stack.Peek().ToString()); 
        // Stack<T>의 맨 위에서 개체를 제거하고 반환
        stack.Pop(); 

        foreach (var tmp in stack) 
        { 
            Debug.LogWarning(tmp);
        } 
    }
=======
>>>>>>> 868fea7 (자료구조 - Generic Collection - List에 관한 코드 추가)
}
