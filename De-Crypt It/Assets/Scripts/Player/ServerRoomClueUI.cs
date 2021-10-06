using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerRoomClueUI : MonoBehaviour
{

    public GameObject pingingCluePopup;

    // Update is called once per frame
    void Update()
    {
        if(PingingTaskLoad.taskComplete == true)
        {
            pingingCluePopup.SetActive(false);
        }
        else if(IPaddressInteraction.clueReceived == true)
        {
            pingingCluePopup.SetActive(true);
        }
        else
        {
            pingingCluePopup.SetActive(false);
        }
    }
}
