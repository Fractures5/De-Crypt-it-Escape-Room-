using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardInteraction : MonoBehaviour
{
    //This script is used for the interaction and pick of the card interactable
    [SerializeField]
    public Color startcolor;
    public Text interactionText;
    public Text cardInstructions;
    public bool inRange = false;
    public GameObject card;
    public static bool cardPickUp = false;

    void Update()
    {
        //If the user is in range and presses e, the card will be picked up, instructions will be shown to the user of what to do with it
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            interactionText.gameObject.SetActive(false);
            cardInstructions.gameObject.SetActive(true);
            cardPickUp = true;
            card.gameObject.SetActive(false);
        }

        //Once the card swipe puzzle is complete, the card and its interactable will be set to false
        if (SwipeTask.isComplete == true)
        {
            card.gameObject.SetActive(false);
            cardInstructions.gameObject.SetActive(false);
        }
    }

    // This function is called when the user is close to the box collider of the card panel
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, instructions is not shown and dont update the player within range
        if(cardPickUp == true)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);
            cardInstructions.gameObject.SetActive(true);
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                interactionText.gameObject.SetActive(true);
                cardInstructions.gameObject.SetActive(false);
            }
        }
    }

    // This function is called when the user is exiting the box collider of the card panel
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);
            cardInstructions.gameObject.SetActive(false);
        }
    }
}