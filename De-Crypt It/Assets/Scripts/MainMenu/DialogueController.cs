using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{

    public Text characterNameText;
    public Text dialogueText;

    public Animator animator;

    // Create a queue of sentences
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); // Initialise queue of sentences
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

       //Debug.Log("Hello there " +dialogue.characterName);
       characterNameText.text = dialogue.characterName; 

       sentences.Clear(); // Clear any previous convo sentences

       // Go through all strings in the dialogue.storySentences array
       foreach (string sentence in dialogue.sentences)
       {
           sentences.Enqueue(sentence); // Setences will addded in the queue
       }
       
       ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        if(sentences.Count == 0) // If there is no more sentences in queue
        {
            startSinglePlayerGame();
            return;
        }

        string sentence = sentences.Dequeue(); // Stores the deqeued sentence in a variable
        //dialogueText.text = sentence;
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

    public void startSinglePlayerGame()
    {
        Debug.Log("You are now transfered into the game!");
        SceneManager.LoadScene("MainGame");
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}   
