using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerRoomKeypad : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Text variable that shows that the keypad is currently locked.
    public Text lockedText;

    // Text variable that shows that the keypad is currently unlocked and to press "E" to activate door.
    public Text unlockedText;

    // Boolean which checks if the player is in the range of the locked door.
    public bool inRange = false;

    // Static variable which is readable and modifiable by other scripts. 
    // It is used to determine if the quiz task is completed or not by the user.
    public static bool taskComplete = false;

    public static bool keypadActive = false;

    public AudioSource activationFX;

    public GameObject lockedDoor;
    public GameObject unlockedDoor;
    public GameObject activatedKeypadScreen;
    public GameObject unlockedKeypadScreen;

    // Update is called once per frame
    void Update()
    {
        if (keypadActive == true)
        {
            if(inRange == true && Input.GetKeyDown("e"))
            {
                Debug.Log("You have activated the keypad - door is now unlocked");

                unlockedKeypadScreen.SetActive(false);
                activatedKeypadScreen.SetActive(true);
                lockedDoor.SetActive(false);

                unlockedDoor.SetActive(true);
                unlockedText.gameObject.SetActive(false);

                activationFX.Play(0);
                ServerRoomKeypad.taskComplete = true;
            }
        }
    }

    // This function is called when the user is close to the box collider of the keypad
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, instructions is not shown and dont update the player within range
        if(taskComplete == true)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            lockedText.gameObject.SetActive(false);
            unlockedText.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Player") && keypadActive == false)
        {
            // Highlights the uninteractable keypad, changes the range status to true and activates the text instruction
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
            inRange = true;
            lockedText.gameObject.SetActive(true);
        }
        else if (other.CompareTag("Player") && keypadActive == true)
        {
            // Highlights the interactable keypad, changes the range status to true and activates the text instruction to interact with keypad
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
            inRange = true;
            unlockedText.gameObject.SetActive(true);
        }

        
    }

    // This function is called when the user is exiting the box collider of the door
    void OnTriggerExit(Collider other)
    {
        // The color of the door is changed to the default color,
        // the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
        if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            lockedText.gameObject.SetActive(false);
        }
        else if(other.CompareTag("Player") && keypadActive == true)
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            unlockedText.gameObject.SetActive(false);
        }
    }
}
