using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebensanzeige : MonoBehaviour {

    public GameObject img;
    public bool isImgOn;

    // Use this for initialization
    void Start () {
        img.SetActive(true);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("i"))
        {

            img.SetActive(false);
        }
    }
}
