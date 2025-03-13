using UnityEngine;
using TMPro;

public class OptionPopup : UIPopup
{
    [SerializeField]
	private TMP_Dropdown langugateDropDown;

    public override void Open()
    {
        base.Open();
        Refresh();
    }

    public override void Close()
    {
        base.Close();
    }

    // public void Refresh()
    // {
    //     this.langugateDropDown.ClearOptions();
    //     foreach(var tmp in Enum.GetValues(typeof(OptionManager.LanguageModeType)))
	// 	{
	// 		var stringToUse = tmp.ToString();

	// 		if(stringToUse == "zh_cht")
	// 		{
	// 			this.langugateDropDown.options.Add(new TMP_Dropdown.OptionData("繁體中文"));
	// 		}
	// 		else if(stringToUse == "zh_chs")
	// 		{
	// 			this.langugateDropDown.options.Add(new TMP_Dropdown.OptionData("简体中文"));
	// 		}
	// 		else if(stringToUse == "th")
	// 		{
	// 			this.langugateDropDown.options.Add(new TMP_Dropdown.OptionData("Thai"));
	// 		}
	// 		else
	// 		{
	// 			var textTouse = new CultureInfo(stringToUse).NativeName;
	// 			var tmp2 = new TMP_Dropdown.OptionData(textTouse.First().ToString().ToUpperInvariant() + textTouse.Substring(1));
	// 			this.langugateDropDown.options.Add(tmp2);
	// 		}
	// 	}
	// 	this.langugateDropDown.value = (int)OptionManager.Instance.Language;
	// 	this.langugateDropDown.RefreshShownValue();
    // }

    // public void OnLangguageDropDown(int id)
	// {
	// 	if(this.langugateDropDown.value == (int)OptionManager.Instance.Language)
	// 		return;
			
	// 	UIManager.Instance.ShowAlertLocalized(
	// 		"message_change_language",
	// 		() => {
	// 			OptionManager.Instance.Language = (OptionManager.LanguageModeType)id;
	// 			PlayerPrefs.SetInt("is_server_lanugage_set", 0);

	// 			if(ServerNetworkManager.GetServerType == ServerNetworkManager.ServerType.Korea)
	// 				OptionManager.Instance.ChatLanguage = OptionManager.ChatLanguageModeType.ko;
	// 			else
	// 				OptionManager.Instance.ChatLanguage = OptionManager.ChatLanguageModeType.global;

	// 			ChatManager.Instance.Disconnect();

	// 			SceneChangeManager.Instance.LoadMainGame(true, true);
	// 		},
	// 		() => {
	// 			this.langugateDropDown.value = (int)OptionManager.Instance.Language;
	// 		}
	// 	);
	// }
}
