using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2StateMachine : MonoBehaviour {

    public float countdown;
    public GameObject StateMachine;
    public GameObject GegnerSpawner;
    public Text txt;
    public GameObject text;
    public GameObject Hanf;

    public float Lebenspunkte;

    public GameObject Joint100;
    public GameObject Joint80;
    public GameObject Joint60;
    public GameObject Joint40;
    public GameObject Joint20;
    public GameObject Joint10;

    // Use this for initialization
    void Start()
    {
        countdown = 140;
        text.SetActive(false);
        Lebenspunkte = GameManager.instance.leben;
        /*
        if (Lebenspunkte >= 0 && Lebenspunkte <= 2)
        {
            StateMachine.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(HandleIt());
        }
        */
    }

    void OnGUI()
    {
        float round = Mathf.Round(countdown);
        txt.text = "" + round.ToString();
    }

    // Update is called once per frame
    void Update () {

        if (countdown >= -10 && countdown <= 120)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown >=70 && countdown <= 90)
        {
            //GameObject.Find("Zeitlimit").GetComponent<Zeitlimit>().zeitlimit = countdown;
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().spawnRate = 1;
        }

        if (countdown >= 50 && countdown < 70 )
        {
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().spawnRate = 0.5f;
        }

        if (countdown >= 30 && countdown < 50)
        {
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().spawnRate = 0.3f;
        }

        if (countdown > 0 && countdown < 30)
        {
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().spawnRate = 0.1f;
        }

        if (countdown >= -2 && countdown < 0)
        {
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().enabled = false;
            //GameObject.Find("Zeitlimit").GetComponent<Zeitlimit>().enabled = false;
            text.SetActive(false);
            
        }

        if (countdown < -2) 
        {
            Hanf.SetActive(true);
            //GameObject.Find("NachKampfExit").GetComponent<BoxCollider2D>().enabled = true;
        }



        //Test mit Joint:
        if (countdown >= 50 && countdown <= 80)
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

    /*
    public IEnumerator HandleIt()
    {
        StateMachine.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("YAUUU");
        // process pre-yield
        yield return new WaitForSeconds(2f);
        // process post-yield
        countdown = 80;
        GegnerSpawner.SetActive(true);
        text.SetActive(true);
    }
    */


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateMachine.GetComponent<BoxCollider2D>().enabled = false;
            countdown = 80;
            GegnerSpawner.SetActive(true);
            text.SetActive(true);

        }

    }

}
