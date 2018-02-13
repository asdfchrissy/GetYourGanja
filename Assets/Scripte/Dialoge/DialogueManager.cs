using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager: MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;

    private float alterspeed;
    private float alterjump;

    //public float spawnZahl;


    


    // Use this for initialization
    void Start () {
		sentences = new Queue<string>();

        alterspeed = GameObject.Find("Player").GetComponent<Player>().movementSpeed;
        alterjump = GameObject.Find("Player").GetComponent<Player>().jumpHigh;
        // spawnZahl = GameObject.Find("Spawner").GetComponent<EnemySpawner>().spawnRate;

        
    }

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

        GameObject.Find("Player").GetComponent<Player>().movementSpeed = 0;
        GameObject.Find("Player").GetComponent<Player>().jumpHigh = 0;
        //GameObject.Find("Spawner").GetComponent<EnemySpawner>().spawnRate = 10;

        foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
   }

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
            GameObject.Find("Player").GetComponent<Player>().movementSpeed = alterspeed;
            GameObject.Find("Player").GetComponent<Player>().jumpHigh = alterjump;
            //GameObject.Find("Spawner").GetComponent<EnemySpawner>().spawnRate = spawnZahl;
            //GameObject.Find("Paragraph").GetComponent<SpriteRenderer>().enabled = true;
            //GameObject.Find("Paragraph").GetComponent<BoxCollider2D>().enabled = true;
            //Debug.Log("Test");
            //GameObject.Find("Spawner").GetComponent<EnemySpawner>().enabled = true;
            return;
		}
        Debug.Log("Test");
        string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
        animator.SetBool("IsOpen", false);
        //GameObject.Find("Paragraph").GetComponent<SpriteRenderer>().enabled = true;
        //GameObject.Find("Paragraph").GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("Test");
        //GameObject.Find("Spawner").GetComponent<EnemySpawner>().enabled = true;
    }

}
