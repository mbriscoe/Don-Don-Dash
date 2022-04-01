using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float startDelay = 2f;
    public float repeatRate = 2f;
    public float xPos = 32f;
    public float yPos = 0f;
    public float zPos = 2f;

    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    private void Start()
    {
        spawnPos = new Vector3(xPos, yPos, zPos);
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if (GameManager.instance.gameOver != false) return;
        
        GameObject newObstacle = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];
        Instantiate(newObstacle, spawnPos, newObstacle.transform.rotation);
    }
}
