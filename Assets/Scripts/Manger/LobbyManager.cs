
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    [SerializeField] 
    private Image fadeImage; // 화면 전환 시 페이드 효과를 담당하는 이미지
    [SerializeField]
    private TMP_InputField input_Nickname; // 닉네임을 입력받는 입력 필드
    [SerializeField]
    private Button createButton; // 게임 시작 버튼
    [SerializeField]
    private TMP_Text nickNameText; // 화면에 표시할 닉네임

    [SerializeField]
    private GameObject nickNameCreatePopup; // 닉네임 생성 팝업
    [SerializeField]
    private GameObject nickNamePanel;    // 닉네임 표시 UI

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
    }

    // 닉네임 입력 필드의 값이 변경될 때 호출
    public void OnInputFieldValueChanged()
    {
        // 닉네임이 입력된 경우에만 시작 버튼 활성화
        createButton.interactable = input_Nickname.text.Length > 0;
    }

    // 게임 시작 버튼 클릭 시 호출
    public void OnClickBtnCreate()
    {
        if (co == null) // 코루틴 중복 실행 방지
        {
            co = StartCoroutine(SceneTrans("FunctionScene")); // 씬 전환 코루틴 실행
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

