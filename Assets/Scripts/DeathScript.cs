using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScript : MonoBehaviour
{
    private static TextMeshProUGUI deathText;
    public static bool deathByTime;

    private void Awake()
    {
        deathText = GetComponent<TextMeshProUGUI>();
        deathByTime = false;
    }

    void Update()
    {
        if (Player.life == 0 && !deathByTime)
        {
            deathText.text = "Game Over";
        }
        else if (deathByTime)
        {
            deathText.text = "Time Over";
        }
    }
}
