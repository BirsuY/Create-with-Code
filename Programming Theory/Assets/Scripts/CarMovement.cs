using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    protected float speed = 10.0f;
    [SerializeField] float speed__;
    private Rigidbody rb;
    public Vector3 carPos;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        carPos = transform.position;
        Move();
    }
    void Move(){
        if(Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        else if(Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
        else{
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if(Input.GetKey(KeyCode.W)){
            MoveForward(speed * 3);
        }
        else{
            MoveForward(speed);
        }
    }

    void MoveForward(float speed){
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        speed__ = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f);
    }
}
