// MapMovement.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    private MapCreator _mapCreator;
    private bool isMoving = true; // 이동 여부를 나타내는 변수 추가

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
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MapMovement : MonoBehaviour
// {
//     private MapCreator _mapCreator;
//     // Start is called before the first frame update
//     void Start()
//     {
//         _mapCreator = GameObject.Find("MapCreator").GetComponent<MapCreator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         transform.Translate(Vector3.back*Time.deltaTime*_mapCreator.speed*15f);
//     }
// }
