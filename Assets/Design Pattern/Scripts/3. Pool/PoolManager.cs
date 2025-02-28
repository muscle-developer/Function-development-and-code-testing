using System.Collections.Generic; 
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; // 싱글톤 패턴을 위한 정적 인스턴스

    // 특정 태그(string)로 구분되는 오브젝트 풀을 저장하는 딕셔너리
    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        // 싱글톤 패턴 적용 (하나의 PoolManager만 존재하도록 설정)
        Instance = this;
    }

    // 새로운 오브젝트 풀을 생성하는 함수
    public void CreatePool(string name, GameObject prefab, int size)
    {
        // 같은 이름의 오브젝트 풀이 존재하지 않는 경우에만 생성
        if (!poolDictionary.ContainsKey(name))
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // 지정된 크기만큼 오브젝트를 생성하여 비활성화 후 큐에 추가
            for (int i = 0; i < size; i++)
            {
                GameObject obj = Instantiate(prefab); // 프리팹 인스턴스화
                obj.SetActive(false); // 비활성화하여 풀에 대기 상태로 둠
                objectPool.Enqueue(obj); // 큐에 추가
            }

            // 생성한 오브젝트 풀을 딕셔너리에 등록
            poolDictionary.Add(name, objectPool);
        }
    }

    // 오브젝트 풀에서 오브젝트를 가져오는 함수
    public GameObject GetObjectFromPool(string name)
    {
        // 해당 이름의 오브젝트 풀이 존재하고, 큐에 오브젝트가 남아있는 경우
        if (poolDictionary.ContainsKey(name) && poolDictionary[name].Count > 0)
        {
            GameObject obj = poolDictionary[name].Dequeue(); // 큐에서 오브젝트 가져오기
            obj.SetActive(true); // 오브젝트 활성화
            return obj;
        }

        return null; // 풀에 사용 가능한 오브젝트가 없으면 null 반환
    }

    // 사용이 끝난 오브젝트를 다시 오브젝트 풀에 반환하는 메서드
    public void ReturnObjectToPool(string name, GameObject obj)
    {
        obj.SetActive(false); // 오브젝트 비활성화
        poolDictionary[name].Enqueue(obj); // 다시 큐에 추가하여 재사용 가능하게 만듦
    }
}
