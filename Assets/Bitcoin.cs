using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitcoin : MonoBehaviour
{
    [SerializeField] private float amount = 1.0f; // This is for the coin collection value
    [SerializeField] private float movementAmount = 0.25f; // This is for the height it floats
    [SerializeField] private float speed = 4.0f;
    private Vector3 pointA;
    private Vector3 pointB;

    private void Start()
    {
        pointA = transform.position;
        pointB = transform.position + new Vector3(0, movementAmount, 0);
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.Character)
        {
            Destroy(gameObject);
            Player.Instance.CollectBitcoin(amount); // Collecting the coin value
        }
    }
}
