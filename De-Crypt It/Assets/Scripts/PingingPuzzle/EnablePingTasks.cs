using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePingTasks : MonoBehaviour
{
    public GameObject glitchedPCscreens;
    public GameObject workingPCscreens;

    // Update is called once per frame
    void Update()
    {

        if(SwipeTask.isComplete == true)
        {
            glitchedPCscreens.SetActive(false);
            workingPCscreens.SetActive(true);
        }
        
    }
}
