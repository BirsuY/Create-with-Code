using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject car;
    private Vector3 offset = new Vector3(0, 3, -5);
    void Start()
    {
        car = GameObject.Find("Car");
    }
    void LateUpdate()
    {
        transform.position = car.transform.position + offset;
    }
}
