using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }

    public GameObject Character { get; private set; }

    [SerializeField] GameObject characterPrefab;

    private float bitcoins;

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

    public void CollectBitcoin(float amount)
    {
        if (amount < 0) { return; }
        bitcoins += amount;
        Debug.Log($"amount now is {bitcoins}");
    }

    public void TransferBitcoin(float amount)
    {
        if (amount < 0) { return; }
        if (bitcoins - amount < 0) { return; }
        bitcoins -= amount;
        
    }

    public void Spawn()
    {
        if (Character != null) { return; }
        Vector3 spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        Character = Instantiate(characterPrefab,spawnPoint,Quaternion.identity);
        CameraFollow.Instance.SetTarget(Character.transform);
    }

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        
    }
}
