using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardPickUp : MonoBehaviour
{
    public Transform equipPosition;
    public float distance = 10f;
    GameObject currentCard;
    GameObject wp;
    public static bool cardCollected = false;
    public GameObject cardText;

    bool canGrab;

    void Update()
    {
        CheckCard();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentCard != null)
                {
                    Drop();
                }
                else
                {
                    cardCollected = true;
                    PickUp();
                    cardText.SetActive(true);
                }
            }
        }
        
        if (currentCard != null)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        }
    }

    private void CheckCard()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        else
        {
            canGrab = false;
        }
    }

    private void PickUp()
    {
        currentCard = wp;
        currentCard.transform.position = equipPosition.position;
        currentCard.transform.parent = equipPosition;
        currentCard.transform.localEulerAngles = new Vector3(0f, 100f, 0f);
        currentCard.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Drop()
    {
        currentCard.transform.parent = null;
        currentCard.GetComponent<Rigidbody>().isKinematic = false;
        currentCard = null;
    }
}
