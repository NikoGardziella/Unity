using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }
    void Update()
    {

        if (Input.anyKeyDown && animator.GetBool("isOpen") == true)
        {
            Debug.Log("anykeypressed");
            DisplayNextSentence();
        }

    } 
    public void StartDialogue(dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        

        Debug.Log("StartDialogue");
      //  sentences.Clear(); // should this be moved/removed?

        foreach(string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);

		}
        
        DisplayNextSentence();
       
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
		{

            EndDialogue();
            return;
		}

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
     /*   if (sentences.Count == 0)
        {
            Time.timeScale = 0;
        } */


    }

    IEnumerator TypeSentence(string sentence)
	{
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
		{
            dialogueText.text += letter;
            yield return null;
		}
        
    }

    void EndDialogue()
	{
        animator.SetBool("isOpen", false);
       // Time.timeScale = 1;
        Debug.Log("end of dialogue");
	}

}
