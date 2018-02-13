using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textfeld : MonoBehaviour {

    public string hinweistext;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Debug.Log("bis hierher funktioniert es");
            //GameManager.instance.hinweisAusgeben(hinweistext);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
