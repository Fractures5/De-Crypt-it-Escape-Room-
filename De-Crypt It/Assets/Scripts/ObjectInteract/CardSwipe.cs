using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardSwipe : MonoBehaviour
{
    [SerializeField]
    public Color startcolor;

    public Text interactionText;
    public Text lockedText;
    public bool inRange = false;
    public static bool isComplete = false;

    void Update()
    {
        if(isComplete==false && CardInteraction.cardPickUp == true)
        {
            if (inRange == true && Input.GetKeyDown("e"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("CardSwipe");
            }
            /*else
            {
                cardSwipeUI.SetActive(false);
                //could add here to show a clue
            }*/
        }  
    }

    // This function is called when the user is close to the box collider of the gameobject in the TV
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, instructions is not shown and dont update the player within range
        if(isComplete == true)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);
        }
        // If the task in not complete, object is highlighted, instructions text is show and the player within the range is updated
        else if (CardInteraction.cardPickUp == false)
        {
            if (other.CompareTag("Player"))
            {
                // Highlights the interactable TV game object, changes the range status to true and activates the text instruction
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                lockedText.gameObject.SetActive(true);
            }
        }
        else if (CardInteraction.cardPickUp == true)
        {
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                interactionText.gameObject.SetActive(true);
        }
    }

    // This function is called when the user is exiting the box collider of the gameobject in the TV
    void OnTriggerExit(Collider other)
    {
        // The color of the interactable gameobject in the TV is changed to the default color,
        // the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
        if (other.CompareTag("Player") && CardInteraction.cardPickUp == true)
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);
        }
        else if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            lockedText.gameObject.SetActive(false);
        }
    }
}
