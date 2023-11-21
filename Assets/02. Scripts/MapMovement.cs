using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    private MapCreator _mapCreator;
    // Start is called before the first frame update
    void Start()
    {
        _mapCreator = GameObject.Find("MapCreator").GetComponent<MapCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back*Time.deltaTime*_mapCreator.speed);
    }
}
