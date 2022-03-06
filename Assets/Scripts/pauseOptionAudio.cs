using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class pauseOptionAudio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public static bool isMute = false;
    public float presentVolume;
    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", 0);
        volumeSlider.value = 0;
        presentVolume = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isMute == false)
            presentVolume = volumeSlider.value;

        if (volumeSlider.value != -80)
            isMute = false;
    }
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void muteVolume(float volume)
    {
        if (isMute == false)
        {
            isMute = true;
            audioMixer.SetFloat("volume", -80);
            volumeSlider.value = -80;
        }
        else
        {
            isMute = false;
            volume = presentVolume;
            audioMixer.SetFloat("volume", volume);
            volumeSlider.value = volume;
        }
    }

    public void setMaxVolume(float volume)
    {
        volumeSlider.maxValue = volume;
        volumeSlider.value = volume;
    }

    public void setPresentVolume(float volume)
    {
        volumeSlider.value = volume;
    }
}
