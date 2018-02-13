using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verstecken : MonoBehaviour {

    public SpriteRenderer sprite;
    public BoxCollider2D gefahrenzoneVater;
    public BoxCollider2D gefahrenzoneMutter;
    public Animator spieleranimator;
    public int sortingOrder;
    public int alterLayer;
    public float alterspeed;
    public float alterjump;

    // Use this for initialization
    void Start () {

        sprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        gefahrenzoneVater = GameObject.Find("GefahrentriggerVater").GetComponent<BoxCollider2D>();
        gefahrenzoneMutter = GameObject.Find("GefahrentriggerMutter").GetComponent<BoxCollider2D>();
        alterspeed = GameObject.Find("Player").GetComponent<Player>().movementSpeed;
        alterjump = GameObject.Find("Player").GetComponent<Player>().jumpHigh;
        spieleranimator= GameObject.Find("Player").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("IM SCHRANK?");
        if (Input.GetKey(KeyCode.C) && other.tag == "Player")
        {
            sprite.sortingOrder = sortingOrder;
            GameObject.Find("Player").GetComponent<Player>().movementSpeed = 0;
            GameObject.Find("Player").GetComponent<Player>().jumpHigh = 0;
            gefahrenzoneMutter.enabled = false;
            gefahrenzoneVater.enabled = false;
            spieleranimator.enabled = false;
            Debug.Log("IM WOOOO?");
        }
        if (Input.GetKey(KeyCode.V) && other.tag == "Player")
        {
            Debug.Log("IM nichtmehrschrnak?");
            sprite.sortingOrder = alterLayer;
            GameObject.Find("Player").GetComponent<Player>().movementSpeed = alterspeed;
            GameObject.Find("Player").GetComponent<Player>().jumpHigh = alterjump;
            gefahrenzoneMutter.enabled = true;
            gefahrenzoneVater.enabled = true;
            spieleranimator.enabled = true;
        }

    }
}
