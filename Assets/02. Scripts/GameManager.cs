using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // 게임 내에서 씬 이동 시 유지하고 싶은 골드 값
    public int score = 0;
    public int health = 3;

    private int highScore = 0; // 최고 기록을 저장할 변수

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    // 최고 기록을 갱신하는 메서드
    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    // 최고 기록을 가져오는 메서드
    public int GetHighScore()
    {
        return highScore;
    }
}


// // GameManager 스크립트

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager instance = null;
    
//     // 게임 내에서 씬이동시 유지하고 픈 골드 값
//     public int score = 0;
//     public int health = 3;



//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             if (instance != this)
//                 Destroy(this.gameObject);
//         }
//     }
// }


