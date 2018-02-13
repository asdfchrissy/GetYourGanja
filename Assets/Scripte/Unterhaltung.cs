using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Unterhaltung : MonoBehaviour {

    public Text justica;
    public Text johnny;
    


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
                Anzeigen();
            }
        }

    public void Anzeigen()
    {
        justica.text = "DU BIST EIN KIFFER!? EIN SIECHENDER UNTERMENSCH!?";
    }

}
