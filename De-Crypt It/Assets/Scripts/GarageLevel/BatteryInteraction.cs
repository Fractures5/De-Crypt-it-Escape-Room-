using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryInteraction : MonoBehaviour
{
    //private Renderer renderer;
    public GameObject Battery;
    public static bool isBatteryCollected = false;
    public Text batteryInteraction;
    public bool isRange = false;

    public bool battery;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && battery == true)
        {
            Battery.active = false;
            isBatteryCollected = true;
            batteryInteraction.gameObject.SetActive(false);
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

