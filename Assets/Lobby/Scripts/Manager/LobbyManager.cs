using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    [SerializeField] 
    private Image fadeImage; // 화면 전환 시 페이드 효과를 담당하는 이미지
    [SerializeField]
    private TMP_InputField input_Nickname; // 닉네임을 입력받는 입력 필드
    [SerializeField]
    private Button createButton; // 게임 시작 버튼

    [Header("구글 시트")]
    [SerializeField]
    private GoogleSheetsLoader googleSheetsLoader; // Google Sheets 데이터 로드 스크립트

    private Coroutine co = null; // 현재 실행 중인 코루틴을 저장하는 변수 (중복 실행 방지)
    public bool deleteData; // PlayerPrefs 데이터를 초기화할지 여부
    private float fadeDuration = 1f; // 페이드 인/아웃에 걸리는 시간

    void Awake()
    {
        Instance = this;

        // deleteData가 true인 경우 저장된 PlayerPrefs 데이터를 모두 삭제
        if (deleteData)
            PlayerPrefs.DeleteAll();
    }

    private void Start()
    {        
        // 페이드 아웃 효과를 시작
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
        createButton.interactable = false; // 닉네임 생성 버튼 비활성화
    }

    // 닉네임 입력 필드의 값이 변경될 때 호출
    public void OnInputFieldValueChanged()
    {
        // 닉네임이 규칙을 위반했는지를 저장하는 변수
        bool isViolating = false;

        // 닉네임의 각 문자에 대해 검사
        foreach(var tmp in input_Nickname.text)
        {
            // 문자가 알파벳, 숫자, 또는 공백이 아닌 경우 위반으로 간주
            if(!char.IsLetterOrDigit(tmp) && char.IsWhiteSpace(tmp))
                isViolating = true;   
        }

        // 입력된 문자열에서 이모지와 특수문자 제거
        string inputString = input_Nickname.text;
        string outputString = Regex.Replace(inputString, @"[^\w\s]", ""); // \w는 알파벳, 숫자, 밑줄을 의미하고 \s는 공백 문자
        // 특수문자가 제거된 문자열 길이가 1 이하이거나 원본 문자열과 다르면 위반 처리
        if(outputString.Length <= 1 || outputString != inputString)
        {
            isViolating = true;
        }

        // 입력된 닉네임이 1자 이하일 경우 위반 처리
        if(input_Nickname.text.Length <= 1 || input_Nickname.text == "")
            isViolating = true;

        // 구글 시트 URL로 받아올 때: 금지어 필터 적용
        // if (googleSheetsLoader.IsBannedWord(input_Nickname.text))
        //     isViolating = true;

        // txt파일로 받아올 떄 : 금지어 필터 적용
        if (OutgameController.Instance.CheckBlockText(input_Nickname.text))
            isViolating = true;

        // 위반이 있으면 버튼 비활성화, 없으면 활성화
        if(isViolating)
            createButton.interactable = false; // 유효하지 않으면 버튼 비활성화
        else
            createButton.interactable = true;  // 유효하면 버튼 활성화
    }

    // 게임 시작 버튼 클릭 시 호출
    public void OnClickBtnCreate()
    {
        if (co == null) // 코루틴 중복 실행 방지
        {
            co = StartCoroutine(SceneTrans("OutgameScene")); // 씬 전환 코루틴 실행
        }
    }

    // 페이드 아웃 효과 실행 (화면을 점점 투명하게 만듦)
    private IEnumerator FadeOut()
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, 0f, normalizedTime); // 알파값을 0으로 점진적으로 변경
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f; // 완전 투명하게 설정
        fadeImage.color = color;
    }

    // 페이드 인 효과 실행 (화면을 점점 하얗게 만듦)
    private IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, 1f, normalizedTime); // 알파값을 1로 점진적으로 변경
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f; // 완전 불투명하게 설정
        fadeImage.color = color;
    }

    // 씬 전환을 처리하며 페이드 인/아웃 효과를 실행
    // 닉네임을 저장하고 씬을 비활성화 상태로 로드한 뒤 페이드 인 후 활성화
    private IEnumerator SceneTrans(string sceneName)
    {
        input_Nickname.interactable = false; // 씬 전환 중에는 입력 필드 비활성화
        PlayerPrefs.SetString("Nickname", input_Nickname.text); // 입력된 닉네임을 PlayerPrefs에 저장

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName); // 비동기로 씬 로드
        async.allowSceneActivation = false; // 씬 활성화를 일시적으로 막음

        yield return StartCoroutine(FadeIn()); // 페이드 인 효과 실행
        async.allowSceneActivation = true; // 씬 활성화
        
        co = null; // 코루틴 종료 후 초기화
    }
}

