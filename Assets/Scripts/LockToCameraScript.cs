using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToCameraScript : MonoBehaviour
{

    public Transform camTransform;
    public Vector3 camPos;
    private float distanceFromCamera = 15;

    void LateUpdate()
    {
        //make object face the camera
        transform.rotation = Camera.main.transform.rotation;

        camPos = Camera.main.transform.position;
        camTransform = Camera.main.transform;

        Vector3 resultingPosition = camPos + camTransform.forward * distanceFromCamera;
        transform.position = resultingPosition;
    }
}

