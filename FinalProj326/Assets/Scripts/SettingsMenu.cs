using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour

{
    public AudioMixer MainAudioMix;
    public void SetVolume(float volume)
    {
        MainAudioMix.SetFloat("volume",volume);
        MainAudioMix.SetFloat("Volume", Mathf.Log10(volume) * 20);

    }

    public void ToggleFullscreen(bool fullscreen)
    {
        
        Screen.fullScreen = fullscreen;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}

//
//public void OnPause()
//{
    //if (!isPaused)
    //{
        //eventSystem.GetComponent<MenuController>().Pause();

    //}
    //else
    //{
        //eventSystem.GetComponent<MenuController>().UnPause();
    //}

//}