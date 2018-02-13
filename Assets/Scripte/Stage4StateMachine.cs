using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage4StateMachine : MonoBehaviour {


    public GameObject Polizistgroß;
    public GameObject Polizistkniend;
    public GameObject Polizist1;
    public GameObject Polizist2;
    public GameObject Polizist3;
    public GameObject StateMachine;
    public GameObject Kamera1;
    public GameObject Kamera2;
    public GameObject Heiler;
    public GameObject NachKampfexit;

    public Text txt;
    public GameObject text;

    public float countdown;
    private float falschezeit;



    void OnGUI()
    {
        float round = Mathf.Round(falschezeit);
        txt.text = "" + round.ToString();
    }
    // Use this for initialization
    void Start () {
        
        countdown = 140;
        GameObject.Find("Zeitlimit").GetComponent<Zeitlimit>().enabled = false;
        text.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        falschezeit = countdown + 20;

        if (countdown >= -10 && countdown <= 120)
        {
            countdown -= Time.deltaTime;
            GameObject.Find("Zeitlimit").GetComponent<Zeitlimit>().enabled = true;
            Heiler.SetActive(true);
        }
        if (countdown >= 41 && countdown <= 45)
        {
            Polizist1.SetActive(true);
        }
        if (countdown >= 35 && countdown <= 40)
        {
            Polizistgroß.SetActive(true);
        }
        if (countdown >= 25 && countdown < 35)
        {
            Polizistkniend.SetActive(true);
        }
        if (countdown >= 15 && countdown < 25)
        {
            //Polizist1.SetActive(true);
        }
        if (countdown >= 5 && countdown < 15)
        {
            //Polizist2.SetActive(true);
            //Polizist3.SetActive(true);
        }
        if (countdown <= 0 && countdown > -5)
        {

            /*
           
            Polizist2.SetActive(false);
            Polizist3.SetActive(false);
             */
            Polizist1.SetActive(false);
            Polizistkniend.SetActive(false);
            Polizistgroß.SetActive(false);
            Heiler.SetActive(false);


        }
        if (countdown < 0)
        {
           
            Kamera1.SetActive(false);
            Kamera2.SetActive(true);
            
            
        }
        if (countdown <= -9)
        {

            NachKampfexit.SetActive(true);
            GameManager.instance.AudioStop();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateMachine.GetComponent<BoxCollider2D>().enabled = false;
            countdown = 45;
            text.SetActive(true);
        }

    }
}
