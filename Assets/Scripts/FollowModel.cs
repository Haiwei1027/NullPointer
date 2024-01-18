using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FollowModel : ScriptableObject
{
    public float height;
    public Vector3 lookOffset;
    public Vector3 upAxis;
    public float linearSpeed;
    public float angularSpeed;
    public float velocityFactor;
    public float minDistance;
}