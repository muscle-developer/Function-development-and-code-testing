using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PressedPopup : UIPopup
{
    [SerializeField]
    private TMP_Text numberText;
    private int number = 0;

    public override void Open()
    {
        base.Open();  
        Init();
    }

    public override void Close()
    {
        base.Close();
    }

    void Init()
    {
        number = 0;
        numberText.text = number.ToString();
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

    public void ResetButtonClicked()
    {
        Init();
    }
}
