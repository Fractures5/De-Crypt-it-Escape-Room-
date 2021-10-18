using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardInteraction : MonoBehaviour
{
    [SerializeField]
    public Color startcolor;
    public Text interactionText;
    public Text cardInstructions;
    public bool inRange = false;
    public GameObject card;
    public static bool cardPickUp = false;

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            interactionText.gameObject.SetActive(false);
            cardInstructions.gameObject.SetActive(true);
            cardPickUp = true;
            card.gameObject.SetActive(false);
        }

        if (SwipeTask.isComplete == true)
        {
            card.gameObject.SetActive(false);
            cardInstructions.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
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
