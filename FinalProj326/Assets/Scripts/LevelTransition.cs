using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public int sceneID;
    void OnCollisionStay(Collision collision)
    {
        SceneManager.LoadScene(sceneID);
    }
}
