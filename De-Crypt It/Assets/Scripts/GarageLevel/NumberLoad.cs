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
    public static bool firstNumberActive = false;

    public GameObject firstNumber;

    // Update is called once per frame
    public void Update()
    {
        if (inRange == true && UvLightController.UvLightActive == true)
        {
            turnNumberActive();
        }
        if (UvLightController.UvLightActive == false)
        {
            turnNumberNotActive();
        }
    }

    public bool turnNumberActive()
    {
        // If the task is complete then....
        firstNumber?.gameObject.SetActive(true);
        return true;
        //firstNumberActive = true;
    }

    public bool turnNumberNotActive()
    {
        // If the task is complete then....
        firstNumber?.gameObject.SetActive(false);
        //firstNumberActive = false;
        return false;
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
}