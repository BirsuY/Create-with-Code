using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneManagement : MonoBehaviour
{
    private GameObject ball;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        pos = ball.transform.position;

    }

    

    public void RestartGame(){
        ball.transform.position = pos;
    }
}
