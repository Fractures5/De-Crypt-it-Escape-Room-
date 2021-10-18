using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyPadLoad : MonoBehaviour
{

    //Keeps track of the object color
    [SerializeField]
    public Color startcolor;
    //Boolean that check if the player is within object range
    public bool isRange = false;
    //Text variable which gives intructions to the player on how to interact with them
    public Text instructions;

    public static bool taskComplete = false;

    public static bool isClosed = false;

    public GameObject doorInteractable;
    public GameObject doorNotInteractable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(taskComplete == false) 
        {
            if (isRange && Input.GetKeyDown("e")) 
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(6);
            }
        }
        
        if(taskComplete == true)
        {
            doorInteractable.gameObject.SetActive(true);
            doorNotInteractable.gameObject.SetActive(false);
        }
    }

    //This function will load the the next scene if the player is within object range and is interacting
    void OnTriggerEnter(Collider other)
    {
        if(FuseboxLoad.taskComplete == false)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
        }
        else if(FuseboxLoad.taskComplete == true)
        {
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
        //If the task is already completed, dont highlight the object, dont show instruction and dont update the player within range


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