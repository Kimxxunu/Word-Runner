using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;

    void Update()
    {
        if (Time.timeScale > 0.1f) // 시간이 정상적으로 흐를 때만 업데이트
        {
            // GameManager.instance.score를 0 이상으로 보장
            int clampedScore = Mathf.Max(0, GameManager.instance.score);
            scoreText.text = clampedScore + "개";
            
            healthText.text = GameManager.instance.health.ToString();
        }
    }
}
