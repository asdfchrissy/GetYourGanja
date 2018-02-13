using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gefahreinmal : MonoBehaviour {

    public int schaden;
    public GameObject item;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.health -= schaden;
            GameManager.instance.schadengenommen = true;
            item.GetComponent<SpriteRenderer>().enabled = false;
            item.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(HandleIt());
        }
    }
    public IEnumerator HandleIt()
    {
        Debug.Log("Wasn das los?");
        // process pre-yield
        yield return new WaitForSeconds(0.1f);
        // process post-yield
        GameManager.instance.schadengenommen = false;
    }
}
