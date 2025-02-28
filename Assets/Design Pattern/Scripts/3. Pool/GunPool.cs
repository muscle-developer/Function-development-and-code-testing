using UnityEngine;

public class GunPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int poolSize = 10; // 총알 풀 크기

    private void Start()
    {
        // 총알 풀 생성
        PoolManager.Instance.CreatePool("Bullet", bulletPrefab, poolSize);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // 풀에서 오브젝트 가져오기
        GameObject bullet = PoolManager.Instance.GetObjectFromPool("Bullet");

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.LookAt(firePoint.position + firePoint.forward);
        }
        else
        {
            Debug.Log("No available bullets in pool!");
        }
    }
}
