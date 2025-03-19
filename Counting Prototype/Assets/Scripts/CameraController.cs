using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float sensitivity;  
    private GameObject player;
    void Start () {
    player = GameObject.Find("Player");	
    }
	void FixedUpdate ()
	{
		float rotateHorizontal = Input.GetAxis ("Mouse X");
		transform.RotateAround (player.transform.position, Vector3.up, rotateHorizontal * sensitivity);  
	
	}

    
}
