using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles interaction with the keypad which activates the door and manages the controls for the door and the keypad.
public class ServerRoomKeypad : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Text variable which pops up allowing the user to interact with the locked keypad.
    public Text lockedTextInteraction;

    // Text variable which tells the user the keypad is locked.
    public Text lockedKeypadMsg;

    // Text variable that shows that the keypad is currently unlocked and to press "E" to activate door.
    public Text unlockedText;

    // Boolean which checks if the player is in the range of the keypad.
    public bool inRange = false;

    // AudioSource variable for the locked keypad sound effect.
    public AudioSource keypadLockedFX;

    // Static variable which is readable and modifiable by other scripts. 
    // It is used to determine if the keypad tasks is completed or not by the user.
    public static bool taskComplete = false;
    public static bool keypadActive = false;

    // Boolean which will be used to play sound effect for the complete activation once.
    public bool playFXonce = false;
    // Audiosource variable for the activation sound effect.
    public AudioSource activationFX;

    // Gameobject variables for the doors and keypads.
    public GameObject lockedDoor;
    public GameObject unlockedDoor;
    public GameObject activatedKeypadScreen;
    public GameObject unlockedKeypadScreen;

    // Update is called once per frame
    void Update()
    {
        // When the keypad is activated
        if (keypadActive == true)
        {
            // If the user is in range of keypad and presses "E" then they are shown the activated keypad message and the door is unlocked.
            if(inRange == true && Input.GetKeyDown("e"))
            {
                Debug.Log("You have activated the keypad - door is now unlocked");

                unlockedKeypadScreen.SetActive(false); // hides unlocked keypad screen.
                activatedKeypadScreen.SetActive(true); // shows activated keypad message.
                
                lockedDoor.SetActive(false); // hides the lock door.
                unlockedDoor.SetActive(true); // enable the unlocked interactable door.

                unlockedText.gameObject.SetActive(false); // hide the unlocked text instruction.

                // Will only play the sound effects for the activation once.
                if (playFXonce == false)
                {
                    activationFX.Play(0);
                    playFXonce = true;
                }

                ServerRoomKeypad.taskComplete = true; // sets the status for the server room keypad task as complete.
            }

        }
        else if (keypadActive == false) // if the user has not activated the keypad
        {
            if(inRange == true && Input.GetKeyDown("e")) // If the user in range and presses "E" then a locked message is shown.
            {
                Debug.Log("You have pressed E to try and use the keypad");

                lockedTextInteraction.gameObject.SetActive(false); // hides the interaction text
                keypadLockedFX.Play(0); // Will play locked keypad sound effect when user interacts with the locked keypad.
                StartCoroutine(keypadIsLocked()); // invokes method to show locked keypad message for only a second.

            }
        }
    }

    // This function is called when the user is close to the box collider of the keypad
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, interaction text and unlocked text is not shown and dont update the player within range
        if(taskComplete == true)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            lockedTextInteraction.gameObject.SetActive(false);
            unlockedText.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Player") && keypadActive == false) // if the player is in range of the keypad and the keypad is not activated then they are shown a locked interaction text message
        {
            // Highlights the unactive keypad, changes the range status to true and activates the text instruction
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
            inRange = true;
            lockedTextInteraction.gameObject.SetActive(true);
        }
        else if (other.CompareTag("Player") && keypadActive == true)  // if the player is in range of the keypad and the keypad is activated then they are shown the unlocked keypad interaction text
        {
            // Highlights the interactable active keypad, changes the range status to true and activates the text instruction to interact with keypad
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
            inRange = true;
            unlockedText.gameObject.SetActive(true);
        }
    }

    // This function is called when the user is exiting the box collider of the keypad.
    // The color of the keypad is changed to the default color, the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
    void OnTriggerExit(Collider other)
    {
        // If the player exits out of the keypad range and it is active, the unlocked keypad text is hidden. The highlighting of the keypad will disappear.
        if(other.CompareTag("Player") && keypadActive == true)
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            unlockedText.gameObject.SetActive(false);
            
        } // Else if the player exits out of the keypad range and it is locked, the locked keypad text interaction is hidden. The highlighting of the keypad will disappear.
        else if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            lockedTextInteraction.gameObject.SetActive(false);
        }
    }

    // This method will be invoked to show the locked keypad message for one second to the user 
    // when they try to interact with the locked keypad by pressing "E".
    // This method will return the IEnumerator object.
    IEnumerator keypadIsLocked()
    {
        lockedKeypadMsg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1); //  waits one second.
        lockedKeypadMsg.gameObject.SetActive(false); // hides locked keypad message.
    }
}
