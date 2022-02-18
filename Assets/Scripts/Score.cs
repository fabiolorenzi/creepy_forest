using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void UpdateScore(int score)
    {
        text.text = "Points: " + score;
    }
}
