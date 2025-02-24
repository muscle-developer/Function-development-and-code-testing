using UnityEngine;

public class AudioManagerObserver : MonoBehaviour, IObserver
{
    public void OnNotify(int score)
    {
        Debug.Log("효과음 재생! 🎵");
    }
}
