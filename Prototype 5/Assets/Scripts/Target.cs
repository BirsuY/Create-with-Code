using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;
    public ParticleSystem explosionParticle;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -3;
    public int pointValue;

    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown(){
        if(gameManager.isGameActive){
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if(gameObject.CompareTag("Bad")){
                gameManager.GameOver();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }
    private Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque(){
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomPos(){
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
