using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will handle when the pinging pop up clue should be shown.
public class ServerRoomClueUI : MonoBehaviour
{
    // This pinging clue pop up game object.
    public GameObject pingingCluePopup;

    // Update is called once per frame
    void Update()
    {
        if(PingingTaskLoad.taskComplete == true) // When the pinging task is complete the clue UI is not shown in the medium game.
        {
            pingingCluePopup.SetActive(false);
        }
        else if(IPaddressInteraction.clueReceived == true) // When the clue is received, leave the clue UI to be shown.
        {
            pingingCluePopup.SetActive(true);
        }
        else // If no conditions are meeant leave the clue UI hidden.
        {
            pingingCluePopup.SetActive(false);  
        }
    }
}
