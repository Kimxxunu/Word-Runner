using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    public GameObject target;

    private float speed = 35f;

    private float fireTimer = 0.60f;

    private float timer = 0f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (target != null) // target이 null이 아닌지 확인
        {
            if (timer >= fireTimer)
            {
                Vector3 direction = target.transform.position - transform.position;
                direction.Normalize();
                // 오브젝트를 타겟 방향으로 이동
                transform.position += direction * speed * Time.deltaTime;
                transform.parent = null;
            }
            else
            {
                timer += Time.deltaTime;
            }

            if (Vector3.Distance(transform.position, target.transform.position) < 3f)
            {
                Destroy(target);
                Destroy(gameObject);
                Debug.Log("삭제");
            }
        }
        else
        {
            // target이 null인 경우 처리
            // 예를 들어, 현재 gameObject를 파괴할 수 있습니다
            Destroy(gameObject);
        }
    }
}
