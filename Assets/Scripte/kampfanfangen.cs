using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kampfanfangen : MonoBehaviour {

    public GameObject zerstörtejustica;
    public GameObject schwertarm;
    public GameObject schwertrising;
    public GameObject hanftrigger;

    public GameObject schwert;

    private float spielergeschwindigkeit;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()    {
        spielergeschwindigkeit = GameObject.Find("Player").GetComponent<Player>().movementSpeed;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            zerstörtejustica.GetComponent<SpriteRenderer>().enabled = false;
            schwertarm.GetComponent<SpriteRenderer>().enabled = false;
            schwertrising.GetComponent<SpriteRenderer>().enabled = true;
            hanftrigger.GetComponent<SpriteRenderer>().enabled = false;
            
        }

        /* if (spielergeschwindigkeit > 0){
            Debug.Log("MAGIC!");
            anim.enabled = true;
         }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            hanftrigger.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("MAGIC!");
            schwert.GetComponent<SpriteRenderer>().enabled = true;
            schwert.GetComponent<BoxCollider2D>().enabled = true;
        }

    }
}
