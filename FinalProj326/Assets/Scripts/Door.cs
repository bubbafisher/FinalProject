using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit for most of this code goes to LiamAcademy: https://www.youtube.com/watch?v=cPltQK5LlGE

public class Door : Interactable
{
    public bool isOpen = false;
    public float speed = 1f;

    private float rotationAmount = 90f, forwardDirection = 0;
    private Vector3 StartRotation, Forward;
    private Coroutine AnimationCoroutine;
    // Start is called before the first frame update
    void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        Forward = transform.right;
    }

    // Update is called once per frame
    public void Open(Vector3 userPosition)
    {
        if(!isOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            float dot = Vector3.Dot(Forward, (userPosition - transform.position).normalized);
            AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
        }
    }

    private IEnumerator DoRotationOpen(float forwardAmount)
    {
        float time;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if (forwardAmount >= forwardDirection)
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y - rotationAmount, 0));
        else
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y + rotationAmount, 0));

        isOpen = true;

        time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    public void Close()
    {
        if (!isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            AnimationCoroutine = StartCoroutine(DoRotationClose());
        }
    }

    private IEnumerator DoRotationClose()
    {
        float time;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(StartRotation);

        isOpen = false;

        time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    public override void OnInteract()
    {
        Transform Camera = getCamera();
        LayerMask UseLayers = getUseLayers();
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, maxUseDistance, UseLayers))
        {
            if (isOpen)
                Close();
            else
                Open(transform.position);
        }
    }
}
