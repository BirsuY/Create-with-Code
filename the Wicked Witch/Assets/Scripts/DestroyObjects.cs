using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private GameObject plane;
    private GameObject skull;
    
    private GameObject wood;
    private GameObject rock;

    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        plane = GameObject.Find("Plane(Clone)");
        skull = GameObject.Find("Skull(Clone)");
        wood = GameObject.Find("Wood(Clone)");
        rock = GameObject.Find("Rock(Clone)");
        DestroyObject();
    }

    void DestroyObject(){
        float pos = player.transform.position.x;

        if(plane.transform.position.x < pos - 40){
            Destroy(plane);
        }
        if(skull.transform.position.x < pos - 40){
            Destroy(skull);
        }
        if(wood.transform.position.x < pos - 40){
            Destroy(wood);
        }
        if(rock.transform.position.x < pos - 40){
            Destroy(rock);
        }
    }
}
