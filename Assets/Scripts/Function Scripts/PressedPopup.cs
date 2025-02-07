using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PressedPopup : UIPopup
{
    [SerializeField] 
    private TMP_Text numberText; // 현재 숫자를 표시하는 UI 텍스트

    private int number = 0; // 현재 숫자 값

    private bool isPressed = false; // 버튼이 눌려 있는지 여부
    private float lastTime = 0; // 마지막으로 버튼이 눌린 시간
    private float pressInterval = 0.1f; // 버튼이 눌린 상태에서 숫자가 변경되는 간격 (초 단위)

    private enum PressType { None, Plus, Minus }    // 버튼이 눌린 상태인지 및 어떤 버튼이 눌렸는지를 나타내는 열거형
    private PressType currentPressType = PressType.None; // 현재 눌린 버튼 타입

    public override void Open()
    {
        base.Open();
        Init();
    }

    public override void Close()
    {
        base.Close();
    }

    private void Update()
    {
        // 눌리는 중이고, 마지막 변경 시간(lastTime)으로부터 pressInterval(0.1초) 이상 경과했을 때 실행
        if (isPressed && (Time.realtimeSinceStartup - lastTime) > pressInterval)
        {
            if (currentPressType == PressType.Plus)
                PlusButtonClicked();
            else if (currentPressType == PressType.Minus)
                MinusButtonClicked();

            // 마지막으로 숫자가 변경된 시간을 현재 시간으로 갱신
            lastTime = Time.realtimeSinceStartup;
        }
    }

    // 초기화 함수
    void Init()
    {
        number = 0;
        numberText.text = number.ToString();
    }

    // + 버튼을 눌렀을 때 호출함수, 숫자 증가 
    public void OnPointerDownPlus()
    {
        lastTime = Time.realtimeSinceStartup;   // 현재 시간을 기록 (0.1초마다 숫자가 변하도록 기준점 설정)
        isPressed = true;                       
        currentPressType = PressType.Plus;      
    }

    // - 버튼을 눌렀을 때 호출함수, 숫자 감소 
    public void OnPointerDownMinus()
    {
        lastTime = Time.realtimeSinceStartup;
        isPressed = true;
        currentPressType = PressType.Minus;
    }

    // 버튼을 떼었을 때 호출함수, 숫자 변경 동작을 중지한다.
    public void OnPointerUp()
    {
        isPressed = false;
        currentPressType = PressType.None;
    }

    public void PlusButtonClicked()
    {
        number += 1;
        numberText.text = number.ToString();
    }

    public void MinusButtonClicked()
    {
        number -= 1;
        numberText.text = number.ToString();
    }

    // 초기화 함수
    public void ResetButtonClicked()
    {
        Init();
    }
}
