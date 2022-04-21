using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public int sceneID;
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneID);
    }
}
