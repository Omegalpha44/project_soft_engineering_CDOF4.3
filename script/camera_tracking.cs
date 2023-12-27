using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_tracking : MonoBehaviour // unused, but may be useful later
{
    public Transform target;
    public float smoothSpeed = 0.125f; 

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, target.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}