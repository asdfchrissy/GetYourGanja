using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schwertschwingen : MonoBehaviour {

     public Animation anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("NUTTE");
            anim.Play();
            
        }
    }

   /* IEnumerator verzogerung()
    {
        while (true)
        {

            yield return new WaitForSeconds(1f);
            anim.enabled = true;
        }
    }
    */
}
