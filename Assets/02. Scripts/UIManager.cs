using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    
    void Update()
    {
        scoreText.text = GameManager.instance.score + "개";
    }
}
