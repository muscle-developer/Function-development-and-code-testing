using UnityEngine;

public class GameStarterObserver : MonoBehaviour
{
    [SerializeField]
    private GameManagerObserver gameManager;
    [SerializeField]
    private UIManagerObserver uiManager;
    [SerializeField]
    private AudioManagerObserver audioManager;
    [SerializeField]
    private GameLoggerObserver gameLogger;

    private void Start()
    {
        // 옵저버 등록
        gameManager.AddObserver(uiManager);
        gameManager.AddObserver(audioManager);
        gameManager.AddObserver(gameLogger);

        // 점수 추가 (테스트)
        gameManager.PlayerScored();
    }
}
