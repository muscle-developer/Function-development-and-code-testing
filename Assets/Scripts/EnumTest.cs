using UnityEngine;

public class EnumTest : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    /* // 방향을 나타내는 Enum 정의
=======
    // 방향을 나타내는 Enum 정의
>>>>>>> f639bdf (Enum의 관한 내용 정리)
=======
    // 방향을 나타내는 Enum 정의
>>>>>>> f639bdf (Enum의 관한 내용 정리)
    public enum Direction
    {
        Up,     // 0
        Down,   // 1
        Left,   // 2
        Right   // 3
    }

    // 현재 플레이어의 방향
    private Direction playerDirection;

    void Update()
    {
        // 플레이어의 입력에 따라 방향 설정 (예: 화살키 입력)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerDirection = Direction.Up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerDirection = Direction.Down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerDirection = Direction.Left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerDirection = Direction.Right;
        }

        // 플레이어의 방향에 따른 이동 처리
        MovePlayer();
    }

    void MovePlayer()
    {
        // 플레이어의 방향에 따라 이동 코드 작성
        float speed = 5f; // 플레이어 이동 속도 설정

        // 실제 이동 처리
        if (playerDirection == Direction.Up)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (playerDirection == Direction.Down)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (playerDirection == Direction.Left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (playerDirection == Direction.Right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
<<<<<<< HEAD
<<<<<<< HEAD
    } */

    // 플레이어의 상태를 나타내는 Enum 정의
    public enum PlayerState
    {
        Idle,
        Walking,
        Running,
        Jumping
    }

    // 현재 플레이어 상태
    private PlayerState currentState;

    void Start()
    {
        // 초기 상태 설정
        SetPlayerState(PlayerState.Idle);
    }

    void Update()
    {
        // 사용자 입력 또는 게임 로직에 따라 상태 업데이트
        if (Input.GetKey(KeyCode.W))
        {
            SetPlayerState(PlayerState.Walking);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            SetPlayerState(PlayerState.Running);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetPlayerState(PlayerState.Jumping);
        }
        else
        {
            SetPlayerState(PlayerState.Idle);
        }
    }

    // 상태 설정 함수
    void SetPlayerState(PlayerState newState)
    {
        // 현재 상태와 새로운 상태가 같으면 함수 종료
        if (currentState == newState)
        {
            return;
        }

        // 상태에 따라 다른 동작 수행
        switch (newState)
        {
            case PlayerState.Idle:
                // Idle 상태에 대한 동작 수행
                break;

            case PlayerState.Walking:
                // Walking 상태에 대한 동작 수행
                break;

            case PlayerState.Running:
                // Running 상태에 대한 동작 수행
                break;

            case PlayerState.Jumping:
                // Jumping 상태에 대한 동작 수행
                break;
        }

        // 현재 상태 갱신
        currentState = newState;
    }
=======
    }

    
>>>>>>> f639bdf (Enum의 관한 내용 정리)
=======
    }

    
>>>>>>> f639bdf (Enum의 관한 내용 정리)
}
