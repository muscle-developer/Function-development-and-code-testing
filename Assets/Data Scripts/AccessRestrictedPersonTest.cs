using UnityEngine;

public class AccessRestrictedPersonTest : MonoBehaviour
{
    private int a = 1;
    private int b = 2;

    void Start()
    {
        Program();
        NumberProgram(b, a);
    }

    public void Program()
    { 
        // Debug.Log("a의 값:" + a + "\n" + "b의 값:" + b);
        Debug.Log($"a의 값: {a}\n b의 값: {b}");
    }

    public int NumberProgram(int numberA, int numberB)
    {   
        // Debug.Log("Number A의 값:" + numberA + "\n" + "Number B의 값:" + numberB);
        Debug.Log($"Number A의 값: {numberA}\n Number B의 값: {numberB}");
        return numberA + numberB;    
    }
}
