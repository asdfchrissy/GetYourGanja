using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rauchpusten : MonoBehaviour {
    public GameObject item;
   public float wvbaggys;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        wvbaggys = GameManager.instance.baggy;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rauch")
        {
            if (wvbaggys > 0)
            {
                item.SetActive(false);
                //item.GetComponent<BoxCollider2D>().enabled = false;
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //gameObject.GetComponent<BoxCollider2D>().enabled = false;
                GameManager.instance.baggy -= 1;
            }
            else
            {
                Debug.Log("Zu Wenig WEED");
            }
        }
    }
}
