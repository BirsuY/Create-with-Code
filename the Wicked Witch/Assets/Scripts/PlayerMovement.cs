using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private float speed = 20.0f;
    private float jumpSpeed = 4.0f;
    public float startBoundary = -1.0f;
    private bool isGrounded = true;
    private Rigidbody rb;
    public SpawnManager sm;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        SetBoundary();
        if(transform.position.y <= 1.0f){
            isGrounded = true;
        }
        float boundary = startBoundary + sm.planeLength;
        if(transform.position.x > boundary){
            startBoundary += sm.planeLength;
        }
        
    }

    void MovePlayer(){
        // if(Input.GetKeyDown(KeyCode.D)){
        //     //transform.Translate(Vector3.right * Time.deltaTime * speed);
        //     rb.AddForce(Vector3.right * speed, ForceMode.Impulse);

        // }
        // else if(Input.GetKeyDown(KeyCode.A)){
        //     //transform.Translate(Vector3.right * Time.deltaTime * -speed);
        //     rb.AddForce(Vector3.right * -speed, ForceMode.Impulse);
        // }
        // else{
        //     rb.AddForce(Vector3.right* 0);
        // }

        if(Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        else if(Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
        else {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z); // Stop moving when no key is pressed
        }

        // float move_input = Input.GetAxis("Horizontal");
        // rb.AddForce(Vector3.right * move_input * speed);

        if(Input.GetKey(KeyCode.Space) && isGrounded){
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            isGrounded = false;
        }
        else if(!isGrounded ){
            rb.velocity = new Vector3(rb.velocity.x, -jumpSpeed, rb.velocity.z); // Stop moving when no key is pressed
        }
    }

    void SetBoundary(){
        if(transform.position.x < startBoundary){
            transform.position = new Vector3(startBoundary, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Coin")){
            Destroy(other.gameObject);
        }
    }
}
