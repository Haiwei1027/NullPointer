using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitcoin : MonoBehaviour
{
    [SerializeField] private float amount = 1.0f; // This is for the coin collection value

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.Character)
        {
            Destroy(gameObject);
            Player.Instance.CollectBitcoin(amount); // Collecting the coin value
        }
    }
}
