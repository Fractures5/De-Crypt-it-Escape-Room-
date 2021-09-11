using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInteraction : MonoBehaviour
{
    [SerializeField]
    private Image parchment;
    public Color startcolor;
    public bool isRange = false;
    public Text interactionText;
    public GameObject firstPersonController;
    public GameObject firstPersonCamera;
    public GameObject exitButton;
    public GameObject crosshair;

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

        if (isRange == true && Input.GetKeyDown("e"))
        {
            interactionText.gameObject.SetActive(false);
            
            firstPersonController.GetComponent<Jump>().enabled=false;
            firstPersonController.GetComponent<FirstPersonMovement>().enabled=false;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=false;
            firstPersonCamera.GetComponent<Zoom>().enabled=false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            parchment.enabled = true;
            exitButton.SetActive(true);
            crosshair.SetActive(false);
        }
    }

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
