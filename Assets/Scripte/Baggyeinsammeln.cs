using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baggyeinsammeln : MonoBehaviour {

    public int plastikbeutel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.instance.baggy += plastikbeutel;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
