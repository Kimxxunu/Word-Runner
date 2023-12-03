using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SimpleHelvetica Word;
    public float WordSpeed = 20f;
    public float ShootInterval = 5f;

    private float lastShootTime;
    private bool isDead = false; // 죽은 상태 여부를 나타내는 변수

    string[] words = { "apple", "nice", "good", "yes", "why", "sunwoo", "wonderful", "mix", "ice", "bag" };

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
    }
}

}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public SimpleHelvetica Word; // SimpleHelvetica를 사용하도록 수정
//     public float WordSpeed = 20f;
//     public float ShootInterval = 5f;

//     private float lastShootTime;

    
//     // words 배열 정의
//     string[] words = { "apple", "nice", "good", "yes", "why", "sunwoo", "wonderful", "mix", "ice", "bag" };

//     void Update()
//     {
//         // 게임 시작 후 경과 시간에 따라 ShootInterval 조정
//         float elapsedTime = Time.time;

//         if (Time.time - lastShootTime >= ShootInterval)
//         {
//             Shoot();
//             lastShootTime = Time.time;
//         }

//         if (GameManager.instance.health <= 0)
//         {
//             Time.timeScale = 0.1f;
//         }
//     }
    
//     public void reduceShootInterval()
//     {
//         float softcap = 3f; // ShootInterval의 softcap 설정
//         float hardcap = 2f; // ShootInterval의 hardcap 설정

//         if (ShootInterval > softcap)
//         {
//             // softcap보다 클 때는 정상적으로 감소
//             ShootInterval = Mathf.Max(softcap, ShootInterval - 0.2f);
//         }
//         else
//         {
//             // softcap 이하일 때는 더 느리게 감소
//             ShootInterval = Mathf.Max(hardcap, ShootInterval - 0.7f);
//         }
//     }

//     void Shoot()
//     {
//         // SimpleHelvetica 인스턴스를 생성하고 GenerateRandomWord() 메서드 호출
//         SimpleHelvetica word = Instantiate(Word, transform.position + new Vector3(0f, 10f, 100f), Quaternion.identity);
//         //word.GenerateRandomWord();  // 단어 생성 및 표시
//         word.Text = words[Random.Range(0, words.Length)];
//         word.name = word.Text;
//         word.GenerateText();

//         // 랜덤한 위치로 이동
//         float randomX = Random.Range(-30f, 30f);
//         float randomY = Random.Range(10f, 45f);
        
//         Vector3 randomOffset = new Vector3(randomX, randomY, 0f);
//         word.transform.position += randomOffset;

//         // 플레이어 위치에 조금 더 높은 위치로 바라보도록 수정
//         Vector3 playerPositionWithHeight =
//             new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
//         word.transform.LookAt(playerPositionWithHeight);

//         // 총알에 힘을 가해서 날아가게 함
//         Rigidbody wordRb = word.GetComponent<Rigidbody>();
//         if (wordRb != null)
//         {
//             wordRb.velocity = (playerPositionWithHeight - word.transform.position).normalized * WordSpeed;
//         }
//     }
// }