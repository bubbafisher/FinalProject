using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Interactable : MonoBehaviour
{
    public TextMeshPro prompt;
    public string itemName;
    public float maxUseDistance = 5f;
    public Transform Camera;
    public LayerMask UseLayers;

    void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, maxUseDistance, UseLayers))
        {
            prompt.SetText("Press \"E\" to interact with " + itemName);
            prompt.gameObject.SetActive(true);
            prompt.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.01f;
            prompt.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
        }
        else
        {
            prompt.gameObject.SetActive(false);
        }    
    }

    public abstract void OnInteract();
}
