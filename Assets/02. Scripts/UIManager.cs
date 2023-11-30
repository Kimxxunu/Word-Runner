using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    
    void Update()
    {
        scoreText.text = GameManager.instance.score + "개";
        healthText.text = GameManager.instance.health.ToString();
    }
}
