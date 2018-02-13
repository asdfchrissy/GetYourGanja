using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herunterfallenderGegenstand : MonoBehaviour
{
    
    public GameObject gegenstand;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gegenstand.GetComponent<Rigidbody2D>().simulated = true;
        }
    }
}
