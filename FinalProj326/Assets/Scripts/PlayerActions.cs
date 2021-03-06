using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerActions : MonoBehaviour
{
    public TMP_Text prompt;
    public float maxUseDistance = 5f;
    public Transform Camera;
    public LayerMask UseLayers;
    public GameObject eventSystem;

    void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, maxUseDistance, UseLayers))
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                prompt.SetText("Press \"E\" to interact with " + door.itemName);
                prompt.gameObject.SetActive(true);
                //prompt.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.01f;
                //prompt.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized); }

            }
            else if (hit.collider.TryGetComponent<Button>(out Button button))
            {
                prompt.SetText("Press \"E\" to press " + button.itemName);
                prompt.gameObject.SetActive(true);
                //prompt.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.01f;
                //prompt.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
            }
            else
            {
                prompt.gameObject.SetActive(false);
            }
        }
        else
        {
            prompt.gameObject.SetActive(false);
        }
    }

    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, maxUseDistance, UseLayers))
        {
            if(hit.collider.TryGetComponent<Door>(out Door door))
            {
                if (door.isOpen)
                    door.Close();
                else
                    door.Open(transform.position);
            }
            else if (hit.collider.TryGetComponent<Button>(out Button button))
            {
                button.Fire();
            }
        }
    }

    public void OnPause()
    {
            eventSystem.GetComponent<PauseScript>().Pause();
    }

}
