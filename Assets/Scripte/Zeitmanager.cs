using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeitmanager : MonoBehaviour {

    public float zeitlimit;

	// Use this for initialization
	void Start () {
        GameObject.Find("Zeitlimit").GetComponent<Zeitlimit>().enabled = false;
        //GameObject.Find("Timefeld").SetActive(false);
        //zeitlimit = GameObject.Find("Stage2StateMachine").GetComponent<Stage2StateMachine>().countdown;
    }
	
	// Update is called once per frame
	void Update () {

        
		
	}
}
