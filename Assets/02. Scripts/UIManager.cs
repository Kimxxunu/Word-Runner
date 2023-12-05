using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text highScoreText; // 최고 기록을 표시할 UI Text
    public TMP_Text CurrentScoreText;

    void Update()
    {
        if (Time.timeScale > 0.1f) // 시간이 정상적으로 흐를 때만 업데이트
        {
            // GameManager.instance.score를 0 이상으로 보장
            int clampedScore = Mathf.Max(0, GameManager.instance.score);
            scoreText.text = clampedScore + " 개";

            healthText.text = GameManager.instance.health.ToString();

            CurrentScoreText.text = scoreText.text;

            // 최고 기록 업데이트
            GameManager.instance.UpdateHighScore();
            // 최고 기록 UI 업데이트
            highScoreText.text = GameManager.instance.GetHighScore() + " 개";
        }
    }
}



// using UnityEngine;
// using TMPro;

// public class UIManager : MonoBehaviour
// {
//     public TMP_Text scoreText;
//     public TMP_Text healthText;

//     void Update()
//     {
//         if (Time.timeScale > 0.1f) // 시간이 정상적으로 흐를 때만 업데이트
//         {
//             // GameManager.instance.score를 0 이상으로 보장
//             int clampedScore = Mathf.Max(0, GameManager.instance.score);
//             scoreText.text = clampedScore + "개";
            
//             healthText.text = GameManager.instance.health.ToString();
//         }
//     }
// }
