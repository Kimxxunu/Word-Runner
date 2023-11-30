using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SimpleHelvetica Word; // SimpleHelvetica를 사용하도록 수정
    public float WordSpeed = 20f;
    public float ShootInterval = 5f;

    private float lastShootTime;

    // words 배열 정의
    string[] words = { "apple", "nice", "good", "yes", "why", "sunwoo", "wonderful", "mix", "ice", "bag" };

    void Update()
    {
        Debug.Log("현재 interval + " + ShootInterval);
        // 게임 시작 후 경과 시간에 따라 ShootInterval 조정
        float elapsedTime = Time.time;
        float softcap = 2f; // ShootInterval의 softcap 설정
        float hardcap = 1f; // ShootInterval의 hardcap 설정

        if (ShootInterval > softcap)
        {
            // softcap보다 클 때는 정상적으로 감소
            ShootInterval = Mathf.Max(softcap, ShootInterval * Mathf.Pow(0.9f, Mathf.FloorToInt(elapsedTime / 60f)));
        }
        else
        {
            // softcap 이하일 때는 더 느리게 감소
            ShootInterval = Mathf.Max(hardcap, ShootInterval * Mathf.Pow(0.95f, Mathf.FloorToInt(elapsedTime / 60f)));
        }

        if (Time.time - lastShootTime >= ShootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }


    void Shoot()
    {
        // SimpleHelvetica 인스턴스를 생성하고 GenerateRandomWord() 메서드 호출
        SimpleHelvetica word = Instantiate(Word, transform.position + new Vector3(0f, 10f, 100f), Quaternion.identity);
        //word.GenerateRandomWord();  // 단어 생성 및 표시
        word.Text = words[Random.Range(0, words.Length)];
        word.name = word.Text;
        word.GenerateText();

        // 랜덤한 위치로 이동
        float randomX = Random.Range(-30f, 30f);
        float randomY = Random.Range(10f, 45f);
        
        Vector3 randomOffset = new Vector3(randomX, randomY, 0f);
        word.transform.position += randomOffset;

        // 플레이어 위치에 조금 더 높은 위치로 바라보도록 수정
        Vector3 playerPositionWithHeight =
            new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        word.transform.LookAt(playerPositionWithHeight);

        // 총알에 힘을 가해서 날아가게 함
        Rigidbody wordRb = word.GetComponent<Rigidbody>();
        if (wordRb != null)
        {
            wordRb.velocity = (playerPositionWithHeight - word.transform.position).normalized * WordSpeed;
        }
    }
}