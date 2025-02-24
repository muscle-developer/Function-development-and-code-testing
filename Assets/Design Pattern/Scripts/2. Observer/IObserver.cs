using System.Collections.Generic;
using UnityEngine;

// 옵저버 인터페이스
public interface IObserver
{
    void OnNotify(int score);
}

// Subject (이벤트 발행자)
public class GameManagerObserver : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();
    private int score = 0;

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(score);
        }
    }

    public void PlayerScored()
    {
        score += 10;
        Debug.Log($"플레이어 점수: {score}");
        NotifyObservers(); // 모든 구독자에게 알림
    }
}
