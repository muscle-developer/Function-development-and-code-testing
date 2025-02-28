using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f; // 2초 후 자동 반환

    private void OnEnable()
    {
        // 일정 시간이 지나면 자동 반환
        Invoke(nameof(ReturnToPool), lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌 시 풀로 반환
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        // 오브젝트 풀로 반환하기
        PoolManager.Instance.ReturnObjectToPool("Bullet", this.gameObject);
    }
}
