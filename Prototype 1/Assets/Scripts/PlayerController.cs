using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    private int speed = 10;
    private float turnSpeed = 25;
    private float horizontalInput;

    //private float verticalInout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInout = Input.GetAxis("Vertical");

        // transform.Translate(0, 0, 1);
        // Move vehicle forward based
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        // Rotate vehicle based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
