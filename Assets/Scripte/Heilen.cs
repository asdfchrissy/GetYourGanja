using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heilen : MonoBehaviour {

    public int heilen;
    public GameObject item;
    private float countdown;


	// Use this for initialization
	void Start () {
        countdown = 5;
        
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            item.SetActive(false);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("WASCH");
            GameManager.instance.health += heilen;
            item.SetActive(false);

        }
    }

    public void HEILENAUFHUNDERT()
    {
        GameManager.instance.health += 100;
    }
}
