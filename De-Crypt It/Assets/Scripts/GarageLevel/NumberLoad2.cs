using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberLoad2 : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Boolean which checks if the player is in the range of the tv object
    public bool inRange = false;

    public GameObject secondNumber;

    // Update is called once per frame
    void Update()
    {
        
        if(inRange == true && UvLightController.UvLightActive == true)
        {
            // If the task is complete then....
            secondNumber.SetActive(true);
        }
        if(UvLightController.UvLightActive == false)
        {
            // If the task is complete then....
            secondNumber.SetActive(false);
        }

    }

    // This function is called when the user is close to the box collider of the gameobject in the TV
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, instructions is not shown and dont update the player within range
        if (other.CompareTag("Light"))
        {
            inRange = true;
            //firstNumber.SetActive(true);
        }
    }

    
    void OnTriggerExit(Collider other)
    {
        // if(other.CompareTag(""))
        // {
        //     inRange = false;
        //     //firstNumber.SetActive(false);
        // }
    }
}
