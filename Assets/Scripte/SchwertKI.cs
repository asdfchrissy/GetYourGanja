using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchwertKI : MonoBehaviour {

    private Vector3 pos1 = new Vector2(-12, 2);
    private Vector3 pos2 = new Vector2(10, 2);
    public float speed = 1.0f;
    
    //-12,2
    //6,2

    
    void Update()
    {

        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));     
        

    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            speed = 0.01f;

        }
    }
    */

    // Use this for initialization
    void Start () {

    }
}
