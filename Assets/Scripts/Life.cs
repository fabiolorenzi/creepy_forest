using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life : MonoBehaviour
{
    public static TextMeshProUGUI lifeText;

    void Awake()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
    }

    public static void UpdateLife(int points)
    {
        lifeText.text = "Life: " + points.ToString();
    }
}
