using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float UpBound = 30f;
    private float lowBound = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If an object goes pass the player, remove them
        if(transform.position.z > UpBound)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.z < lowBound)
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject);
        }
    }
}
