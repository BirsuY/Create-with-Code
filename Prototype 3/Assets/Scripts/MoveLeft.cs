using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20f;
    private PlayerController PlayerControllerScript;
    private float leftBound = -10f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControllerScript.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(gameObject.CompareTag("Obstacle") && transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
