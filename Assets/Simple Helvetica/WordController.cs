using System;
using System.Collections;
using System.Collections.Generic;
// WordController.cs
using UnityEngine;

public class WordController : MonoBehaviour
{
    public float movementSpeed = 30f; // Word가 플레이어 방향으로 이동할 속도
    public AudioClip explosionSound; // Inspector에서 연결할 폭발 사운드 클립

    private GameObject player;

    public GameObject destoryParticle;
    
    void Start()
    {
        // Rigidbody 컴포넌트 추가
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false; // 중력 비활성화
        rb.velocity = transform.forward * movementSpeed; // Word 초기 이동 방향 설정

        player = GameObject.Find("Player");
        transform.LookAt(player.transform.position);
        transform.Rotate(0, 180, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Check");

        if (other.CompareTag("Player"))
        {
            Debug.Log("확인 = "+transform.name);
            GameManager.instance.health--;
            AudioManager.Instance.PlayExplosionSound(explosionSound);
            // 플레이어와 충돌하면 오브젝트를 제거 또는 비활성화
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(destoryParticle, transform.position, transform.rotation);
    }
}