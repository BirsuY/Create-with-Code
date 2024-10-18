using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawn = true;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            StartCoroutine(spawnDog());
        }

    }

    IEnumerator spawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        canSpawn = false;
        yield return new WaitForSecondsRealtime(2f);
     
        canSpawn = true;
    }

        

}
