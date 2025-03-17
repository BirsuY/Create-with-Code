using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 3.0f;
    private Rigidbody rb;
    private GameObject player;

    private bool isNextTo = false;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveGhost();
    }

    
    void OnCollisionEnter(Collision other){
        //if there is an obstacle jump on it
        if(other.gameObject.CompareTag("Boundary")){
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            // Destroy(other.gameObject);
            Debug.Log("Collided");
        }

        if(other.gameObject.CompareTag("Player")){
            isNextTo = true;
        }
        
    }

    void MoveGhost(){
        if(!isNextTo){
            Vector3 lookDir = (player.transform.position-transform.position).normalized;
            rb.AddForce(lookDir * speed);
        }
    }
}
