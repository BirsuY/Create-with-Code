using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    protected CarMovement car;
    private float offset = 10f;

    void Start()
    {
        car = GameObject.Find("Car").GetComponent<CarMovement>();
    }

    void Update()
    {
        if (car.carPos.z > this.transform.position.z + offset )
        {
            Destroy(this.gameObject);
        }
    }
}
