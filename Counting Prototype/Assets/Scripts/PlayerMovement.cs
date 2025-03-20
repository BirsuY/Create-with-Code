using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10f;

    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput != 0){
            playerRb.velocity = camera.transform.TransformDirection(Vector3.right*horizontalInput*speed);
        }
        if(verticalInput != 0){
            playerRb.velocity = camera.transform.TransformDirection(Vector3.forward*verticalInput*speed);
        }

    }
}
