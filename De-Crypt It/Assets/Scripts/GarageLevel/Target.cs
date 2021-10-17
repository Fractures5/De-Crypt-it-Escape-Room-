using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer;
    public GameObject TheKey;
    public static bool isKeyCollected;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the renderer component attached to the game object which this script is applied to
        renderer = GetComponent<Renderer>();

        //checks if the correct key has been collected
        if (isKeyCollected == true)
        {
            //if the correct key has been collected before, then the correct key will be hidden
            TheKey.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    //If the mouse has entered the correct key object
    private void OnMouseOver()
    {
        //if the mouse has entered the correct key object then the render the key inside the box with a green colour
        renderer.material.color = Color.green;
        //if the mouse has entered the correct key object and if the player has clicked down on the mouse
        if (Input.GetMouseButtonDown(0))
        {
            //set the active state of the correct key to false so that it is hidden
            TheKey.active = false;
            //set the boolean value which tracks if the key is collected to true as it has been indeed collected
            isKeyCollected = true;
        }
    }

    //If the mouse has exited the correct key object
    private void OnMouseExit()
    {
        //If the mouse has exited the correct key object then the green rendering effect will be reversed and the renderer will render the default colour of the correct key
        renderer.material.color = Color.white;
    }
}
