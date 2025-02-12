using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
	public static UIManager Instance
	{
		get{
			if(instance == null)
				instance = GameObject.FindObjectOfType<UIManager>();
			return instance;
		}
	}

    // 특정 이름의 Canvas를 찾아서 화면에 표시한다.
    public Canvas ShowCanvas(string name)
	{
		Canvas toReturn = null;

		var target = GameObject.Find(name);
		if(target != null)
		{
			toReturn = target.GetComponent<Canvas>();
			target.GetComponent<Canvas>().enabled = true;
		}
		else
		{
			Debug.LogWarning("The canvas with name of " + name + "isn't exist.");
		}

		return toReturn;
	}

	public void HideCanvas(string name)
	{
		var target = GameObject.Find(name);
		if(target != null)
		{
			target.GetComponent<Canvas>().enabled = false;		
		}
		else
		{
			Debug.LogWarning("The canvas with name of " + name + "isn't exist.");
		}
	}
}
