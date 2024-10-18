using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;
    private int speed = 10;
    //private bool canChange = true;
    void Start()
    {
        transform.position = new Vector3(13, 5, 12);
        transform.localScale = Vector3.one * 3.1f;
        
        material = Renderer.material;
        material.color = new Color(0.5f, 0.6f, 0.1f, 0.3f);

    }
    
    void Update()
    {
        transform.Rotate(0.0f, 1.3f * Time.deltaTime * speed, 0.5f * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(changeColor());
            float rIndex = Random.Range(0.0f, 1.0f);
            float gIndex = Random.Range(0.0f, 1.0f);
            float bIndex = Random.Range(0.0f, 1.0f);
            float aIndex = Random.Range(0.0f, 1.0f);

            material.color = new Color(rIndex, gIndex, bIndex, aIndex);
            Debug.Log(rIndex);
            Debug.Log(gIndex);
            Debug.Log(bIndex);
            Debug.Log(aIndex);

        }
        
    }

    //IEnumerator changeColor()
    //{
    //    rIndex = Random.Range(0, 1);
    //    gIndex = Random.Range(0, 1);
    //    bIndex = Random.Range(0, 1);
    //    aIndex = Random.Range(0, 1);
    //    material.color = new Color(rIndex, gIndex, bIndex, aIndex);
    //    canChange = false;
    //    yield return new WaitForSecondsRealtime(1f);

    //    canChange = true;
    //}
}
