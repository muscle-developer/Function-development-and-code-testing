using UnityEngine;
using System.IO; // 저장 등 파일 관리를 위해 추가

[System.Serializable]
public class PlayerDataJson
{
    public string name;
    public int age;
    public int level;
    public bool isDead;
    public string[] items;
}

public class JsonFileManager : MonoBehaviour
{
    private string filePath; // JSON 파일 경로

    void Start()
    {
        // filePath = Path.Combine(Application.persistentDataPath, "playerData.json"); // 저장할 경로 설정
        filePath = Path.Combine(Application.dataPath, "Outgame", "Scripts", "Json", "playerData.json");
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);

        // 예시 데이터 생성
        PlayerDataJson playerData = new PlayerDataJson()
        {
            name = "Player",
            age = 25,
            level = 1,
            isDead = false,
            items = new string[] { "Apple", "Sword", "Shield" }
        };

        // JSON 저장
        SaveJson(playerData);
        
        // JSON 불러오기
        PlayerDataJson loadedData = LoadJson();
        
        // 결과 확인
        Debug.Log($"Loaded Player Data: Name={loadedData.name}, Age={loadedData.age}, Level={loadedData.level}, IsDead={loadedData.isDead}");
    }

    // JSON을 파일에 저장하는 함수
    void SaveJson(PlayerDataJson data)
    {
        string jsonData = JsonUtility.ToJson(data, true); // JSON 변환 (true: 보기 좋게 정렬)
        File.WriteAllText(filePath, jsonData); // 파일로 저장
        Debug.Log("JSON Saved: " + filePath);
    }

    // JSON 파일을 불러오는 함수
    PlayerDataJson LoadJson()
    {
        if (File.Exists(filePath)) // 파일이 존재하는지 확인
        {
            string jsonData = File.ReadAllText(filePath); // 파일에서 읽기
            return JsonUtility.FromJson<PlayerDataJson>(jsonData); // JSON 역직렬화
        }
        else
        {
            Debug.LogWarning("JSON 파일이 존재하지 않습니다.");
            return new PlayerDataJson(); // 기본값 반환
        }
    }
}
