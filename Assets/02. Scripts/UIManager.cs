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
            scoreText.text = GameManager.instance.score + "개";
            healthText.text = GameManager.instance.health.ToString();
        }
    }
}
