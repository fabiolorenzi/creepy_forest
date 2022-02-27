using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButtons : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void ResetValues()
    {
        OptionBackgroudVolume.Reset();
    }
}
