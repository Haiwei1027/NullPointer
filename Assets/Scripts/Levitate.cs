using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    [Tooltip("Floaty Heighty")]
    [SerializeField] private float movementAmount = 0.25f; // This is for the height it floats
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private Vector3 direction = Vector3.up;
    private Vector3 pointA;
    private Vector3 pointB;

    private void Start()
    {
        pointA = transform.position;
        pointB = transform.position + direction * movementAmount;
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            yield return StartCoroutine(Move(transform, pointA, pointB, speed));
            yield return StartCoroutine(Move(transform, pointB, pointA, speed));
        }
    }

    private IEnumerator Move(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
