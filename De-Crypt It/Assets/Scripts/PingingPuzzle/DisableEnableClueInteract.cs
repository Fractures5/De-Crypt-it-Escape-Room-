using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will determine when do disable and enable the clue interaction field.
public class DisableEnableClueInteract : MonoBehaviour
{
    // Game object of the clue interaction field which has the collider
    // and the clue interaction script for the server room.
    public GameObject clueInteractionField;

    // Update is called once per frame
    // These statements in the update statement will constantly make sure
    // whenever the user switches scenes the clue interaction field works as intended.
    void Update()
    {
        // When has received the clue already, the clue interaction field is disabled.
        if (IPaddressInteraction.clueReceived == true)
        {
            clueInteractionField.SetActive(false);
        }
        else if(LightSwitch.isOn == true) // When the hidden server room light is on, the clue interaction field is enabled.
        {
            clueInteractionField.SetActive(true);
        }
        else if(LightSwitch.isOn == false) // When the hidden server room light is off, the clue interaction field is disabled
        {
            clueInteractionField.SetActive(false);
        }
    }
}
