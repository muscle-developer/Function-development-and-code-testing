using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleManager : MonoBehaviour
{
    bool isChanging;

    private void ChangeLocale(int index)
    {   
        if(!isChanging)
            return;

        StartCoroutine(ChangeCorountine(index));
    }

    private IEnumerator ChangeCorountine(int index)
    {
        isChanging = true;

        // Localization 기능이 초기화 됐는지? 안됐으면 초기화 하고 시작하자
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];

        isChanging = false;
    }
}
