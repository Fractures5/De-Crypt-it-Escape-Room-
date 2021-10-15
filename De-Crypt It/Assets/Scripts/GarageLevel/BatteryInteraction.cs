using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryInteraction : MonoBehaviour
{
    //private Renderer renderer;
    
    public GameObject Battery;
    public GameObject glass;
    public static bool isBatteryCollected = false;
    public Text batteryInteraction;
    public Text uvLightTogglePrompt;
    public bool isRange = false;

    public bool hasUVLightEnumeratorRan = false;
    public bool battery;

    void Start()
    {
        if (isBatteryCollected == true)
        {
            Battery.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && battery == true)
        {
            isBatteryCollected = true;
            batteryInteraction.gameObject.SetActive(false);
            StartCoroutine(showUVLightToggle());
            //Battery.SetActive(false);
        }

        if (hasUVLightEnumeratorRan == true)
        {
            gameObject.SetActive(false);
            Battery.SetActive(false);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRange == false)
            {
                batteryInteraction.gameObject.SetActive(false);
            }
            battery = true;
            batteryInteraction.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRange = false;
            battery = false;
            batteryInteraction.gameObject.SetActive(false);
        }

    }

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
    /*private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Battery.active = false;
            isBatteryCollected = true;
            //if key colleceted then user can press G for using the light.
            //add text to allow the user to know
        }
        
    }*/
}

