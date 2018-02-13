using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2StateMachine2: MonoBehaviour {

    public GameObject Verweisspawner;
    public GameObject Verweisducken;
    public GameObject Verweisspringen;
    public GameObject Levelwechsel;
    public GameObject StateMachine;

    public GameObject Dialog;

    public Text txt;
    public GameObject text;
    public GameObject Hanf;

    public float countdown;

    public GameObject Joint100;
    public GameObject Joint80;
    public GameObject Joint60;
    public GameObject Joint40;
    public GameObject Joint20;
    public GameObject Joint10;

    public float Lebenspunkte;


    void OnGUI()
    {
        float round = Mathf.Round(countdown);
        txt.text = "" + round.ToString();
    }

    // Use this for initialization

    void Start () {
        countdown = 70;
        text.SetActive(true);
        Lebenspunkte = GameManager.instance.leben;
        StartCoroutine(HandleIt());

        /*if (Lebenspunkte >= 0 && Lebenspunkte <= 2)
        {
            StartCoroutine(HandleIt());
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
        //countdown -= Time.deltaTime;
        
        if(countdown >= -10 && countdown <= 65)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown >=40  && countdown <= 60)
        {
            Verweisspawner.SetActive(true);

        }
        if (countdown >= 20 && countdown < 40)
        {
            //Verweisducken.SetActive(true);
        }

        if (countdown > 0 && countdown < 20)
        {
            //Verweisspringen.SetActive(true);
        }
        if (countdown >= -10 && countdown <= 0)
        {
            StateMachine.GetComponent<BoxCollider2D>().enabled = true;
            Levelwechsel.SetActive(true);
            text.SetActive(false);
            Verweisspawner.SetActive(false);
            Verweisspringen.SetActive(false);
            
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

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        StateMachine.GetComponent<BoxCollider2D>().enabled = false;
    }
    */
    public IEnumerator HandleIt()
    {
        Verweisspawner.SetActive(false);
        Debug.Log("YAUUU");
        // process pre-yield
        yield return new WaitForSeconds(2f);
        // process post-yield
        countdown = 60;
        Verweisspawner.SetActive(true);
        text.SetActive(true); 
    }
}
