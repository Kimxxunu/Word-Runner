using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Word;  
    public float WordSpeed = 20f;
    public float ShootInterval = 5f;  // 2초에 한 번 생성하도록 변경

    private float lastShootTime;

    void Update()
    {
        // 플레이어가 발사할 수 있는지를 체크하고 발사 로직 수행
        if (Time.time - lastShootTime >= ShootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

     void Shoot()
    {
        // 총알 생성
        GameObject word = Instantiate(Word, transform.position + new Vector3(0f, 0f, 100f), Quaternion.identity);

        // 랜덤한 위치로 이동
        float randomX = Random.Range(-30f, 30f);
        float randomY = Random.Range(-30f, 30f);
        Vector3 randomOffset = new Vector3(randomX, randomY, 0f);
        word.transform.position += randomOffset;

        // 플레이어 방향 구하기
        Vector3 playerDirection = transform.forward;

        // 총알 방향 설정
        word.transform.LookAt(transform.position + playerDirection);

        // 총알에 힘을 가해서 날아가게 함
        Rigidbody wordRb = word.GetComponent<Rigidbody>();
        if (wordRb != null)
        {
            wordRb.velocity = playerDirection * WordSpeed;
        }
    }

}
