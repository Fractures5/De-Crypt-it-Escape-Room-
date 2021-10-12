using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class JigsawPuzzle : MonoBehaviour
{
    //Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    //Boolean that check if the player is within object range
    public bool isRange = false;
    //Text variable which gives intructions to the player on how to interact with them
    public Text instructions;
    //A static variable that is readable and modifiable by other scripts. This can be used to determine whether a task is complated by the user
    public static bool taskComplete = false;
    //Variable to store close sound effect

    //As the jigsawpuzzle is the main task to be completed before doing other tasks, some puzzles will be disabled to indicate that power is needed to accomplish them
    public GameObject portal;
    public GameObject portalwCollider;
    public GameObject PuzzleGraphicNotComplete;
    public GameObject PuzzleGraphicComplete;
    void Start () 
    {

    }  
    //This function checks if the player is within the range and is pressing the E button, program will switch scene
    void Update() 
    {
        //Removes the portal blockage in the secret room if task is finished
        if(taskComplete == true) 
        {
            portal.SetActive(true);
            portalwCollider.SetActive(false);
            PuzzleGraphicNotComplete.SetActive(false);
            PuzzleGraphicComplete.SetActive(true);
        }
        //If the task is not completed, allow user to interact with the object
        if(taskComplete == false) 
        { 
            if (isRange && Input.GetKeyDown("e")) 
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("JiggsawPuzzle");
            }
        }

    }
    //This function will load the the next scene if the player is within object range and is interacting
    void OnTriggerEnter(Collider other)
    {
        //If the task is already completed, dont highlight the object, dont show instruction and dont update the player within range
        if(taskComplete == true) 
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;

            isRange = false;
            instructions.gameObject.SetActive(false);
        }
        //Vice versa if the task is not yet completed
        else 
        {
            if(other.CompareTag("Player"))
            {
                //Highlights the interactable object and changes the is range status to true
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                isRange = true;
                instructions.gameObject.SetActive(true);
            }
        }


    }

    void OnTriggerExit(Collider other)
    {
        //Changes the interactable object color to default and changes is range status to false
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            isRange = false;
            instructions.gameObject.SetActive(false);
        }
    }
}
