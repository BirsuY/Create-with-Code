using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 6, -10);
    void Start()
    {
        
    }

    void LateUpdate()
    {
        //Offset the camera behind the vehicle by adding tot he player position
        transform.position = player.transform.position + offset;
    }
}
