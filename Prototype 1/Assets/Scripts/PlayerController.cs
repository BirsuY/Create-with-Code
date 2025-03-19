using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    private int wheelsOnGround;
    private float speed;    
    private float rpm;
    private float turnSpeed = 25;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float horsePower = 0;
    private Rigidbody playerRb; 
    [SerializeField] GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> wheels;
    public bool aa;

    //private float verticalInout;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    async Task FixedUpdate()
    {
        //Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // transform.Translate(0, 0, 1);
        // Move vehicle forward based
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
        // Rotate vehicle based on horizontal input
        aa = IsOnGround();
        if(IsOnGround()){
            
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedText.text = "Speed: " + speed + "Km/h";

            rpm = Mathf.RoundToInt((speed % 30)*40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround(){
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in wheels){
            if(wheel.isGrounded){
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4){
            return true;
        }
        return false;
    }
}
