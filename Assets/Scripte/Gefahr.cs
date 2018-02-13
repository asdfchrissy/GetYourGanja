using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gefahr : MonoBehaviour {

    public float schaden;
   
  

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.schadengenommen = true;
            GameManager.instance.health -= schaden;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.schadengenommen = false;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
