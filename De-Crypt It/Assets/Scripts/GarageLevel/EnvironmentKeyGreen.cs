using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentKeyGreen : MonoBehaviour
{
    public GameObject theIncorrectKey;
    public bool playerNextToKey = false;
    public static bool hasWrongEnvKeyClltd = false;
    public bool isRange = false;
    public Text collectKeyInstruction;

    public AudioSource collectKeySoundFX;

    //This function will be invoked when the key has been collected and play a sound effect
    public void PlayCollectKeySoundFX()
    {
        collectKeySoundFX.Play();

    }
    // Start is called before the first frame update
    void Start()
    {
        //The script will check if the key has been collected and if the key has been collected then the key's game object will be set to false
        if (hasWrongEnvKeyClltd == true)
        {
            //If the key has been collected then the game object's state will be set to false
            theIncorrectKey.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player has pressed the letter E on their keyboard and the player controller is within the range of the key
        if (Input.GetKeyDown(KeyCode.E) && playerNextToKey == true)
        {
            PlayCollectKeySoundFX();
            theIncorrectKey.SetActive(false);
            hasWrongEnvKeyClltd = true;
            collectKeyInstruction.gameObject.SetActive(false);
        }
    }

    //if the player controller leaves the collider of the key then this function will be invoked
    void OnTriggerExit(Collider other)
    {   
        //if the player controller leaves the collider of the key, hide the collect key interaction text from showing up
        if (other.CompareTag("Player"))
        {
            isRange = false;
            playerNextToKey = false;
            collectKeyInstruction.gameObject.SetActive(false);
        }
    }
    //if the player controller enters  the collider of the key then this function will be invoked
    void OnTriggerEnter(Collider other)
    {
        //if the player controller enter the collider of the key, show the collect key interaction text from showing up
        if (other.CompareTag("Player"))
        {
            //if the player controller has left the collider of the key then hide the collect key interaction text from showing up
            if (isRange == false)
            {
                //hide interaction text
                collectKeyInstruction.gameObject.SetActive(false);
            }
            playerNextToKey = true;
            //show interaction text
            collectKeyInstruction.gameObject.SetActive(true);

        }
    }
}
