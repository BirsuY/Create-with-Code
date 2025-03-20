using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private GameObject ball;
    private GameObject goalPost;
    private Rigidbody rb;
    private bool isNextTo = false;
    private float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        ball = GameObject.Find("Ball");
        goalPost = GameObject.Find("GoalPost1");
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Ball")){
            isNextTo = true;
        }
        //if player is on the way go to another direction
    }

    void MoveEnemy(){
        if(!isNextTo){
            Vector3 lookDir = (ball.transform.position-transform.position).normalized;
            rb.AddForce(lookDir * speed);
        }
        else{
            Vector3 lookDir = (goalPost.transform.position-transform.position).normalized;
            rb.AddForce(lookDir * speed);
        }
    }
}
