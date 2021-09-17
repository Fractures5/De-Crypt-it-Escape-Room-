using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddConstantVelocity : MonoBehaviour
{   
    //Will save the values of the momentum and velocity of the ball player
    [SerializeField]// allows to change in the editor.
    Vector3 v3Force;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity += new Vector3(0.001f, 0, 0);
    }
}
