using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberLoad4 : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Boolean which checks if the player is in the range of the first hidden number
    public bool inRange = false;

    public GameObject fourthNumber;

    // Update is called once per frame to check state of the hidden number
    void Update(){
        
        if(inRange == true && UvLightController.UvLightActive == true){

            fourthNumber.SetActive(true);
        
        }
        if(UvLightController.UvLightActive == false){

            fourthNumber.SetActive(false);
        
        }

    }

    // This function is called when the user is close to the box collider of the gameobject in the room
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, instructions is not shown and dont update the player within range
        if (other.CompareTag("Light")){

            inRange = true;
 
        }
    }
}