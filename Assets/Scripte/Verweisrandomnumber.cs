using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verweisrandomnumber : MonoBehaviour {

    Animator anim;

  


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator HandleIt()
    {
        int pickAnumber = Random.Range(1, 10);
        anim.SetInteger("Verweis", pickAnumber);
        // process pre-yield
        yield return new WaitForSeconds(2f);
        // process post-yield
        anim.SetInteger("Verweis", 0);
    }
    
}


