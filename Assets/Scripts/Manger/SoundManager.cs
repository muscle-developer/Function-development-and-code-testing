using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
	public static SoundManager Instance
	{
		get{
			if(instance == null)
				instance = GameObject.FindObjectOfType<SoundManager>();
			return instance;
		}
	}

    public void MuteAll()
	{
		AudioListener.volume = 0f;
	}

	public void ResetAll()
	{
		AudioListener.volume = 1f;
	}
}
