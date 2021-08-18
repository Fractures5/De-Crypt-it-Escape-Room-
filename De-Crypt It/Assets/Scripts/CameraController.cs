using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Horizontal and Vertical Sensitivity
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    //Reference to Camera object
    Camera cam;

    //Horizontal and Vertical mouse input
    float mouseX;
    float mouseY;

    //X and Y rotation angle
    float xRotation;
    float yRotation;

    //Multiplier will be used to determine the speed and the sensitivity of camera movement
    float multiplier = 0.01f;

    private void Start()
    {
        //Get Camera object
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MyInput();

        //Setting the camera rotation
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //Setting the player rotation
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    //This function checks for the camera x and y input and rotates the camera based on the player input
    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        //Camera rotation will move based on the mouseinput
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        //Limiting the camera rotation so the player wouldn't look 360
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

}
