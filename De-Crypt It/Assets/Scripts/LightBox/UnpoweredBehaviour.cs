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
    //Sound effect of wires being connected
    public AudioSource playSound;
    public AudioClip ConnectedWire;
    public AudioClip DisconectedWire;
    public AudioClip TaskCompleted;
    //Check to see if task is completed
    public bool hasPlayedCompleted = false;
    //Show a text when task is completed
    public GameObject CompletedText;
    // Start is called before the first frame update
    void Start()
    {
        //Calling the connected wire sound
        playSound = GetComponent<AudioSource>();
        //Calling the component of the script
        ups = gameObject.GetComponent<UnpoweredStatus>();
        //Resetting the total connection to 0 incase the player exits the task, this is necessary as the int is static
        totalConnection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if all the wires are connected which plays a sound and sets the completed to true
        if(totalConnection == 4) 
        {
            if(!hasPlayedCompleted)
            {
                playSound.PlayOneShot(TaskCompleted, 0.2f);
                hasPlayedCompleted = true;
            }
            CompletedText.SetActive(true);
            //Changing the task complete boolean in fuseboxload to tell the program that the task is completed by the user
            FuseboxLoad.taskComplete = true;
        }
        else 
        {
            CompletedText.SetActive(false);
            hasPlayedCompleted = false;
            FuseboxLoad.taskComplete = false;
        }
        LightStatus();
    }
    //A function to check if the player is matching the wire
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PoweredStatus>())
        {
            PoweredStatus ps = collision.GetComponent<PoweredStatus>();
            if(ps.objectColor==ups.objectColor)
            {
                //If the player matches the wire, total connection will be incremented
                playSound.PlayOneShot(ConnectedWire);
                totalConnection++;
                ps.isConnected = true;
                ups.isConnected = true;
                //Wire will snap to end point if connected
                ps.connectedPosition = gameObject.transform.position;
            }
        }
    }

    //A function to check if the player is not matching the wire
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PoweredStatus>())
        {
            PoweredStatus ps = collision.GetComponent<PoweredStatus>();
            if(ps.objectColor==ups.objectColor)
            {
                //If the player unmatches the wire, total connection will be decreased
                totalConnection--;
            }
            playSound.PlayOneShot(DisconectedWire);
            ps.isConnected = false;
            ups.isConnected = false;
        }
    }
    //This function checks if the wires are connected and correct displayed is shown
    void LightStatus()
    {
        //If statement to check if wires are connected and appropriate light power will be displayed. A yellow light power indicates its connected
        //where as a black light power indicates its not powered
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
