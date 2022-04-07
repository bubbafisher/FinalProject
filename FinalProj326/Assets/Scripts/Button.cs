using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    public GameObject target;
    
    public void Fire()
    {
        if (target.TryGetComponent<Door>(out Door door))
        {
            if (door.isOpen)
                door.Close();
            else
                door.Open(transform.position);
        }
    }
}
