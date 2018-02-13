using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selbstzerstörung : MonoBehaviour {

    public float lifetime;
   

    // Use this for initialization
    void Start () {
           

    }
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Debug.Log("FUCK");
            Destroy(gameObject);
        }
    }
}
