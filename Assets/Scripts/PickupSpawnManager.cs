using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnManager : MonoBehaviour
{

    public float startDelay = 2f;
    public float repeatRate = 2f;
    public float xPos = 32f;
    public float yPos = 0f;
    public float zPos = 2.0f;

    public GameObject[] pickupPrefab;
    private Vector3 spawnPos;

    void Start()
    {
        spawnPos = new Vector3(xPos, yPos, zPos);
        InvokeRepeating("spawnPickup", startDelay, repeatRate);
    }

    void spawnPickup()
    {
        if (GameManager.instance.gameOver == false)
        {
            GameObject newPickup = pickupPrefab[Random.Range(0, pickupPrefab.Length)];
            Instantiate(newPickup, spawnPos, newPickup.transform.rotation);
        }
    }
}

