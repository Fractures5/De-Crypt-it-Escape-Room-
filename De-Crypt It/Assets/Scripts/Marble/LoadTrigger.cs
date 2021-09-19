using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadTrigger : MonoBehaviour
{
    [SerializeField]

    public bool isRange = false;
    public Color startcolor;
    public Text instructions;

    public static bool taskComplete = false;

    public static bool isClosed = false;

    public GameObject ArcadeInteractable;
    public GameObject ArcadeNotInteractable;

    void Start()
    {
        
    }

    void Update()
    {
          if(taskComplete == false) 
        {
            if (isRange && Input.GetKeyDown("e")) 
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(8);
            }
        }
        
        if(taskComplete == true)
        {
            ArcadeInteractable.gameObject.SetActive(true);
            ArcadeNotInteractable.gameObject.SetActive(false);
        }
    }

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
        if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            isRange = false;
            instructions.gameObject.SetActive(false);
        }
    }
}
