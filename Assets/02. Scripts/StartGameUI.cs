using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGameUI : MonoBehaviour
{
    public GameObject gameStartButton;
    public TMP_InputField tmpInputField;
    public GameObject scoreTextObject;
    public GameObject healthTextObject;
    public GameObject startExitButton;

    private Text scoreText;
    private Text healthText;

    void Start()
    {
        
        // GameStart 버튼에 클릭 리스너 추가
        gameStartButton.GetComponent<Button>().onClick.AddListener(GameStart);

        // StartExitButton에 클릭 리스너 추가
        startExitButton.GetComponent<Button>().onClick.AddListener(StartExitGame);

        // StartExitButton은 초기에는 비활성화
        startExitButton.SetActive(false);

        // scoreTextObject와 healthTextObject에서 Text 컴포넌트 가져오기
        scoreText = scoreTextObject.GetComponent<Text>();
        healthText = healthTextObject.GetComponent<Text>();

        // 초기 UI 가시성 설정
        SetUIVisibility(true);
    }

    void GameStart()
    {
        Debug.Log("GameStart button clicked!");
        // GameStart 버튼 클릭 시 적용되는 로직
        // 시작 UI 숨기기
        SetUIVisibility(false);

        // healthText가 null이 아닌지 확인
        if (healthText != null)
        {
            // Set the initial score and health from input fields
            GameManager.instance.score = int.Parse(tmpInputField.text);
            GameManager.instance.health = int.Parse(healthText.text);
        }
        else
        {
            Debug.LogError("healthText is null.");
        }

        // 게임 재개
        Time.timeScale = 1f;

        
    }

      public void StartExitGame()
    {
        Debug.Log("StartExitGame button clicked!");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode(); // 에디터 모드에서는 에디터를 종료
#else
        Application.Quit(); // 빌드된 런타임에서는 실제로 게임을 종료
#endif
    }

    void SetUIVisibility(bool isVisible)
    {
        
        // GameStart 버튼과 StartExitGame 버튼 가시성 설정
        gameStartButton.SetActive(isVisible);
        startExitButton.SetActive(isVisible);

        // tmpInputField, scoreTextObject, healthTextObject 가시성 설정
        tmpInputField.gameObject.SetActive(!isVisible);
        scoreTextObject.SetActive(!isVisible);
        healthTextObject.SetActive(!isVisible);
    }
}
