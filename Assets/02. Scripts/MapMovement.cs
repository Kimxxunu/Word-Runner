// MapMovement.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    private MapCreator _mapCreator;
    private bool isMoving = true; // 처음에 이동하지 않도록 false로 설정

    // Start is called before the first frame update
    void Start()
    {
        _mapCreator = GameObject.Find("MapCreator").GetComponent<MapCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _mapCreator.speed * 15f);
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


// // MapMovement.cs

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MapMovement : MonoBehaviour
// {
//     private MapCreator _mapCreator;
//     private bool isMoving = true; // 이동 여부를 나타내는 변수 추가

//     // Start is called before the first frame update
//     void Start()
//     {
//         _mapCreator = GameObject.Find("MapCreator").GetComponent<MapCreator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (isMoving)
//         {
//             transform.Translate(Vector3.back * Time.deltaTime * _mapCreator.speed * 15f);
//         }
//     }

//     // 이동을 중지하는 메서드
//     public void StopMovement()
//     {
//         isMoving = false;
//     }
// }

