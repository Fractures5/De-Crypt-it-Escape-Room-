using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoweredStatus : MonoBehaviour
{
    //Boolean to check if wire is connected
    public bool isConnected = false;
    //Color to check multiple status of wires
    public KnownColor objectColor;
    //Gameobject of poweredlight, useful for switching models to differentiate connected and not connected
    public GameObject poweredLight;
    //Gameobject of unpoweredlight,useful for switching models to differentiate connected and not connected
    public GameObject unpoweredLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
