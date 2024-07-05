using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIPopup : MonoBehaviour
{
    public virtual void Open()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Refresh()
	{
		// 이곳에서는 아무기능도 하지 않는다.
        // 각각의 팝업에서 알맞은 용도로 Refresh를 사용하자.
	}

    public virtual void Close()
	{
        ClosePopup();
	}

    // 닫기 기능
    protected virtual void ClosePopup(bool foreSkip = false)
    {
        // 열리고 있는중이거나, 닫히는중이면 실행하지 않는다.
        if(!this.gameObject.activeSelf)
			return;

		this.gameObject.SetActive(false);
    }
}
