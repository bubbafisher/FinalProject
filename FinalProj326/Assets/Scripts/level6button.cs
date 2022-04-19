using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level6button : Button
{

    public GameObject otherButton1;
    public GameObject otherButton2;

    public void Fire()
    {
        if (target.TryGetComponent<Door>(out Door door))
        {
            if (door.isOpen)
                door.Close();
            else
                door.Open(transform.position);

            otherButton1.SetActive(false);
            otherButton2.SetActive(true);
        }
    }
}