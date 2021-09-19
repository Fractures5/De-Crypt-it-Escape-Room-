using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    //This script manages the dialogue for the game story board
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
    //Starts the dialogue
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
    //this function will determine what sentence is shown next in the story board
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
    //this function will determine what sentence is shown next in the story board
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    //This will load the main game
    public void startSinglePlayerGame()
    {
        restartStatus();
        Debug.Log("You are now transfered into the game!");
        SceneManager.LoadScene("MainGame");
    }
    //this function will reset the game variables if the player wishes to restart the game
    void restartStatus()
    {
        StorePlayerLocation.savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
        StorePlayerLocation.restartStatus = true;
        GameObject[] allLights= GameObject.FindGameObjectsWithTag("SwitchLight");
        //Getting audio source component
        foreach (GameObject i in allLights)
        { 
            i.SetActive(false); 
        } 
        FuseboxLoad.taskComplete = false;
        KeyPadLoad.taskComplete = false;
        QuizLoad.taskComplete = false;
        PhoneDecoy.taskComplete = false;
        ArcadeLoad.taskComplete = false;
        FlashlightController.FlashlightActive = false;
        TimerCountdown.timeLeft = 1800;

    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}   
