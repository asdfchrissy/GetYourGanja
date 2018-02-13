using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1StageMachine : MonoBehaviour
{
    public GameObject StateMachine;
    public GameObject GegnerSpawner;
    public GameObject Verweis;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateMachine.GetComponent<BoxCollider2D>().enabled = false;
            Verweis.GetComponent<FollowEnemy>().enabled = true;
            GegnerSpawner.SetActive(true);
        }

    }
}
