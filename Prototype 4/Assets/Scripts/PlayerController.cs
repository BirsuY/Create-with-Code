using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    private float speed = 5.0f;
    private float poweredUp = 15.0f;
    private bool hasPowerUp = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        hasPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerUpIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PowerUp")){
            hasPowerUp = true;
            Destroy(other.gameObject);

            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(CountdownRoutine());
        }
    }

    IEnumerator CountdownRoutine(){
        yield return new WaitForSeconds(10);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision other){
        
        if(other.gameObject.CompareTag("Enemy") && hasPowerUp){
            //Debug.Log("Collided with " + other.gameObject.name + " with powerup set to " + hasPowerUp);
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFrom = other.gameObject.transform.position-transform.position;

            enemyRb.AddForce(awayFrom * poweredUp, ForceMode.Impulse);
        }
    }

}
