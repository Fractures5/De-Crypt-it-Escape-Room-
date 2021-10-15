using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to monitor the times the working PC screens should be shown.
public class EnablePingTasks : MonoBehaviour
{
    // Game object for the pc screen savers in the server room.
    public GameObject glitchedPCscreens;
    public GameObject workingPCscreens;

    // Update is called once per frame
    void Update()
    {
        // Constantly checks in the update method if the swipe task is complete,
        // as when it is, the glitched pc screen objects are disabled and the
        // working pc screns are now active and interactable.
        if(SwipeTask.isComplete == true)
        {
            glitchedPCscreens.SetActive(false);
            workingPCscreens.SetActive(true);
        }
        
    }
}
