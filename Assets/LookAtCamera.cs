using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(LookAtConstraint))]
public class LookAtCamera : MonoBehaviour
{
    private void Start()
    {
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = CameraFollow.Instance.transform;
        source.weight = 1.0f;
        GetComponent<LookAtConstraint>().AddSource(source);
    }
}
