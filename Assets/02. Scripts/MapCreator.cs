// MapCreator.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    private float timer = 0;
    public float speed = 2f;
    private bool isCreating = false; // 처음에 생성하지 않도록 false로 설정
    private float mapSpawnTime;
    public Vector3 mapSpawnPosition = new Vector3(0, 0, 80);
    public GameObject Map_Prefab;
    // Start is called before the first frame update
    void Start()
    {
        // Map 생성 코드 등 필요한 초기화 작업 수행
    }
    // Update is called once per frame
    void Update()
    {
        if (isCreating)
        {
            timer += Time.deltaTime;
            SpeedCal();
            if (timer > mapSpawnTime)
            {
                GameObject map = Instantiate(Map_Prefab, mapSpawnPosition, Quaternion.identity);
                Destroy(map, 10f);
                timer = 0;
                
            }
        }
    }
    private void SpeedCal()
    {
        mapSpawnTime = 6 / speed;
    }
    // 맵생성 멈춤
    public void StopMapCreation()
    {
        isCreating = false;
    }
    // 맵생성 시작
    public void StartCreation()
    {
        isCreating = true;
    }
}

