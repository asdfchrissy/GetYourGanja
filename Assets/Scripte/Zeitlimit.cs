using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Zeitlimit : MonoBehaviour {

    public float zeitlimit;
    public float countdown;
    public Text txt;


    void OnGUI()
    {
        float round = Mathf.Round(countdown);
        txt.text = "" + round.ToString();
    }

    // Use this for initialization
    void Start () {
        countdown = zeitlimit;
        
    }
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        
        
        /* if (countdown <= 0)
        {
            GameManager.instance.Sterben();
            countdown = zeitlimit;

        }
        */
    }
}
