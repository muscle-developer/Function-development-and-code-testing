using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class GoogleSheetsLoader : MonoBehaviour
{
    private List<string> bannedWords = new List<string>();

    // Google Sheets의 공개 CSV 링크
    private string googleSheetsUrl = "https://docs.google.com/spreadsheets/d/11qnAwaWJCf1O6nQ3tgJ54G1kNClQ-SHFWCNY-gstx2s/export?format=csv";

    void Start()
    {
        StartCoroutine(LoadBannedWords());
    }

    IEnumerator LoadBannedWords()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(googleSheetsUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string csvData = request.downloadHandler.text;
                Debug.Log("CSV 데이터 로드 완료:\n" + csvData); // 🔥 데이터 확인용 로그
                ParseBannedWords(csvData);
            }
            else
            {
                Debug.LogError("금지어 데이터를 불러오지 못했습니다: " + request.error);
            }
        }
    }

    private void ParseBannedWords(string csv)
    {
        bannedWords.Clear(); // 기존 리스트 초기화
        string[] lines = csv.Split('\n'); // 줄 단위로 분리

        foreach (string line in lines)
        {
            string word = line.Trim(); // 앞뒤 공백 제거
            if (!string.IsNullOrEmpty(word))
            {
                Debug.Log("금칙어 추가됨: " + word); // 🔥 데이터 확인용 로그
                bannedWords.Add(word);
            }
        }
    }

    public bool IsBannedWord(string text)
    {
        foreach (string word in bannedWords)
        {
            Debug.Log($"닉네임 검사: {text} vs {word}"); // 🔥 비교 과정 확인용 로그

            if (text.Contains(word)) // 닉네임에 금칙어 포함 여부 체크
            {
                Debug.Log("금칙어 발견됨! 닉네임 사용 불가");
                return true;
            }
        }
        return false;
    }
}
