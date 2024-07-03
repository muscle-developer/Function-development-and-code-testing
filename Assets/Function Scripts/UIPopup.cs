using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIPopup : MonoBehaviour
{
    [SerializeField]
	protected bool addBackground = true;
    [SerializeField]
	protected bool allowCloseByBackgroundClick = true;
    protected GameObject popupBack = null;
    protected bool isOpening = false;
    protected bool isClosing = false;
    public virtual void Open()
    {
        this.gameObject.SetActive(true);
		
		isOpening = true;

        // if(addBackground)
		// {
		// 	AddBackground();

		// 	var image = popupBack.GetComponent<Image>();
		// 	if (image != null)
		// 		image.color = new Color(image.color.r, image.color.g, image.color.b, 150f / 255f);
		// }
    }

    public virtual void Refresh()
	{
		// 이곳에서는 아무기능도 하지 않는다.
        // 각각의 팝업에서 알맞은 용도로 Refresh를 사용하자.
	}

    public virtual void Close()
	{
        Close();
	}

    // 닫기 기능
    public virtual void Close(bool foreSkip = false)
    {
        // 열리고 있는중이거나, 닫히는중이면 실행하지 않는다.
        if(isOpening || isClosing || !this.gameObject.activeSelf)
			return;

		isClosing = true;
		this.gameObject.SetActive(false);

        // if(addBackground)
		// {
		// 	if(popupBack == null)
		// 	{
		// 		AddBackground();
		// 	}
			
		// 	var image = popupBack.GetComponent<Image>();
		// 	if (image != null)
		// 		image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
		// }
    }

    // protected virtual void AddBackground()
	// {
	// 	if(popupBack == null)
	// 	{
	// 		popupBack = Instantiate<Transform>(Resources.Load<Transform>("Popup Back")).gameObject;
	// 		popupBack.transform.SetParent(this.transform.parent, false);
	// 		popupBack.transform.SetSiblingIndex(transform.GetSiblingIndex());
	// 		if(allowCloseByBackgroundClick)
	// 			popupBack.GetComponent<Button>().onClick.AddListener(Close);
	// 	}

	// 	popupBack.gameObject.SetActive(true);
    // }
}
