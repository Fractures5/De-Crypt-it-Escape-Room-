using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhoneDecoy : MonoBehaviour
{
    public Color startcolor;
    //Boolean that check if the player is within object range
    public bool isRange = false;
    //Text variable which gives intructions to the player on how to interact with them
    public Text instructions;
    //A static variable that is readable and modifiable by other scripts. This can be used to determine whether a task is complated by the user
    public static bool taskComplete = false;
    //Variable to store close sound effect
    public AudioSource phoneSound;
    //boolean to check if fusebox is closed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(taskComplete == false) 
        { 
            //When the player is in range and Presses E, since its a decoy, it will only play a sound
            //This object will also be interactable once per game
            if (isRange && Input.GetKeyDown("e")) 
            {
                phoneSound.Play();
                taskComplete = true;
            }
        }
    }
    //Check if the player is within the object range
    void OnTriggerEnter(Collider other)
    {
        //If the task is already completed, dont highlight the object, dont show instruction and dont update the player within range
        if(taskComplete == true) 
        {
            
            //keyPad.GetComponent<KeyPadLoad>().enabled = true;
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            isRange = false;
            instructions.gameObject.SetActive(false);
        }
        //Vice versa if the task is not yet completed
        else 
        {
            if(other.CompareTag("Player"))
            {
                //Highlights the interactable object and changes the is range status to true
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                isRange = true;
                instructions.gameObject.SetActive(true);
            }
        }


    }
    //Check if the player is outside the collider range
    void OnTriggerExit(Collider other)
    {
        //Changes the interactable object color to default and changes is range status to false
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            isRange = false;
            instructions.gameObject.SetActive(false);
        }
    }
}
