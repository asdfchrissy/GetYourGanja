using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //Punkteanzeige:
    //public int score;
    //public Text punkteanzeige;

    // Lebensanzeige:
    public float health;
    public int maxHealth;
    public float healthdavor;


    public GameObject schadensscreen;
    public bool schadengenommen;
    //public RectTransform healthBalken;

    public float leben;
    public Text lebensanzeige;

    //Verschiedene Screens:
    public GameObject normalScreen;

    //Text:
    //public Text hinweisanzeige;

    //public float zeit;

    public string sceneName;

    /*
    public GameObject Joint100;
    public GameObject Joint80;
    public GameObject Joint60;
    public GameObject Joint40;
    public GameObject Joint20;
    public GameObject Joint10;
    */

    //TEST:
    public float lebenfürHealthbar;
    public Image Schlange;
    public Image Schlangerot;


    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public float baggy;
    public GameObject Weedbags;
    public Text AnzahlderBaggys;

    public bool zeitverlangsamt;
    public float slowdownFactor;
    public GameObject Zeitanzeige;
    public float alterspeed;
    public float alterjump;



    //Musik:
    public AudioSource justicia;
    public AudioSource start;
    public AudioSource schule;
    public AudioSource demo;
    public AudioSource daheim;
    public bool musicon;
















    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        


    }
   

    /* Text: 
    public void hinweisAusgeben(string hinweis)
    {
        hinweisanzeige.text = hinweis;
    }
    */


    void OnGUI()
    {
       
        /*Lebensanzeige:
        healthBalken.localScale = new Vector3((float)health / maxHealth, 1, 1);
        lebensanzeige.text = "Leben: " + leben.ToString();
        */
        //Punkteanzeige:
        //punkteanzeige.text = "Score: " + score.ToString();

    }

    public void Sterben()
    {
        Debug.Log("Du bist gestorben!");
        health = maxHealth;
        leben -= 1;
        schadengenommen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (baggy < 3 || baggy > 6 )
        {
            baggy = 3;
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }



    // Use this for initialization
    void Start()
    {
        musicon = true;
        normalScreen.SetActive(true);
        health = maxHealth;
        //leben = 3;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Schlange.fillAmount = 1;
        GameIsPaused = false;
        schadengenommen = false;
        Anfang();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        AnzahlderBaggys.text = "" + baggy.ToString();
        lebensanzeige.text = "" + leben.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused){
                Resume();
            }else
            {
                Paused();
            }
        }

        if (health >= 100)
        {
            Schlange.enabled = false;
            Schlangerot.enabled = false;
            lebensanzeige.enabled = false;
            Weedbags.SetActive(false);
            
        }
        else
        {
            lebensanzeige.enabled = true;
            Weedbags.SetActive(true);

            Schlange.enabled = true;
            Schlangerot.enabled = true;
        }

        if (health <= 0){
            Sterben();
        }


        if (leben <= 0)
        {
            leben = 3;
            baggy = 3;
            //normalScreen.SetActive(false);
            SceneManager.LoadScene(1);
        }

        
        lebenfürHealthbar = health;
        Schlange.fillAmount = (lebenfürHealthbar / 100);

        if (baggy > 10)
        {
            baggy = 10;
        }
        if (baggy < 0)
        {
            baggy = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (baggy >0 && zeitverlangsamt == false)
            {
                alterspeed = GameObject.Find("Player").GetComponent<Player>().movementSpeed;
                
                baggy -= 1;
                StartCoroutine(HandleIt());
            }
        }

     

        if (schadengenommen == true)
        {
            schadensscreen.SetActive(true);
            healthdavor = health;
            StartCoroutine(Lebensermittler());
        }
        if (schadengenommen == false)
        {
            schadensscreen.SetActive(false);
        }


        if (musicon == true)
        {
            AudioListener.volume = 1;
        }
        if (musicon == false)
        {
            AudioListener.volume = 0;
        }


    }

    public IEnumerator Lebensermittler()
    {
        // process pre-yield
        yield return new WaitForSeconds(0.5f);
        // process post-yield
        Debug.Log("Zwei sekunden gewartet");
        if (healthdavor <= health)
        {
            schadengenommen = false;
        }
    }

    public IEnumerator HandleIt()
    {
        Zeitanzeige.SetActive(true);
        Time.timeScale = slowdownFactor;
        GameObject.Find("Player").GetComponent<Player>().movementSpeed += alterspeed;
        zeitverlangsamt = true;
        // process pre-yield
        yield return new WaitForSeconds(4f);
        // process post-yield
        Time.timeScale = 1f;
        GameObject.Find("Player").GetComponent<Player>().movementSpeed -= alterspeed;
        
        Zeitanzeige.SetActive(false);
        zeitverlangsamt = false;

    }
   

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        
    } 
    public void QuitGame()
    {
        Application.Quit();
    }






    //MUSIK:
    public void Anfang()
    {
        if(musicon == true)
        {
            
            start.Play();
            demo.Stop();
            schule.Stop();
            justicia.Stop();
            daheim.Stop();
            
        }
        else
        {

            
            start.Stop();
            demo.Stop();
            schule.Stop();
            justicia.Stop();
            daheim.Stop();
            
        }
    }
    public void Zuhause()
    {
        if (musicon == true) { 
        start.Stop();
        demo.Stop();
        schule.Stop();
        justicia.Stop();
        daheim.Play();
    }
        else
        {
            start.Stop();
            demo.Stop();
            schule.Stop();
            justicia.Stop();
            daheim.Stop();
        }
    }
    public void Demonstration()
{
    if (musicon == true) { 
        start.Stop();
    demo.Play();
    schule.Stop();
    justicia.Stop();
    daheim.Stop();
}
        else
        {
            start.Stop();
            demo.Stop();
            schule.Stop();
            justicia.Stop();
            daheim.Stop();
        }
    }
    public void Schule()
    {
        if (musicon == true)
        {

            start.Stop();
            demo.Stop();
            schule.Play();
            justicia.Stop();
            daheim.Stop();
        }
        else
        {
            start.Stop();
            demo.Stop();
            schule.Stop();
            justicia.Stop();
            daheim.Stop();
        }
    }
    public void Justicia()
    {
        if (musicon == true) { 
            start.Stop();
        demo.Stop();
        schule.Stop();
        justicia.Play();
        daheim.Stop();
    }
        else
        {
            start.Stop();
            demo.Stop();
            schule.Stop();
            justicia.Stop();
            daheim.Stop();
        }
    }

    public void AudioStop()
    {
                start.Stop();
                demo.Stop();
                schule.Stop();
                justicia.Stop();
                daheim.Stop();
    }


}

