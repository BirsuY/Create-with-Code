using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private float speed = 20.0f;
    private float startBoundary = -1.0f;

    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        SetBoundary();
        
    }

    void MovePlayer(){
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.right * Time.deltaTime * -speed);

        }
    }

    void SetBoundary(){
        if(transform.position.x < startBoundary){
            transform.position = new Vector3(startBoundary, transform.position.y, transform.position.z);
        }
    }
}
