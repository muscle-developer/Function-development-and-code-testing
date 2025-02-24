using UnityEngine;
using TMPro;

public class UIManagerObserver : MonoBehaviour, IObserver
{
    // 인터페이스 사용
    public void OnNotify(int score)
    {
        Debug.Log($"UI 업데이트: 점수 {score}");
    }

    // 델리게이트, 액션 이벤트 사용

    [SerializeField]
    private TMP_Text uiScoreText;

    [SerializeField]
    private TMP_Text mainViewScoreText;

    private void OnEnable()
    {
        // 이벤트 구독 (플레이어 점수가 변경되면 UI 업데이트)
        PlayerObserver.OnScoreChanged += UpdateScoreUI;
    }

    private void OnDisable()
    {
        // 이벤트 구독 해제 (메모리 누수 방지)
        PlayerObserver.OnScoreChanged -= UpdateScoreUI;
    }

    private void UpdateScoreUI(int newScore)
    {
        uiScoreText.text = $"UI 점수: {newScore}";
        mainViewScoreText.text = $"Main 점수: {newScore}";
    }
}
