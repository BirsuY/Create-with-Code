using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject roadPrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject[] obstaclePrefabs;
    private GameObject currentRoad;
    private GameObject previousRoad;
    private CarMovement car;
    private float offset = 10f;
    private float startDelay = 0f;
    private float spawnObjectInterval = 5f;
    private float spawnCoinInterval = 5f;
    public bool isSpawned = false;
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<CarMovement>();

        currentRoad = GameObject.Find("Road");
        InvokeRepeating("SpawnObstacle", startDelay, spawnObjectInterval);
        InvokeRepeating("SpawnCoin", startDelay, spawnCoinInterval);


    }
    void FixedUpdate()
    {

        if (car.carPos.z >= currentRoad.transform.position.z + offset)
        {
            isSpawned = true;
        }

        if (isSpawned)
        {
            SpawnRoad();
            isSpawned = false;
        }

        if (previousRoad != null && previousRoad.transform.position.z < car.carPos.z + offset * 2)
        {
            Destroy(previousRoad);

        }
    }

    void SpawnRoad()
    {
        if (Time.timeScale == 0) return;
        previousRoad = currentRoad;
        currentRoad = Instantiate(roadPrefab, currentRoad.transform.position + new Vector3(0, 0, offset * 1), roadPrefab.transform.rotation);

    }

    void SpawnObstacle()
    {
        if (Time.timeScale == 0) return;
        for (int i = 0; i < 5; i++)
        {
            var randomObs = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            float randomX = Random.Range(-2f, 2f);
            float randomZ = Random.Range(25f, 55f);
            var currObstacle = Instantiate(randomObs, car.transform.position + new Vector3(randomX, -0.5f, randomZ), randomObs.transform.rotation);
        }

    }

    void SpawnCoin()
    {
        if (Time.timeScale == 0) return;
        for (int i = 0; i < 10; i++)
        {
            float randomX = Random.Range(-3f, 3f);
            float randomZ = Random.Range(25f, 55f);
            var currObstacle = Instantiate(coinPrefab, car.transform.position + new Vector3(randomX, 0.5f, randomZ), coinPrefab.transform.rotation);
        }
    }


}
