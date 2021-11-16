using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject obstaclePrefab;
    public float startDelay = 2;
    public float repeatRate = 2.0f;
    private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    public GameObject[] obstaclePrefabs;
    public int randomX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //PlayerController

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        
        if (!playerControllerScript.gameOver)
        {
            int randomX = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomX], spawnPos, obstaclePrefabs[randomX].transform.rotation);
        }
        
    }
}
