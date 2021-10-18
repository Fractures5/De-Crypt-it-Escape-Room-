using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardSwipe : MonoBehaviour
{
    //This script will make sure when the user is within the card swipe puzzle range, the user can interarct with the puzzle, and once the task is complete, the puzzle/asset will become un-interactable
    [SerializeField]
    public Color startcolor;

    public Text interactionText;
    public Text lockedText;
    public bool inRange = false;
    public static bool isComplete = false;

    public GameObject cardSwipeIncomplete;
    public GameObject cardSwipeComplete;

    void Update()
    {
        //The graphic for the incompplete card swipe on the card panel will be active
        cardSwipeIncomplete.SetActive(true);

        //If the task is incomplete and the card has been picked up
        if(isComplete==false && CardInteraction.cardPickUp == true)
        {
            //If the user is in range and the button e is pressed
            if (inRange == true && Input.GetKeyDown("e"))
            {
                //A new scene is loaded up showing the card swipe puzzle
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("CardSwipe");
            }
        }
        else if (isComplete == true)
        {
            //If they task is complete, the card complete graphic will be shown on the card panel instead
            cardSwipeIncomplete.SetActive(false);
            cardSwipeComplete.SetActive(true);
        } 
    }

    // This function is called when the user is close to the box collider of the card panel
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
                // Highlights the interactable card panel, changes the range status to true and activates the text instruction
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

    // This function is called when the user is exiting the box collider of the card panel
    void OnTriggerExit(Collider other)
    {
        // The color of the interactable card panel is changed to the default color,
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