using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class GoogleSheetsLoader : MonoBehaviour
{
    // 금칙어 리스트를 저장할 변수
    private List<string> bannedWords = new List<string>();

    // Google Sheets에서 CSV 형식으로 가져올 공개 링크 (CSV 다운로드 URL)
    private string googleSheetsUrl = "https://docs.google.com/spreadsheets/d/11qnAwaWJCf1O6nQ3tgJ54G1kNClQ-SHFWCNY-gstx2s/export?format=csv";

    void Start()
    {
        // 게임이 시작될 때 Google Sheets에서 금칙어 데이터를 불러옴
        StartCoroutine(LoadBannedWords());
    }

    // Google Sheets에서 CSV 데이터를 가져오는 코루틴
    IEnumerator LoadBannedWords()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(googleSheetsUrl)) // HTTP GET 요청 생성
        {
            yield return request.SendWebRequest(); // 요청을 보내고 응답을 기다림

            if (request.result == UnityWebRequest.Result.Success) // 요청 성공 시
            {
                string csvData = request.downloadHandler.text; // 응답 데이터를 문자열로 저장
                Debug.Log("CSV 데이터 로드 완료:\n" + csvData); // 데이터 확인용 로그
                ParseBannedWords(csvData); // CSV 데이터를 분석하여 금칙어 리스트에 추가
            }
            else // 요청 실패 시
            {
                Debug.LogError("금지어 데이터를 불러오지 못했습니다: " + request.error);
            }
        }
    }

    // CSV 데이터를 파싱하여 금칙어 리스트에 저장하는 함수
    private void ParseBannedWords(string csv)
    {
        bannedWords.Clear(); // 기존 리스트 초기화 (중복 방지)
        string[] lines = csv.Split('\n'); // 줄 단위로 데이터를 분리

        foreach (string line in lines)
        {
            string word = line.Trim(); // 앞뒤 공백 제거 (개행 문자 포함 가능)
            if (!string.IsNullOrEmpty(word)) // 빈 줄이 아니면 추가
            {
                Debug.Log("금칙어 추가됨: " + word); // 데이터 확인용 로그
                bannedWords.Add(word);
            }
        }
    }

    // 입력된 텍스트에 금칙어가 포함되어 있는지 검사하는 함수
    public bool IsBannedWord(string text)
    {
        foreach (string word in bannedWords)
        {
            Debug.Log($"닉네임 검사: {text} vs {word}"); // 비교 과정 확인용 로그

            if (text.Contains(word)) // 닉네임에 금칙어 포함 여부 체크
            {
                Debug.Log("금칙어 발견됨! 닉네임 사용 불가");
                return true; // 금칙어가 포함된 경우 true 반환
            }
        }
        return false; // 금칙어가 포함되지 않은 경우 false 반환
    }
}
