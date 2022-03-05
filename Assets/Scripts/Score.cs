using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static TextMeshProUGUI scoreText;


    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public static void UpdateScore(int score)
    {
        scoreText.text = "Points: " + score.ToString() + "/" + GiveVictory.levelsPoints;
    }
}
