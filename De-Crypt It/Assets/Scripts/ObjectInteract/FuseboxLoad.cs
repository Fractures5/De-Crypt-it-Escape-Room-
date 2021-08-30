using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FuseboxLoad : MonoBehaviour
{
    //Keeps track of the object color
    [SerializeField]
    public Color startcolor;
    //Boolean that check if the player is within object range
    public bool isRange = false;
    public Text instructions;

    //This function checks if the player is within the range and is pressing the E button, program will switch scene
    void Update() 
    {
        if (isRange && Input.GetKeyDown("e")) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
    //This function will load the the next scene if the player is within object range and is interacting
    void OnTriggerEnter(Collider other)
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
