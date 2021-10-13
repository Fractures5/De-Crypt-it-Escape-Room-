using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryInteraction : MonoBehaviour
{
    //private Renderer renderer;
    public GameObject Battery;
    public static bool isBatteryCollected = false;
    
    private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Battery.active = false;
            isBatteryCollected = true;
            //if key colleceted then user can press G for using the light.
            //add text to allow the user to know
        }
        
    }
}

