using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableClueInteract : MonoBehaviour
{
    public GameObject clueInteractionField;

    // Update is called once per frame
    void Update()
    {
        if (IPaddressInteraction.clueReceived == true)
        {
            clueInteractionField.SetActive(false);
        }
        else if(LightSwitch.isOn == true)
        {
            clueInteractionField.SetActive(true);
        }
        else if(LightSwitch.isOn == false)
        {
            clueInteractionField.SetActive(false);
        }
    }
}
