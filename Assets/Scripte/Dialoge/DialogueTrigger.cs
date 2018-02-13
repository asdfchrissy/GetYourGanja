using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public GameObject item;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TriggerDialogue();                        
        }
    }

    public void TriggerDialogue ()
	{
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        item.GetComponent<BoxCollider2D>().enabled = false;
    }

}
