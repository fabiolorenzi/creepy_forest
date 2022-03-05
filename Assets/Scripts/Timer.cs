using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float timeRemaining;
    public static TextMeshProUGUI timer;

    public void Awake()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        timeRemaining = 10f;
    }

    public void Update()
    {
        if (timeRemaining > 0f && Player.life > 0 && !GiveVictory.isPlayed)
        {
            timeRemaining -= Time.deltaTime;
            timer.text = timeRemaining.ToString("##.##");
        }
        else if (Player.isPlayerDeath)
        {
            timeRemaining = 0f;
            timer.text = "0.00";
            Player.isTimeOver = false;
        }
        else if (GiveVictory.isPlayed)
        {
            timer.text = timeRemaining.ToString("##.##");
        }
        else
        {
            timeRemaining = 0f;
            timer.text = "0.00";
            Player.isTimeOver = true;
            DeathScript.deathByTime = true;
        }
    }
}
