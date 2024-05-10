using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class AccessRestrictedPersonTest : MonoBehaviour
{
    private bool isFruit = false;

    private int a = 1;
    private int b = 2;

    // void Start()
    // {
    //     Program();
    //     NumberProgram(b, a);
    // }

    // public void Program()
    // {
    //     Debug.Log($"a의 값 : {a}\n b의 값 : {b}");
    // }

    // public int NumberProgram(int numberA, int numberB)
    // {
    //     Debug.Log($"numberA의 값 : {numberA}\n numberB의 값 : {numberB}");
    //     return numberA + numberB;
    // }

    void Update()
    {   
        if (Input.GetKey(KeyCode.Q))
        {
            isFruit = true;   
            Debug.Log("Q 버튼이 눌렸습니다.");
        }
        else if (Input.GetKey(KeyCode.W))
        {   
            isFruit = false;
            Debug.Log("W 버튼이 눌렸습니다.");
        }

        if(Input.GetKey(KeyCode.Space))
            BoolProgram(isFruit);        
    }   

    public bool BoolProgram(bool fruit)
    {
        if(fruit)
            Debug.Log("사과");
        else
            Debug.Log("사탕");

        return fruit;
    }
}
