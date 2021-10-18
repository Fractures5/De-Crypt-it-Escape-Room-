using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberLoad3 : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Boolean which checks if the player is in the range of the first hidden number
    public bool inRange = false;

    public GameObject thirdNumber;

    // Update is called once per frame to check state of the hidden number
    void Update()
    {
        
        if(inRange == true && UvLightController.UvLightActive == true){
            
            thirdNumber.SetActive(true);
        
        }
        if(UvLightController.UvLightActive == false){
            
            thirdNumber.SetActive(false);

        }

    }

    // This function is called when the user is close to the box collider of the gameobject in the room
    void OnTriggerEnter(Collider other){

        if (other.CompareTag("Light")){

            inRange = true;
            
        }
    }
}