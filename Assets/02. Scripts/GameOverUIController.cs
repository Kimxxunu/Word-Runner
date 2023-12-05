using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public Button RestartButton;  // 다시 시작 버튼
    public Button ExitButton;     // 종료 버튼
    private StartGameUI startGameUI; // StartGameUI 클래스 인스턴스를 저장할 변수
    public GameObject highScoreObject;
    public GameObject currentScoreObject;

    private Text highScoreText;
    private Text CurrentScoreText;

    void Start()
    {
        // UI 초기화
        SetUIVisibility(false);

        // StartGameUI 스크립트 할당
        startGameUI = GetComponent<StartGameUI>();

        // 다시 시작 버튼에 클릭 리스너 추가
        RestartButton.onClick.AddListener(RestartGame);

        // 종료 버튼에 클릭 리스너 추가
        ExitButton.onClick.AddListener(ExitGame);

        highScoreText = highScoreObject.GetComponent<Text>();
        CurrentScoreText = currentScoreObject.GetComponent<Text>();
    }

    // 게임 다시 시작 메소드
    void RestartGame()
    {
    RestartButton.gameObject.SetActive(false);
    ExitButton.gameObject.SetActive(false);
    highScoreObject.SetActive(false);
    currentScoreObject.SetActive(false);
        // StartGameUI 클래스의 GameStart 메소드 호출
    if (startGameUI != null)
    {
        startGameUI.GameStart();
    }
    else
    {
        Debug.LogError("StartGameUI not found in the scene.");
    }


    }

    // 게임 종료 메소드
    void ExitGame()
    {
        // 어플리케이션 종료 (빌드된 게임에서 동작)
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // UI의 가시성을 설정하는 메소드
    void SetUIVisibility(bool isVisible)
    {
        RestartButton.gameObject.SetActive(isVisible);
        ExitButton.gameObject.SetActive(isVisible);
        highScoreObject.SetActive(isVisible);
        currentScoreObject.SetActive(isVisible);
        // 여기에 다른 UI 요소들을 추가하고 설정할 수 있습니다.
    }

    // Death 상태를 감지하는 메소드 (외부에서 호출되어야 함)
    public void OnPlayerDeath()
    {
        // 죽은 상태일 때 UI 보이기
        SetUIVisibility(true);
    }
}
