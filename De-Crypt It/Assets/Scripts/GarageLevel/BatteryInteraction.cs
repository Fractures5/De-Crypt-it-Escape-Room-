using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryInteraction : MonoBehaviour
{       
    public GameObject Battery;
    public GameObject glass;
    public static bool isBatteryCollected = false;
    public Text batteryInteraction; 
    public Text uvLightTogglePrompt;

    //Boolean which checks if the user is inrage of the battery
    public bool isRange = false;
    public bool hasUVLightEnumeratorRan = false;
    public bool battery;

    //for this method it will update the state of battery collected and whether the player can interact with the battery or not.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && battery == true){
            isBatteryCollected = true;
            batteryInteraction.gameObject.SetActive(false);
            StartCoroutine(showUVLightToggle());
            //Battery.SetActive(false);
        }

        if (hasUVLightEnumeratorRan == true){
            gameObject.SetActive(false);
            Battery.SetActive(false);
        }
    }
    
    //For this method we have a on trigger function to allow the user to view the object and have interaction with it, by depending on the collider of another object(the battery in this case)
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player")){
            if (isRange == false){
            
                batteryInteraction.gameObject.SetActive(false);
            
            }

            battery = true;
            batteryInteraction.gameObject.SetActive(true);
        }
    }

    //For this method we will be able to check if the tag for the collider is set to be player and if so then it will not be in range and also the battery will not be visible anymore.
    void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            isRange = false;
            battery = false;
            batteryInteraction.gameObject.SetActive(false);
        }

    }
    //for this methot we have a Ienumarator that will allow the player to turn the UV light on and off on the right time
    IEnumerator showUVLightToggle()
    {
        GetComponent<Renderer>().enabled = false;
        glass.SetActive(false);

        //GetComponentInChildren<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        uvLightTogglePrompt.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        uvLightTogglePrompt.gameObject.SetActive(false);
        hasUVLightEnumeratorRan = true;
    }
}

