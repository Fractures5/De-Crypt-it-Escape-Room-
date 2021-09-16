using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePlayerLocation : MonoBehaviour
{
    //Keep track of player location
    public GameObject playerPos;
    //Variable to store player position
    public static Vector3 savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
    // Start is called before the first frame update
    void Start()
    {
        //Set player Position based on their previous position
        playerPos.transform.position = savedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Stores player position based on player location every frame
        savedPosition = playerPos.transform.position;
    }
}
