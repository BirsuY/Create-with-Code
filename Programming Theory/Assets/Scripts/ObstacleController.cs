using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : ObjectController
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            car.SetSpeed(0);            
            SceneManagement.Instance.PauseGame();
        }
    }
}