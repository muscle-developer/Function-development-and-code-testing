using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class OptionPopup : UIPopup
{
    [SerializeField]
	private TMP_Dropdown languageDropdown;
    private int index = 0;

    public override void Open()
    {
        base.Open();
        Refresh();
    }

    public override void Close()
    {
        base.Close();
    }

     public override void Refresh()
     {
        languageDropdown.ClearOptions();
        
        languageDropdown.AddOptions(new List<string> { "한국어", "English", "日本語" });

        if (index >= 0 && index < languageDropdown.options.Count)
        {
            switch (index)
            {
                case 0:
                    languageDropdown.options[0].text = "한국어";
                break;
                case 1: 
                    languageDropdown.options[1].text = "English";
                break;
                case 2: 
                    languageDropdown.options[2].text = "日本語";
                break;
                default:
                    languageDropdown.options[0].text = "한국어";
                break;
            }
        }
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
