using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3 (Demo-Dialog)"))
        {
            GameManager.instance.Demonstration(); 
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Hauptmenü (fertig)"))
        {
            GameManager.instance.Anfang();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1 (Prolog-Zuhause)"))
        {
            GameManager.instance.Zuhause();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2 (Schule-Dialog)"))
        {
            GameManager.instance.Schule();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Justicia Stage 1 (Prolog)"))
        {
           GameManager.instance.Justicia();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Justicia Stage 5 (Epilog)"))
        {
            gameObject.SetActive(false);
        }
    }

    public void Heiligenanfang()
    {
        GameManager.instance.AudioStop();
    }
    public void Heiligenende()
    {
        GameManager.instance.Anfang();
    }
}
