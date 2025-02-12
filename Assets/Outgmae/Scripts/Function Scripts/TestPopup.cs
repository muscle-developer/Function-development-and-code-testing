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
	private TMP_Text noticeText;
	[SerializeField]
	private RectTransform configureParentTransform;
	[SerializeField]
	private RectTransform noticeParentTransform;
    public override void Awake()
    {
        base.Awake();
    }

	public void Update()
	{
		CheckNoticeLimitText(noticeText.text);
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
			configureParentTransform.SetBottom(-450f);
			noticeParentTransform.SetTop(450f);
			arrowToggle.image.sprite = arrowImageList[0];
			noticeText.overflowMode = TextOverflowModes.Overflow;
		}
		else 
		{
			configureParentTransform.SetBottom(-220f);
			noticeParentTransform.SetTop(220f);
			arrowToggle.image.sprite = arrowImageList[1];
			noticeText.overflowMode = TextOverflowModes.Ellipsis;
		}
	}

	private bool CheckNoticeLimitText(string notice)
	{
		bool isViolating = false;

		if(notice.Length > 150)
            isViolating = true;

		return isViolating;
	}
}
