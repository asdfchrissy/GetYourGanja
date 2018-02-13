using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogohneSpawn : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    private float alterspeed;
    private float alterjump;

    public AudioSource audio;
    public AudioSource audio1;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();

        alterspeed = GameObject.Find("Player").GetComponent<Player>().movementSpeed;
        alterjump = GameObject.Find("Player").GetComponent<Player>().jumpHigh;

        

    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        audio1.Play();
        nameText.text = dialogue.name;

        sentences.Clear();

        GameObject.Find("Player").GetComponent<Player>().movementSpeed = 0;
        GameObject.Find("Player").GetComponent<Player>().jumpHigh = 0;
        

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        Debug.Log("Koks");
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            GameObject.Find("Player").GetComponent<Player>().movementSpeed = alterspeed;
            GameObject.Find("Player").GetComponent<Player>().jumpHigh = alterjump;
            return;
        }
        audio.Play();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
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
        audio1.Play();

    }

}
