using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SimpleHelvetica Word;
    public float WordSpeed = 20f;
    public float ShootInterval = 5f;
    private bool isStart = false; // 게임이 시작했는가?

    public TMP_InputField tmpInputField; // 입력UI
    private Text scoreText; // 점수UI
    private Text healthText; // 체력UI

    private float lastShootTime;
    public bool isDead = false; // 죽은 상태 여부를 나타내는 변수

    string[] words = { "apple", "nice", "good", "yes", "why", "sunwoo", "wonderful", "mix", "ice", "bag" };

    // 추가된 부분: healthTextObject와 scoreTextObject 정의
    public GameObject healthTextObject;
    public GameObject scoreTextObject;

    void Start()
    {
        // scoreTextObject와 healthTextObject에서 Text 컴포넌트 가져오기
        scoreText = scoreTextObject.GetComponent<Text>();
        healthText = healthTextObject.GetComponent<Text>();

        // 초기 UI 가시성 설정
        SetUIVisibility(false);
    }


    void Update()
    {
        float elapsedTime = Time.time;

        if (!isDead && Time.time - lastShootTime >= ShootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }

        // 죽은 상태일 때 Death 메소드 호출
        if (GameManager.instance.health <= 0)
        {
            Death();
        }

        // 피가 0일 때 게임 시간의 흐름을 늦추는 로직
        if (GameManager.instance.health <= 0)
        {
            Time.timeScale = 0.2f;
        }
    }
    
    public void reduceShootInterval()
    {
        float softcap = 3f;
        float hardcap = 2f;

        if (!isDead && ShootInterval > softcap)
        {
            ShootInterval = Mathf.Max(softcap, ShootInterval - 0.2f);
        }
        else if (!isDead)
        {
            ShootInterval = Mathf.Max(hardcap, ShootInterval - 0.7f);
        }
    }
    
    
    void Shoot()
    {
        if(isStart){
        SimpleHelvetica word = Instantiate(Word, transform.position + new Vector3(0f, 10f, 100f), Quaternion.identity);
        word.Text = words[Random.Range(0, words.Length)];
        word.name = word.Text;
        word.GenerateText();

        float randomX = Random.Range(-30f, 30f);
        float randomY = Random.Range(10f, 45f);
        Vector3 randomOffset = new Vector3(randomX, randomY, 0f);
        word.transform.position += randomOffset;

        Vector3 playerPositionWithHeight = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        word.transform.LookAt(playerPositionWithHeight);

        Rigidbody wordRb = word.GetComponent<Rigidbody>();
        if (wordRb != null)
        {
            wordRb.velocity = (playerPositionWithHeight - word.transform.position).normalized * WordSpeed;
        }

        }
    }

   void Death()
{
    if (!isDead)
    {
        isDead = true; // 죽은 상태로 변경
        // Death 애니메이션 트리거 설정
        GetComponent<Animator>().SetTrigger("Death");

        // 플레이어가 죽으면 맵 이동을 멈추고 맵 생성을 중지
        MapMovement[] mapMovements = FindObjectsOfType<MapMovement>();
        foreach (MapMovement mapMovement in mapMovements)
        {
            mapMovement.StopMovement();
        }

        MapCreator[] mapCreators = FindObjectsOfType<MapCreator>();
        foreach (MapCreator mapCreator in mapCreators)
        {
            mapCreator.StopMapCreation();
        }

        // 게임 오버 UI를 찾아서 표시
        GameOverUIController gameOverUI = FindObjectOfType<GameOverUIController>();
        if (gameOverUI != null)
        {
            gameOverUI.OnPlayerDeath();
        }
        else
        {
            Debug.LogError("GameOverUIController not found in the scene.");
        }

       SetUIVisibility(true);

    }
}

    void SetUIVisibility(bool isVisible)
    {
        // tmpInputField, scoreTextObject, healthTextObject 가시성 설정
        tmpInputField.gameObject.SetActive(!isVisible);
        scoreTextObject.SetActive(!isVisible);
        healthTextObject.SetActive(!isVisible);
    }

    public void StartGame()
    {
        isStart = true;
    }

}
