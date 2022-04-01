using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawnManager : MonoBehaviour
{

    public float startDelay = 2f;
    public float repeatRate = 2f;
    public float xPos = 32f;
    public float yPos = 0f;
    public float zPos = -2.5f;

    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(xPos, yPos, zPos);
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {
        if (GameManager.instance.gameOver == false)
        {
            GameObject newObstacle = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];
            Instantiate(newObstacle, spawnPos, newObstacle.transform.rotation);
        }
    }
}
