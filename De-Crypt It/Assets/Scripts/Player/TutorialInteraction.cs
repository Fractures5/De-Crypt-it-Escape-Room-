using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInteraction : MonoBehaviour
{
    //This script will handle the interaction with the desk in the tutorial mode
    [SerializeField]
    private Image parchment;
    public Color startcolor;
    public bool isRange = false;
    public Text interactionText;
    public GameObject firstPersonController;
    public GameObject firstPersonCamera;
    public GameObject exitButton;
    public GameObject crosshair;

    //When player enters the collision range for the paper, then they are able to interact with the paper
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
            interactionText.gameObject.SetActive(true);
            isRange = true;
        }
    }
    //If the player leaves the collision range of the paper, the paper display will then be closed
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
           interactionText.gameObject.SetActive(false);
           isRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range and presses E, then their player controls are disabled and they are shown the parchment with the instructions
        if (isRange == true && Input.GetKeyDown("e"))
        {
            interactionText.gameObject.SetActive(false);
            
            firstPersonController.GetComponent<Jump>().enabled=false;
            firstPersonController.GetComponent<FirstPersonMovement>().enabled=false;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=false;
            firstPersonCamera.GetComponent<Zoom>().enabled=false;
            //They are able to use the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            parchment.enabled = true;
            exitButton.SetActive(true);
            crosshair.SetActive(false);
        }
    }
    //Hides the parchment and enables player controls
    public void hideParchment()
    {
        firstPersonController.GetComponent<Jump>().enabled=true;
        firstPersonController.GetComponent<FirstPersonMovement>().enabled=true;
        firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
        firstPersonCamera.GetComponent<Zoom>().enabled=true;
        
        Cursor.visible = false;
        parchment.enabled = false;
        exitButton.SetActive(false);
        crosshair.SetActive(true);
    }
}
