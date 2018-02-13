using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour {

    public AudioSource zuhause;
    public AudioSource schule;
    public AudioSource demo;
    public AudioSource justicia;
    public AudioSource start;



    // Use this for initialization

    
    void Start () {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is '" + scene.name + "'.");
        Anfang();
    }

    // Update is called once per frame
    void Update () {
        Scene scene2 = SceneManager.GetActiveScene();

        
    }

    /*
    private void Musikwechsel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Hauptmenü (fertig)"))
        {
            Anfang();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3 (Demo-Dialog)"))
        {
            Demonstration();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1 (Prolog-Zuhause)"))
        {
            zuhause.Play();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2 (Schule-Dialog)"))
        {
            Schule();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Justicia Stage 1 (Prolog)"))
        {
            Justicia();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Justicia Stage 5 (Epilog)"))
        {
            gameObject.SetActive(false);
        }
    }
    */

    public void Anfang()
    {
        start.Play();
    }
    public void Demonstration()
    {
        demo.Play();
    }
    public void Schule()
    {
        schule.Play();
    }
    public void Justicia()
    {
        justicia.Play();
    }



}
