using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class OptionPopup : UIPopup
{
    [SerializeField]
	private TMP_Dropdown languageDropdown;

    public override void Open()
    {
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }

     public override void Refresh()
     {
        languageDropdown.ClearOptions();
     }

    public void OnLanguageChange(int index)
    {
        string selectedLanguage = "";

        switch (index)
        {
            case 0: selectedLanguage = "ko"; break; // 한국어
            case 1: selectedLanguage = "en"; break; // 영어
            case 2: selectedLanguage = "ja"; break; // 일본어
        }

        LanguageManager.Instance.LoadLanguage(selectedLanguage);
    }
}
