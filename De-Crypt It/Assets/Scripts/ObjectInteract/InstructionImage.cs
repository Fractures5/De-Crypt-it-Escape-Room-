using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionImage : MonoBehaviour
{
    public Color startcolor;
    //Boolean that check if the player is within object range
    public bool isRange = false;
    //Text variable which gives intructions to the player on how to interact with them
    public Text instructions;
    //store an image for popup
    public GameObject instructionImage;
    //if statement to check if ui is open
    public bool isOpen = false;
    public AudioSource playPickup;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRange && Input.GetKeyDown("e")) 
        {
            if(isOpen == false) 
            {
                playPickup.Play();
                instructionImage.gameObject.SetActive(true);
                instructions.gameObject.SetActive(false);
                isOpen = true;
            }
            else if(isOpen == true) 
            {
                playPickup.Play();
                instructionImage.gameObject.SetActive(false);
                instructions.gameObject.SetActive(true);
                isOpen = false;
            }

        }
    }
    void OnTriggerEnter(Collider other)
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

    void OnTriggerExit(Collider other)
    {
        //Changes the interactable object color to default and changes is range status to false
        if (other.CompareTag("Player"))
        {
            isOpen = false;
            GetComponent<Renderer>().material.color = startcolor;
            isRange = false;
            instructions.gameObject.SetActive(false);
            instructionImage.gameObject.SetActive(false);
        }
    }
}
