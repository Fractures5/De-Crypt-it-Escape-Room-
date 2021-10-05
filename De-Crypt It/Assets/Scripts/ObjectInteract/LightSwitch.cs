using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    public GameObject secretRoomLight;
    public GameObject lightSwitch;
    public GameObject clueInteractionField;
    public Color lightColor;
    public bool isRange;
    public static bool isOn = false;
    public AudioSource switchSound;
    void Start () 
    {
        secretRoomLight.SetActive(false);
    }  
    //This function checks if the player is within the range and is pressing the E button, program will switch scene
    void Update() 
    {
        if(isOn == false)
        {
            secretRoomLight.SetActive(false);
        }
        if(isOn == true)
        {
            secretRoomLight.SetActive(true);
        }
        if (isRange && Input.GetKeyDown("e")) 
        {
            if(isOn == false)
            {
                switchSound.Play();
                secretRoomLight.SetActive(true);
                clueInteractionField.SetActive(true);
                isOn = true;
            }
            else if (isOn == true)
            {
                switchSound.Play();
                secretRoomLight.SetActive(false);
                isOn = false;
            }
        }
    }
    //This function will load the the next scene if the player is within object range and is interacting
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lightColor = lightSwitch.GetComponent<Renderer>().material.color;
            lightSwitch.GetComponent<Renderer> ().material.color = Color.green;
            isRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Changes the interactable object color to default and changes is range status to false
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = lightColor;
            isRange = false;
        }
    }
}
