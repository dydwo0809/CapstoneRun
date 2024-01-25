using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if(!GameManager.Instance.isGameover)
        {
            GameManager.Instance.score += Time.deltaTime;
            scoreText.text = "SCORE\n" + (int)GameManager.Instance.score;
        }
    }
}
