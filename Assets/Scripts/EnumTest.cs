using UnityEngine;

public class EnumTest : MonoBehaviour
{
    // 방향을 나타내는 Enum 정의
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
    }

    
}
