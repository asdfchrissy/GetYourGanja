using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


    public GameObject hauptScreen;
    public GameObject levelScreen;
    public GameObject optionScreen;

    AudioSource audioSource;
    public AudioSource audio;

    // Use this for initialization
    void Start()
    {

        levelScreen.SetActive(false);
        optionScreen.SetActive(false);
        hauptScreen.SetActive(true);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                        SceneManager.LoadScene(1);
        }

    }


    
    public void HauptmenueBtn()
    {
        audio.Play();
        SceneManager.LoadScene(1);
       

    }
    public void NewGameBtn(string newGameLevel)
    {
        
        GameManager.instance.normalScreen.SetActive(true);
        SceneManager.LoadScene(17);

    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void LevelwechselBtn()
    {
        hauptScreen.SetActive(false);
        levelScreen.SetActive(true);
        audio.Play();
    }

    public void OptionenBtn()
    {
        hauptScreen.SetActive(false);
        optionScreen.SetActive(true);
        audio.Play();
    }

    public void MusikBtn()
    {
        audioSource.mute = !audioSource.mute;
    }



    public void Zuhause()  
    {        SceneManager.LoadScene(10);    }

    public void Schule()
    {        SceneManager.LoadScene(11);    }

    public void Demonstration()
    {        SceneManager.LoadScene(13);    }

    public void KampfderGesetze()    
    {        SceneManager.LoadScene(2);    }

    public void Testlevel()
    { SceneManager.LoadScene(10); }

    public void Gesetzbuch()
    { SceneManager.LoadScene(4); }
    public void Schwert()
    { SceneManager.LoadScene(6); }
    public void Polizei()
    { SceneManager.LoadScene(8); }


    public void Musikaus()
    {
        GameManager.instance.musicon = false;
        
    }
    public void Musikan()
    {
        GameManager.instance.musicon = true;
        GameManager.instance.Anfang();
    }

}
