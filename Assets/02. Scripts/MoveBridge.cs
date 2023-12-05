using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    private bool isMoving = false; // 처음에 이동하지 않도록 false로 설정
    

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 2 * 15f);
        }
    }

    // 이동을 중지하는 메서드
    public void StopMovement()
    {
        isMoving = false;
    }

    // 이동을 시작하는 메서드
    public void StartMovement()
    {
        isMoving = true;
    }
}