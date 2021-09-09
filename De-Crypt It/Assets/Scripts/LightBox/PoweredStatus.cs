using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum color that corelates with the wire color
public enum KnownColor
{  
    Blue,  
    Red,
    Green,
    Yellow  
}  
public class PoweredStatus : MonoBehaviour
{
    //Status to check if wire is movable
    public bool isMovable = false;
    //Status to check if wire is moving
    public bool isMoving = false;
    //This variable allows to check where the user is connecting the wire
    public Vector3 startPoint;
    //This variable keeps track of the color of the wires
    public KnownColor objectColor;
    //Boolean to check wire status
    public bool isConnected = false;
    //Check coordinate of end socket so wire can connect
    public Vector3 connectedPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
