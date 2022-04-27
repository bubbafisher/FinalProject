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
    void OnTriggerEnter(Collider other)
    {
        if (!finalLevel)
        {
            PlayerPrefs.SetString("SavedLevel", "level" + sceneID);
            SceneManager.LoadScene(sceneID);
        }
        else 
        {
            other.gameObject.GetComponent<PlayerInput>().enabled = false;
            other.gameObject.GetComponent<StarterAssetsInputs>().SetCursorState(false);
            SceneManager.LoadScene("EndGame");
        }
        
    }
}
