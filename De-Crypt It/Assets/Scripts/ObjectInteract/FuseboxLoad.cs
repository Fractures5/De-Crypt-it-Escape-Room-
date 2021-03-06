using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FuseboxLoad : MonoBehaviour
{
    //Keeps track of the object color
    [SerializeField]
    public Color startcolor;
    public Color fuseBoxFrontColor;

    //Boolean that check if the player is within object range
    public bool isRange = false;
    //Text variable which gives intructions to the player on how to interact with them
    public Text instructions;
    //A static variable that is readable and modifiable by other scripts. This can be used to determine whether a task is complated by the user
    public static bool taskComplete = false;
    //Variable to store close sound effect
    public AudioSource closeSound;
    //boolean to check if fusebox is closed
    public static bool isClosed = false;

    //As the fusebox is the main task to be completed before doing other tasks, some puzzles will be disabled to indicate that power is needed to accomplish them
    public GameObject fuseBoxFront;

    public GameObject tvPuzzleMenu;

    public GameObject keyPad;

    public GameObject marbleScreen;



    void Start () 
    {
        //If fusebox is exited close sound effect is played
        if (isClosed == true) 
        {
            closeSound.Play();
        }
        //Resets this variable
        isClosed = false;
        //This disables all the light switches at the start and user will need to complete this task to enable light switches
        GameObject[] allLights= GameObject.FindGameObjectsWithTag("SwitchLight");
        //Getting audio source component
        foreach (GameObject i in allLights)
        { 
            i.SetActive(false); 
        } 
        Debug.Log("lights off by default");
        
        //Turns on all the light switches if the task is completed
        if(taskComplete == true) 
        {
            foreach (GameObject i in allLights)
            { 
                i.SetActive(true); 
            } 
            //It will also set the other puzzle as active when this task this completed
            tvPuzzleMenu.SetActive(true);
            marbleScreen.SetActive(true);
            
        }
    }  
    //This function checks if the player is within the range and is pressing the E button, program will switch scene
    void Update() 
    {
        //If the task is not completed, allow user to interact with the object
        if(taskComplete == false) 
        { 
            keyPad.GetComponent<KeyPadLoad>().enabled = false;
            if (isRange && Input.GetKeyDown("e")) 
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(4);
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

            fuseBoxFrontColor = GetComponent<Renderer>().material.color;
            fuseBoxFront.GetComponent<Renderer> ().material.color = fuseBoxFrontColor;

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

                fuseBoxFrontColor = fuseBoxFront.GetComponent<Renderer>().material.color;
                fuseBoxFront.GetComponent<Renderer> ().material.color = Color.green;

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
            
            fuseBoxFront.GetComponent<Renderer> ().material.color = fuseBoxFrontColor;
            isRange = false;
            instructions.gameObject.SetActive(false);
        }
    }
}
