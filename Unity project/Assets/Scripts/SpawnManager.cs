using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    private float XRange = -393;

    private float yRange = 1295;

    public int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

     void Update()
    {
        SpawnRandomBall();
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {

        spawnInterval = Random.Range(2, 4);

        // Generate random ball index and random spawn position
        int index = spawnCount;
        // Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);



        // instantiate ball at random spawn location
        if (Input.GetKeyDown(KeyCode.S))
            index = spawnCount - 1;
        Instantiate(enemyPrefab[index],new Vector3(XRange,yRange,1324),
            enemyPrefab[index].transform.rotation);
        Invoke("SpawnRandomBall", startDelay);

    }

}
