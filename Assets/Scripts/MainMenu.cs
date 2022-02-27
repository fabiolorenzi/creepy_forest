using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("level_one");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
