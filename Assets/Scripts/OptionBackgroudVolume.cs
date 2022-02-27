using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class OptionBackgroudVolume : MonoBehaviour
{
    [Range(0f, 1f)]
    public static float backgroundVolume = 0.024f;

    private static Scrollbar scrollbar;

    public void Awake()
    {
        //backgroundVolume = 0.024f;
        scrollbar = GetComponent<Scrollbar>();
    }

    public void Start()
    {
        scrollbar.value = backgroundVolume;
    }

    public void HandleChange()
    {
        backgroundVolume = scrollbar.value;
    }

    public static void Reset()
    {
        backgroundVolume = 0.024f;
        scrollbar.value = 0.024f;
    }
}
