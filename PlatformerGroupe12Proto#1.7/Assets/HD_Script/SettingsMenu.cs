using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider musicSlider;

    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);


    }

    void Start()
    {
        //Volume Slider.value=
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        PlayerPrefs.GetFloat("volume", 1f);



    }
}
