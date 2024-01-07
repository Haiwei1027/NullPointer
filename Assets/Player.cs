using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }

    private int bitcoins;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        // Make this persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void CollectBitcoin(int amount)
    {
        if (amount < 0) { return; }
        bitcoins += amount;
    }

    public void TransferBitcoin(int amount)
    {
        if (amount < 0) { return; }
        if (bitcoins - amount < 0) { return; }
        bitcoins -= amount;
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
