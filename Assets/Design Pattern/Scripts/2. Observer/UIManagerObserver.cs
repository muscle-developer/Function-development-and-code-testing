using UnityEngine;
using TMPro;

public class UIManagerObserver : MonoBehaviour
{
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
