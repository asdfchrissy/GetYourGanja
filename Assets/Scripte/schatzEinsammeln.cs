using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schatzEinsammeln : MonoBehaviour {

    public int punkte;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().score += punkte;          
        }
    }
}
