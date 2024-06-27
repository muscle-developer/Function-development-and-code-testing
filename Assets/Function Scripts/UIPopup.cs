using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIPopup : MonoBehaviour
{
    public virtual void Open()
    {

    }

    public virtual void Refresh()
	{
		// 이곳에서는 아무기능도 하지 않는다.
        // 각각의 팝업에서 알맞은 용도로 Refresh를 사용하자.
	}

    public virtual void Close()
	{
		
	}
}
