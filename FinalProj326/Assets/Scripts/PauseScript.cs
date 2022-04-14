using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseUI; //index 0: pause button, index 1: panel
    public GameObject player;
    private bool isPaused = false;
    private PlayerInput input;
    private StarterAssetsInputs mouseControl;

    void Start()
    {
        input = player.GetComponent<PlayerInput>();
        mouseControl = player.GetComponent<StarterAssetsInputs>();
    }
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
    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
