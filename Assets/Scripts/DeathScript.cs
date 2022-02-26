using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScript : MonoBehaviour
{
    private static TextMeshProUGUI deathText;

    private void Awake()
    {
        deathText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Player.life == 0)
        {
            deathText.text = "You are dead";
        }
    }
}
