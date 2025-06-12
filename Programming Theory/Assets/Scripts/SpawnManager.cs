using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject roadPrefab;
    private GameObject currentRoad;
    private GameObject previousRoad;
    private CarMovement car;
    private float offset = 8f;

    public bool isSpawned = false;
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<CarMovement>();

        currentRoad = GameObject.Find("Road");
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
            //Destroy(previousRoad);
            Debug.Log(car.carPos);
            Debug.Log(currentRoad.transform.position);
            Debug.Log(previousRoad.transform.position);
        }
    }

    void SpawnRoad()
    {
        previousRoad = currentRoad;
        currentRoad = Instantiate(roadPrefab, currentRoad.transform.position + new Vector3(0, 0, offset * 1), roadPrefab.transform.rotation);

    }

}
