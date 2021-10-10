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
    public bool inRange = false;
    public static bool cardPickUp = false;

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            interactionText.gameObject.SetActive(false);
            cardPickUp = true;
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
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                interactionText.gameObject.SetActive(true);
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
        }
    }
}
