using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance { get; private set; }

    public Transform target;
    public float smoothSpeed = 0.125f;
    public float horizontalOffset;
    public float verticalOffset;
    public Vector3 rotationOffset;

    private void Awake()
    {
        Instance = this;
    }

    public void Follow(Transform target)
    {
        this.target = target;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + Vector3.up * verticalOffset;
        Vector3 delta = transform.position - desiredPosition;
        delta.y = 0;
        desiredPosition += delta.normalized * horizontalOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position, Vector3.up) * Quaternion.Euler(rotationOffset), smoothSpeed);
    }
}
