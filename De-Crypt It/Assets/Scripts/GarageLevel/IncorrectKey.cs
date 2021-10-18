using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectKey : MonoBehaviour
{

    private Renderer renderer;
    public GameObject Key;
    public static bool isWrongKeyCollected;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If the mouse pointer has entered the game object range
    private void OnMouseOver()
    {
        renderer.material.color = Color.green;
        //if the player has pressed down on left click while the pointer is in the game object range
        if (Input.GetMouseButtonDown(0))
        {
            Key.active = false;
            isWrongKeyCollected = true;
        }

    }
    //If the mouse pointer has exited the game object range
    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
