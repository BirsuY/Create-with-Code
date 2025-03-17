using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] boundaryPrefab;
    public GameObject planePrefab;
    public GameObject coinPrefab;
    public GameObject ghostPrefab;
    private GameObject player;

    private bool isNewPlane = false;
    private float planeBoundary = 30.0f;
    public float planeLength = 50.0f;
    private float offset = 40.0f;

    private float startDelay = 2.0f;
    private float obstacleSpawnTime = 3.0f;
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("SpawnObstacle", startDelay, obstacleSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > planeBoundary){
            SpawnPlane();
            planeBoundary += planeLength;
            isNewPlane = true;
        }
        
    }

    void SpawnPlane(){
        Instantiate(planePrefab, new Vector3(planeBoundary+offset, 0, 0), planePrefab.transform.rotation);
    }

    void SpawnObstacle(){
        int size = boundaryPrefab.Length;
        int index = Random.Range(0,size);
        float pos = Random.Range(planeBoundary, planeBoundary+offset);
        Instantiate(boundaryPrefab[index], new Vector3(pos, 0.22f, 0), planePrefab.transform.rotation);
        //isNewPlane = false;
    }

    void SpawnEnemy(){
        float pos = Random.Range(planeBoundary, planeBoundary+offset);
        Instantiate(ghostPrefab, new Vector3(pos, 0, 0), planePrefab.transform.rotation);
    }
    
}
