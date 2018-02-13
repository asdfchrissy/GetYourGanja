using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schadenfeedback : MonoBehaviour {

    public GameObject roterschaden;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(HandleIt());
        }
    }

    public IEnumerator HandleIt()
    {
        roterschaden.SetActive(true);
        Debug.Log("Wasn das los?");
        // process pre-yield
        yield return new WaitForSeconds(0.1f);
        // process post-yield
        roterschaden.SetActive(false);

    }
}
