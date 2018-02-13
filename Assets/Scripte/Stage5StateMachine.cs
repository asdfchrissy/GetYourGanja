using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage5StateMachine : MonoBehaviour
{

    public GameObject Kamera1;
    public GameObject Kamera2;
    public GameObject Spieler;
    public GameObject MortlerScreen;
    //public GameObject CanvasObject;
    public GameObject Dialogbox;
    public GameObject Blackscreen;
    public GameObject Blinzeln;
    public GameObject Dateiwiederherstellen;
    public GameObject Müll;


    public GameObject Nachricht;
    public GameObject Desktop;
    public GameObject Dateilöschen;

    public GameObject Text1;
    public GameObject Text2;
    


    public float countdown;
    // Use this for initialization
    void Start()
    {
        GameManager.instance.health = 100;
        countdown = 10;


    }


    // Update is called once per frame
    void Update()
    {
        if (countdown >= -10 && countdown <= 120)
        {
            countdown -= Time.deltaTime;
        }


        if (countdown >= 3 && countdown <= 8)
        {
            Blackscreen.SetActive(false);
            //MortlerScreen.SetActive(true);
            Blinzeln.SetActive(true);
        }


        if (countdown > 1 && countdown < 3)
        {
            MortlerScreen.SetActive(true);
            Kamera1.SetActive(false);
            Kamera2.SetActive(true);


        }


        if (countdown >= -5 && countdown <= 0)
        {
            MortlerScreen.SetActive(true);
            Dialogbox.SetActive(true);
            Spieler.SetActive(true);
        }
    }

    public void Nein()
    {
        Nachricht.SetActive(true);
        Dateilöschen.SetActive(false);
    }

    public void Schließen()
    {
        Dialogbox.SetActive(false);
        Desktop.SetActive(true);
        Dateilöschen.SetActive(true);
    }
    public void Schließen2()
    {
        Nachricht.SetActive(false);
        Müll.SetActive(true);
    }
    public void Schließen3()
    {
        Text1.SetActive(false);
        Müll.SetActive(true);
    }
    public void Schließen4()
    {
        Text2.SetActive(false);
        Müll.SetActive(true);
    }

    public void GetYG()
    {
        SceneManager.LoadScene(0);
    }
    public void GYLSD()
    {
        Dateiwiederherstellen.SetActive(true);
    }
    public void NOGYLSD()
    {
        Dateiwiederherstellen.SetActive(false);
    }
    public void StartLSD()
    {
         SceneManager.LoadScene(18);
    }

    public void Text1Button()
    {
        Nachricht.SetActive(false);
        Text1.SetActive(true);
    }
    public void Text2Button()
    {
        Nachricht.SetActive(false);
        Text2.SetActive(true);
    }
    public void weiter()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
    }

    public void Internet()
    {
        Application.OpenURL("https://yourpart.eu/p/getyourganja");
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

}

