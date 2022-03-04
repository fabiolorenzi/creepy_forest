using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryButtons : MonoBehaviour
{
    private int sceneIndex;

    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void NextLevel()
    {
        if (sceneIndex != 2)
        {
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("main_menu");
        }
    }
}
