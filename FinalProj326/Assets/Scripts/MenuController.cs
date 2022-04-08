using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI[] countText;
    public GameObject pauseUI;//index 0: pause button, index 1: panel
    public GameObject player;
    private bool isPaused = false;
    private PlayerInput input;
    private StarterAssetsInputs mouseControl;


    // Start is called before the first frame update
    void Start()
    {
        input = player.GetComponent<PlayerInput>();
        mouseControl = player.GetComponent<StarterAssetsInputs>();
    }
   


    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            mouseControl.SetCursorState(false);
        }
        else
        {
            mouseControl.SetCursorState(true);
        }
    }

    //Pause Menu
    public void Pause()
    {
        isPaused = true;
        input.enabled = false;
        Time.timeScale = 0;
        pauseUI.SetActive(true);

    }
    public void UnPause()
    {
        isPaused = false;
        input.enabled = true;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    //Transition for all menus
    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }    

    public void LoseGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "GAME OVER";
    }

    public void WinGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win";
    }
    public void AddCountText(int playerIndex, int count)
    {
        countText[playerIndex].text = "Count: " + count.ToString();
    }


    //Options Menu
    public AudioMixer MainAudioMix;
    public void SetVolume(float volume)
    {
        MainAudioMix.SetFloat("volume", volume);
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
