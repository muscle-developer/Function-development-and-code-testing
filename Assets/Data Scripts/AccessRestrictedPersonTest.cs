using Unity.VisualScripting;
using UnityEngine;

public class AccessRestrictedPersonTest : MonoBehaviour
{
    private bool isFruit = false;

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
