using UnityEngine;

public class GameLoggerObserver : MonoBehaviour, IObserver
{
    public void OnNotify(int score)
    {
        Debug.Log($"[LOG] 플레이어 점수 {score} 기록됨.");
    }
}
