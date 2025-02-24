using UnityEngine;
using System;

public class PlayerObserver : MonoBehaviour
{
    // 플레이어 점수가 변경될 때 발생하는 이벤트
    public static event Action<int> OnScoreChanged;

    private int score;

    public void AddScore(int count)
    {
        score += count;
        Debug.Log($"현재 점수 : {score}");

        // 이벤트 발생 (모든 구독자에게 점수 변경을 알림)
        OnScoreChanged?.Invoke(score);
    }

    public void MinusScore(int count)
    {
        score -= count;
        Debug.Log($"현재 점수 : {score}");

        OnScoreChanged?.Invoke(score);
    }
}
