using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerControlledVelocity : MonoBehaviour
{
    //allows to change in the editor.
    [SerializeField]
    Vector3 v3Force;
    [SerializeField]
    KeyCode keyPositive;
    [SerializeField]
    KeyCode keyNegative;

    //Save the values so we can assign the keys so that the player can move the ball player.
    void FixedUpdate()
    {
        if(Input.GetKey(keyPositive))
            GetComponent<Rigidbody>().velocity += v3Force;
    
        if(Input.GetKey(keyNegative))
            GetComponent<Rigidbody>().velocity -=  v3Force;  
    }
}
