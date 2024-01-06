using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float horizontalOffset;
    public float verticalOffset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + Vector3.up * verticalOffset;
        float distance = Vector3.Distance(transform.position, desiredPosition);
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 
            Mathf.Lerp(0,smoothSpeed,Mathf.Clamp01(distance - horizontalOffset)));
        
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(desiredPosition - transform.position, Vector3.up), smoothSpeed);
    }
}
