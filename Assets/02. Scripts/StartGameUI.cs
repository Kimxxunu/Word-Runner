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

    

    public void GameStart()
    {
        Debug.Log("GameStart button clicked!");

        // PlayerController를 찾아서 StartGame 메서드 호출
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.StartGame();
            playerController.isDead=false;
        }
        else
        {
            Debug.LogError("PlayerController not found in the scene.");
        }

        GameManager.instance.score=0;
        GameManager.instance.health=3;
        // GameStart 버튼 클릭 시 적용되는 로직
        // 시작 UI 숨기기
        SetUIVisibility(false);

        // 게임 재개
        Time.timeScale = 1f;

        CameraRotation camera = Camera.main.GetComponent<CameraRotation>();
    if (camera != null)
    {
        camera.StartCamera();
    }

       
        // Fast Run 애니메이션을 재생시키는 코드
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
        animator.SetTrigger("Run"); // 53번째 줄
        }

        // MapMovement 실행
        MapMovement mapMovement = GameObject.Find("bridge1").GetComponent<MapMovement>();
        if (mapMovement != null)
        {
            mapMovement.StartMovement();
        }

        // MapCreator 실행
        MapCreator mapCreator = GameObject.Find("MapCreator").GetComponent<MapCreator>();
        if (mapCreator != null)
        {
            mapCreator.StartCreation();
        }

        // MoveBridge 실행
        MoveBridge moveBridge = GameObject.Find("bridge2").GetComponent<MoveBridge>();
        if (moveBridge != null)
        {
            moveBridge.StartMovement();
        }
        
    
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

