using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
public class UnpoweredBehaviour : MonoBehaviour
{
    //Importing unpowered status script
    UnpoweredStatus ups;
    //Int variable to keep track of how many wires are connected (max 4)
    static int totalConnection = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Calling the component of the script
        ups = gameObject.GetComponent<UnpoweredStatus>();
        //Resetting the total connection to 0 incase the player exits the task, this is necessary as the int is static
        totalConnection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(totalConnection == 4) 
        {
            Debug.Log("All Wires are connected!");
            //Changing the task complete boolean in fuseboxload to tell the program that the task is completed by the user
            FuseboxLoad.taskComplete = true;
        }
        LightStatus();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PoweredStatus>())
        {
            PoweredStatus ps = collision.GetComponent<PoweredStatus>();
            if(ps.objectColor==ups.objectColor)
            {
                totalConnection++;
                Debug.Log(totalConnection);
                ps.isConnected = true;
                ups.isConnected = true;
                //Wire will snap to end point if connected
                ps.connectedPosition = gameObject.transform.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PoweredStatus>())
        {
            //totalConnection--;
            //Debug.Log(totalConnection);
            PoweredStatus ps = collision.GetComponent<PoweredStatus>();
            ps.isConnected = false;
            ups.isConnected = false;
        }
    }
    //This function checks if the wires are connected and correct displayed is shown
    void LightStatus()
    {
        //If statement to check if wires are connected
        if(ups.isConnected)
        {
            //If wires are connected, change the model to let the player know its connected
            ups.poweredLight.SetActive(true);
            ups.unpoweredLight.SetActive(false);
        }
        else
        {
            ups.poweredLight.SetActive(false);
            ups.unpoweredLight.SetActive(true);
        }
    }
}
