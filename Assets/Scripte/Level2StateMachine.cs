using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2StateMachine : MonoBehaviour {

    public GameObject Verweis;
    public GameObject StateMachine;
    public GameObject Levelwechsel;
    // public GameObject Zeitanzeigen;
    //public Text txt;
    //public GameObject text;
    //public float countdown;

    // Use this for initialization
    void Start()
    {
       // countdown = 140;
       // Zeitanzeigen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (countdown >= -10 && countdown <= 120)
          {
              Debug.Log("BISHERHERUNDNICHTWEITER");
              countdown -= Time.deltaTime;
              Zeitanzeigen.SetActive(true);
          }
          if (countdown <= -10 && countdown <= 0)
          {
              Zeitanzeigen.SetActive(false);
          }

*/
    }
    
      private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.tag == "Player")
          {
            StartCoroutine(HandleIt());
          }
  
      }

    private IEnumerator HandleIt()
    {
        // process pre-yield
        yield return new WaitForSeconds(1f);
        // process post-yield
        Verweis.SetActive(true);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Verweis.SetActive(true);
            StateMachine.GetComponent<BoxCollider2D>().enabled = false;
            //countdown = 60;
            Levelwechsel.SetActive(true);

        }

    }
    /*
    void OnGUI()
    {
        float round = Mathf.Round(countdown);
        txt.text = "" + round.ToString();
    }
    */
}
