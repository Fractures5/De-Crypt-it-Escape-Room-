using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredBehaviour : MonoBehaviour
{
    //Lets the program know if user mouse is down
    bool mouseDown = false;
    //Importing the powered status script
    public PoweredStatus ps;
    //Renders a wire line that will follow the mouse movement
    LineRenderer LineVisual;
    // Start is called before the first frame update
    void Start()
    {
        //Getting all the powered status component
        ps = gameObject.GetComponent<PoweredStatus>();
        LineVisual = gameObject.GetComponent<LineRenderer>();
        //LineVisual.SetWidth(0.4f, 0.4f);
        LineVisual.startWidth = 0.4f;
        LineVisual.endWidth = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        LineVisual.SetPosition(1, new Vector3(gameObject.transform.position.x-.1f, gameObject.transform.position.y-.1f, 0));
    }

    //Function to check if mouse is down
    void OnMouseDown()
    {
        mouseDown = true;
    }
    //Check if wire is movable
    void OnMouseOver()
    {
        ps.isMovable = true;
    }
    //Function to check if mouse is on exit
    void OnMouseExit()
    {
        //Statement to match user and movable object
        if(!ps.isMoving)
        {
            ps.isMovable = false;
        }
    }
    //Function to check if mouse is up
    void OnMouseUp()
    {
        mouseDown = false;
        if(!ps.isConnected)
        {
            gameObject.transform.position = ps.startPoint; 
        }
        if(ps.isConnected)
        {
            gameObject.transform.position = ps.connectedPosition;
        }

    }
    //Function to record mouse movement and corelate with wire movement
    void MoveWire()
    {
        //Check if the mouse is down and wire is movable, then player can move wire
        if(mouseDown && ps.isMovable)
        {
            ps.isMoving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;         
            
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1));
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.parent.transform.position.z);
        }
        //If the statement is false, then player should not be able to move the wire
        else
        {
            {
                ps.isMoving = false;
            }
        }



    }
}
