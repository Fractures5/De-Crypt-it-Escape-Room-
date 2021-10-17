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

    // Boolean which checks if the player is in the range of the first hidden number
    public bool inRange = false;
    //Boolean which checks if the hidden number is active or not.
    public static bool firstNumberActive = false;

    public GameObject firstNumber;

    // Update is called once per frame to check state of the hidden number
    public void Update(){

        if(inRange == true && UvLightController.UvLightActive == true){

            turnNumberActive();
        }
        if(UvLightController.UvLightActive == false){
            
            turnNumberNotActive();
        }

    }

    //This method has the task of turning the hidden number to active to allow the player to view the hidden number while the UV light is on.
    public bool turnNumberActive(){

        firstNumber?.gameObject.SetActive(true);
        return true;

    }

    //This method has the task of turning the hidden number to not active to not allow the player to view the hidden number.
    public bool turnNumberNotActive(){

        firstNumber?.gameObject.SetActive(false);
        return false;

    }

    // This function is called when the user is close to the box collider of the gameobject in the room
    void OnTriggerEnter(Collider other){
        
        // if the tag of the object is light then the range is set to true allowing the player to interact with it.
        if (other.CompareTag("Light")){

            inRange = true;
        }
    }
}