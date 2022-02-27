using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundVolume : MonoBehaviour
{
    public AudioSource background;

    private void Awake()
    {
        background = GetComponent<AudioSource>();
    }

    private void Start()
    {
        background.volume = OptionBackgroudVolume.backgroundVolume;
    }

    private void Update()
    {
        background.volume = OptionBackgroudVolume.backgroundVolume;
    }
}
