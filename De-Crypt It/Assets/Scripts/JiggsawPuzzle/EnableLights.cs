using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLights : MonoBehaviour
{
    public GameObject lightSwitch1;
    public GameObject lightSwitch2;
    public GameObject lightSwitch3;
    public GameObject lightSwitch4;
    public GameObject lightSwitch5;
    public GameObject lightSwitch6;
    //This script is functioning along with the keycard swipe, it checks if the task is finished, it will turn on the lights in the server room
    void Update()
    {
        //If keycard swipe is not finished, the lights will be disabled
        if(SwipeTask.isComplete == false)
        {                
            lightSwitch1.SetActive(true); 
            lightSwitch2.SetActive(true); 
            lightSwitch3.SetActive(true); 
            lightSwitch4.SetActive(true); 
            lightSwitch5.SetActive(true); 
            lightSwitch6.SetActive(true); 

            GameObject[] allLights= GameObject.FindGameObjectsWithTag("SwitchLight");
            //Getting audio source component
            foreach (GameObject i in allLights)
            { 
                i.SetActive(false); 

            } 
        }
        //If the keycard swipe task is finished, the lights in the server room will be enabled
        else
        {
            lightSwitch1.SetActive(false);
            lightSwitch2.SetActive(false);
            lightSwitch3.SetActive(false);
            lightSwitch4.SetActive(false);
            lightSwitch5.SetActive(false);
            lightSwitch6.SetActive(false);
            GameObject[] allLights= GameObject.FindGameObjectsWithTag("SwitchLight");
            //Getting audio source component
            foreach (GameObject i in allLights)
            { 
                i.SetActive(true); 
            } 
        }
        
    }
}
