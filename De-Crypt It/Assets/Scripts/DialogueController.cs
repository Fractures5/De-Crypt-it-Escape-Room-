using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    public Text characterNameText;
    public Text dialogueText;

    // Create a queue of sentences
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); // Initialise queue of sentences
    }

    public void StartDialogue (Dialogue dialogue)
    {
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
            FinishDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); // Stores the deqeued sentence in a variable
        dialogueText.text = sentence;
    }

    void FinishDialogue()
    {
        Debug.Log("End of the conversation.");
    }

}   
