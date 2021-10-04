using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberLoad : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Boolean which checks if the player is in the range of the tv object
    public bool inRange = false;

    // Static variable which is readable and modifiable by other scripts. 
    // It is used to determine if the quiz task is completed or not by the user.
    public static bool isvisible = false;

   
    public GameObject firstNumber;
    public GameObject secondNumber;
    public GameObject thirdNumber;
    public GameObject fourthNumber;
    // Update is called once per frame
    void Update()
    {
        
        if(inRange == true)
        {
            // If the task is complete then....
            firstNumber.SetActive(true);
            
        }
        if(inRange == false)
        {
            //firstNumber.SetActive(false);
        }
    }

    // This function is called when the user is close to the box collider of the gameobject in the TV
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, instructions is not shown and dont update the player within range
        if(isvisible == true)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            //firstNumber.SetActive(true);
        }
    }

    // This function is called when the user is exiting the box collider of the gameobject in the TV
    void OnTriggerExit(Collider other)
    {
        // The color of the interactable gameobject in the TV is changed to the default color,
        // the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
        if(other.CompareTag("Ligh"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            //firstNumber.SetActive(false);

            

        }
    }
}
