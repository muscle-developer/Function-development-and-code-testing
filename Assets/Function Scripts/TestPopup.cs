using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestPopup : UIPopup
{
	[SerializeField]
	private Toggle arrowToggle;
	[SerializeField]
	private List<Sprite> arrowImageList; 
	[SerializeField]
	private TMP_Text guildNoticeText;
	[SerializeField]
	private RectTransform guildConfigureParentTransform;
	[SerializeField]
	private RectTransform guildMemberParentTransform;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Open()
    {
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }

    public void ToggleExpand()
	{
		if(arrowToggle.isOn)
		{
			guildConfigureParentTransform.SetBottom(-450f);
			guildMemberParentTransform.SetTop(450f);
			arrowToggle.image.sprite = arrowImageList[0];
			guildNoticeText.overflowMode = TextOverflowModes.Overflow;
		}
		else 
		{
			guildConfigureParentTransform.SetBottom(-220f);
			guildMemberParentTransform.SetTop(220f);
			arrowToggle.image.sprite = arrowImageList[1];
			guildNoticeText.overflowMode = TextOverflowModes.Ellipsis;
		}
	}
}
