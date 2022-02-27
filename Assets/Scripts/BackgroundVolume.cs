using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundVolume : MonoBehaviour
{
    public AudioSource background;
    public float volumeVal;

    private void Awake()
    {
        background = GetComponent<AudioSource>();
        volumeVal = 0.024f;
    }

    private void Start()
    {
        background.volume = volumeVal;
    }

    private void Update()
    {
        background.volume = volumeVal;
    }
}
