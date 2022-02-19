using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static TextMeshProUGUI scoreText;


    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public static void UpdateScore(int score)
    {
        scoreText.text = "Points: " + score.ToString();
    }
}
