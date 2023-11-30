using System.Collections;
using System.Collections.Generic;
// WordController.cs

using UnityEngine;

public class WordController : MonoBehaviour
{
    public float movementSpeed = 30f;  // Word가 플레이어 방향으로 이동할 속도

    void Start()
    {
        // Rigidbody 컴포넌트 추가
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;  // 중력 비활성화
        rb.velocity = transform.forward * movementSpeed;  // Word 초기 이동 방향 설정
    }

    void OnTriggerEnter(Collider other){
    Debug.Log("WORD랑 부딛혔다!!");

    if (other.CompareTag("Player"))
    {
        // 플레이어와 충돌하면 오브젝트를 제거 또는 비활성화
        Destroy(gameObject);
    }
}
}