using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
        // Debug.Log(volume);
    }

    public void MuteMusic(bool volume)
    {
        if (volume == true)
        {
            audioMixer.SetFloat("musicVolume",0);
        }
        else
        {
            audioMixer.SetFloat("musicVolume", -80);
        }
        
    }

    public void MuteEffects(bool volume)
    {
        if (volume == true)
        {
            audioMixer.SetFloat("effectsVolume", 0);
        }
        else
        {
            audioMixer.SetFloat("effectsVolume", -80);
        }
        
    }
    
}
