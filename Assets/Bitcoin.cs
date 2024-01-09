using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitcoin : MonoBehaviour
{
    [SerializeField] float amount;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.Character)
        {
            Destroy(other.gameObject);
            Player.Instance.CollectBitcoin(amount);
        }
    }
}
