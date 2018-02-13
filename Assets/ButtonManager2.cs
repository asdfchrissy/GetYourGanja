using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager2 : MonoBehaviour {


    public GameObject Bildschirm1;
    public GameObject Bildschirm2;
    public GameObject Bildschirm3;
    public GameObject Bildschirm4;
    public GameObject Bildschirm5;
    public GameObject Levelwechsel;

    // Use this for initialization
    void Start () {
        Bildschirm1.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bildschirmeins()
    {
        Bildschirm2.SetActive(true);
        Bildschirm1.SetActive(false);
    }
    public void Bildschirmzwei()
    {
        Bildschirm3.SetActive(true);
    }
    public void Bildschirmdrei()
    {
        Bildschirm3.SetActive(false);
        Bildschirm4.SetActive(true);
    }
    public void Bildschirmvier()
    {
        Bildschirm4.SetActive(false);
        Bildschirm5.SetActive(true);
        Levelwechsel.SetActive(true);
    }


}
