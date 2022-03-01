using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeathButtons : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject homeButton;

    /*public void Awake()
    {
        restartButton = GameObject.Find("RestartButton");
        homeButton = GameObject.Find("HomeButton");
    }*/

    public void Update()
    {
        if (Player.life == 0)
        {
            restartButton.SetActive(true);
            homeButton.SetActive(true);
        }
    }
}
