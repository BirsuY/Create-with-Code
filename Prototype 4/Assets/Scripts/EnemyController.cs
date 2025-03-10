using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 3.0f;
    private Rigidbody rb;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (player.transform.position-transform.position).normalized;
        rb.AddForce(lookDir * speed);

        if(transform.position.y < -10.0f){
            Destroy(gameObject);
        }
    }
    
}
