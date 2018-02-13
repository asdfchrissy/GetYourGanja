using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Zwischensequenz : MonoBehaviour
{

    public GameObject nimmEs;
    public GameObject Kamera1;
    public GameObject Kamera2;
    public int nextLevel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrogeNehmen()
    {
        nimmEs.SetActive(true);
        Kamera1.SetActive(false);
        Kamera2.SetActive(true);
        StartCoroutine(HandleIt());
}

public IEnumerator HandleIt()
{
        // process pre-yield
    yield return new WaitForSeconds(10f);
        // process post-yield
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

}
