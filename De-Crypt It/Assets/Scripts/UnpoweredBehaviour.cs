using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoweredBehaviour : MonoBehaviour
{
    //Importing unpowered status script
    UnpoweredStatus ups;
    // Start is called before the first frame update
    void Start()
    {
        //Calling the component of the script
        ups = gameObject.GetComponent<UnpoweredStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        LightStatus();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PoweredStatus>())
        {
            PoweredStatus ps = collision.GetComponent<PoweredStatus>();
            if(ps.objectColor==ups.objectColor)
            {
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
