using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3StateMachine : MonoBehaviour
{

    public GameObject zerstörtejustica;
    public GameObject schwertarm;
    public GameObject schwertrising;
    public GameObject Stage2StateMachine;
    public GameObject schwert;
    

    public GameObject Schwerstechenvonlinks;
    public GameObject Schwerstechenvonrechts;
    public GameObject Schwertvonoben;
    public GameObject Schwertstechenvonunten;
    public GameObject Schwertmassaker;

    public Text txt;
    public GameObject text;
    public GameObject Hanf;

    public GameObject Joint100;
    public GameObject Joint80;
    public GameObject Joint60;
    public GameObject Joint40;
    public GameObject Joint20;
    public GameObject Joint10;


    //private float spielergeschwindigkeit;

    public float countdown;
    // Use this for initialization
    void Start()
    {

        countdown = 140;
    }

    void OnGUI()
    {
        float round = Mathf.Round(countdown);
        txt.text = "" + round.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //spielergeschwindigkeit = GameObject.Find("Player").GetComponent<Player>().movementSpeed;

        if (countdown >= -10 && countdown <= 120)
        {
            countdown -= Time.deltaTime;
            //GameObject.Find("Zeitlimit").GetComponent<Zeitlimit>().enabled = true;

        }

        if (countdown >= 40 && countdown <= 60)
        {
            Schwerstechenvonlinks.SetActive(true);
            Schwerstechenvonrechts.SetActive(true);
            
        }

        if (countdown >= 20 && countdown < 40)
        {
            Schwertstechenvonunten.SetActive(true);
        }

        if (countdown > 0 && countdown < 20)
        {
            Schwertmassaker.SetActive(true);
        }

        if (countdown <= 0 && countdown > -5)
        {
            
            Schwerstechenvonlinks.SetActive(false);
            Schwerstechenvonrechts.SetActive(false);
            Schwertstechenvonunten.SetActive(false);
            Schwertvonoben.SetActive(false);
            
        }
        if (countdown < 0){
            //GameObject.Find("Zeitlimit").GetComponent<Zeitlimit>().enabled = false;
            text.SetActive(false);

        }
        if (countdown <= -2)
        {
            Hanf.SetActive(true);
        }

        if (countdown >= 50 && countdown <= 60)
        {
            Joint100.SetActive(true);
            Joint10.SetActive(false);

        }
        if (countdown >= 40 && countdown < 50)
        {
            Joint100.SetActive(false);
            Joint80.SetActive(true);
        }
        if (countdown >= 30 && countdown < 40)
        {
            Joint80.SetActive(false);
            Joint60.SetActive(true);
        }
        if (countdown >= 20 && countdown < 30)
        {
            Joint60.SetActive(false);
            Joint40.SetActive(true);
        }
        if (countdown >= 10 && countdown < 20)
        {
            Joint40.SetActive(false);
            Joint20.SetActive(true);
        }
        if (countdown >= 0 && countdown < 10)
        {
            Joint20.SetActive(false);
            Joint10.SetActive(true);

        }


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            zerstörtejustica.GetComponent<SpriteRenderer>().enabled = false;
            schwertarm.GetComponent<SpriteRenderer>().enabled = false;
            schwertrising.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Schwertzeigen").GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Stage2StateMachine.GetComponent<BoxCollider2D>().enabled = false;
            schwert.GetComponent<SpriteRenderer>().enabled = true;
            schwert.GetComponent<BoxCollider2D>().enabled = true;
            text.SetActive(true);
            countdown = 70;

        }

    }


}
