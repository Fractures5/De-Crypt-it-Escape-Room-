using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizLoad : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Text variable that gives instructions to the player on how to interact with the quiz
    public Text interactionText;

    // Boolean which checks if the player is in the range of the tv object
    public bool inRange = false;

    // Static variable which is readable and modifiable by other scripts. 
    // It is used to determine if the quiz task is completed or not by the user.
    public static bool taskComplete = false;

    // GameObject variables of the tv puzzle menu and clue which is used to set the gameobject to be active or not.
    public GameObject tvPuzzleMenu;
    public GameObject tvPuzzleClue;
   
    // Update is called once per frame
    void Update()
    {
        // If the task is not complete and the user in range and interacts with the quiz 
        // game object by pressing "E", then the quiz menu will load.
        if(taskComplete == false)
        {
            if(inRange == true && Input.GetKeyDown("e"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(5);
            }
        }
        else
        {
            // If the task is complete then....
            tvPuzzleMenu.SetActive(false); // Disables the tv puzzle menu
            tvPuzzleClue.SetActive(true); // Enables the tv clue
        }
    }

    // This function is called when the user is close to the box collider of the gameobject in the TV
    void OnTriggerEnter(Collider other)
    {
        // If the task is complete, object is not higlighted, instructions is not shown and dont update the player within range
        if(taskComplete == true)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);
        }
        // If the task in not complete, object is highlighted, instructions text is show and the player within the range is updated
        else
        {
            if (other.CompareTag("Player"))
            {
                // Highlights the interactable TV game object, changes the range status to true and activates the text instruction
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                interactionText.gameObject.SetActive(true);
            }
        }
    }

    // This function is called when the user is exiting the box collider of the gameobject in the TV
    void OnTriggerExit(Collider other)
    {
        // The color of the interactable gameobject in the TV is changed to the default color,
        // the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
        if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);

        }
    }
}
