using UnityEngine;

public class AccessRestrictedPersonTest : MonoBehaviour
{

    void Start()
    {
        Program();
        NumberProgram();
    }

    public void Program()
    {
        Debug.Log("프로그램 실행을 위한 메서드 : Return이 필요없음!!");
    }

    public int NumberProgram()
    {   
        Debug.Log("프로그램 실행을 위한 메서드 : Return이 필요하다!!");
        return 0;    
    }
}
