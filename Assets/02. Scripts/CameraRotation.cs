using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform centerPoint;
    public Vector3 targetPosition = new Vector3(-0.3f, 16.24f, -25.45f);
    public Vector3 targetRotation = new Vector3(-12.54f, -0.8f, 2.147f);
    public float rotationSpeed = 30f; // 180도를 1초 동안 회전
    public float moveSpeed = 30f;

    private bool isMoving = true;
    private bool isRotating = false;

    void Update()
    {
        if (isMoving)
        {
            // 센터 포인트를 기준으로 y축으로 회전
            transform.RotateAround(centerPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
            transform.LookAt(centerPoint);

            // 목표 지점으로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 목표 지점에 도착하면 이동 정지 및 회전 시작
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
                isRotating = true;
            }
        }
        else if (isRotating)
        {
            // 회전 각속도를 계산
            float angularSpeed = 180f / Mathf.PI; // 180도를 1초 동안 회전하는 각속도 (라디안 변환)
            
            // 목표 회전에 도달하면 회전 정지 및 고정
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), angularSpeed * Time.deltaTime);

            // 회전이 거의 완료되면 정지
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(targetRotation)) < 1f)
            {
                isRotating = false;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
        }
    }
}



//    public Vector3 targetPosition = new Vector3(-0.3f, 16.24f, -25.45f);
//     public Vector3 targetRotation = new Vector3(-12.54f, -0.8f, 2.147f);
//     public float movementSpeed = 2f; // 이동 속도
//     public float rotationSpeed = 2f; // 회전 속도

//     void Update()
//     {
//         // 위치 천천히 이동
//         transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);

//         // 회전 천천히 이동
//         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), rotationSpeed * Time.deltaTime);
//     }
// }DontDestroyOnLoad