using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Speedtext;
    [SerializeField] private TextMeshProUGUI Scoretext;

    protected float speed = 10.0f;
    [SerializeField] float speed__;
    private Rigidbody rb;
    public Vector3 carPos;

    public int points;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
        speed__ = _speed;
    }
    void FixedUpdate()
    {
        Speedtext.SetText("Speed: " + speed__ +"km/h");
        carPos = transform.position;
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward(speed * 3);
        }
        else
        {
            MoveForward(speed);
        }
    }

    void MoveForward(float speed)
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        speed__ = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f);
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            points += 1;
            Scoretext.SetText("Score: " + points);
            
        }
    }
}
