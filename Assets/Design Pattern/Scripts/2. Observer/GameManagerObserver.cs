using System.Collections.Generic;
using UnityEngine;

// 옵저버 인터페이스 (Observer) -> GameManager에서 발생한 이벤트를 감지하는 모든 객체가 이 인터페이스를 구현해야 함.
public interface IObserver
{
    // 옵저버가 알림을 받을 때 호출되는 메서드
    void OnNotify(int score);
}

// Subject (이벤트 발행자) -> 게임의 상태 변화를 감지하고, 모든 옵저버에게 알림을 보내는 역할
public class GameManagerObserver : MonoBehaviour
{
    // 옵저버 리스트: 이벤트를 구독한 객체들을 저장하는 리스트
    private List<IObserver> observers = new List<IObserver>();

    // 현재 점수 값 (플레이어가 점수를 얻으면 증가)
    private int score = 0;

    // 옵저버를 추가하는 메서드 (구독 기능)
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    // 옵저버를 제거하는 메서드 (구독 해제 기능)
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    // 모든 옵저버에게 이벤트가 발생했음을 알리는 메서드
    public void NotifyObservers()
    {
        foreach (var observer in observers) // 등록된 모든 옵저버에게 알림
        {
            observer.OnNotify(score); // 각 옵저버의 OnNotify() 실행
        }
    }

    // 플레이어가 점수를 획득했을 때 호출되는 메서드
    public void PlayerScored()
    {
        score += 10; // 점수 증가
        Debug.Log($"플레이어 점수: {score}");
        
        NotifyObservers(); // 점수 변화 이벤트 발생 → 모든 옵저버에게 알림
    }
}
