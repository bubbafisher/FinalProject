using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using StarterAssets;

public class LevelTransition : MonoBehaviour
{
    public int sceneID;
    public bool finalLevel = false;
    public GameObject pauseMenuScript;
    void OnTriggerEnter(Collider other)
    {
        if (!finalLevel)
        {
            PlayerPrefs.SetString("SavedLevel", "level" + sceneID);
            SceneManager.LoadScene(sceneID);
        }
        else 
        {
            pauseMenuScript.GetComponent<PauseScript>().Pause();
            Time.timeScale = 1;
            SceneManager.LoadScene("EndGame");
        }
        
    }
}
