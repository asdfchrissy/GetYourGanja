using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schwertrausholen : MonoBehaviour
{
    public GameObject item;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            item.GetComponent<SpriteRenderer>().enabled = true;
            item.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Zeigen()
    {
        item.SetActive(true);
    }
}
