using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxInteraction : MonoBehaviour
{
    public bool isRange = false;

    public AnimationClip testingClip;
    public Animation boxOpenClip;

    public bool box;
    public Text boxInstructions;
    public Text boxSearchInstructions;

    public static bool taskComplete = false;

    public static bool isClosed = false;

    // Start is called before the first frame update
    void Start()
    {
        //get the animation component attached to the game object which script is applied to and save it into Animation variable
        boxOpenClip = GetComponent<Animation>();
    }

    //if the collider of the player has entered the collider of the box object
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box = true;
            //if the player has left the collider of the box
            if (isRange == false)
            {
                //hide all box interaction instruction pop ups
                boxInstructions.gameObject.SetActive(false);
                boxSearchInstructions.gameObject.SetActive(false);
            }

            //if the padlock has not been unlocked
            if(LockControl.isPadlockOpened == false)
            {
                //show the open box instructions
                boxInstructions.gameObject.SetActive(true);
            }
            //if the padlock has been unlocked
            if(LockControl.isPadlockOpened == true)
            {
                //show the search box instructions
                boxSearchInstructions.gameObject.SetActive(true);
            }
        }
    }

    //if the collider of the player has left the collider of the box object
    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //hide all box interaction pop ups if the player has left the collider of the box
            box = false;
            isRange = false;
            boxInstructions.gameObject.SetActive(false);
            boxSearchInstructions.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        //if the player has pressed E and the box is in range and the padlock and not been unlocked
        if (Input.GetKeyDown(KeyCode.E) && box == true && LockControl.isPadlockOpened == false)
        {
            //load Padlock scene
            SceneManager.LoadScene("Padlock");
            //show the cursor and unlock it
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        //if the player has pressed E and the box is in range and the padlock has been unlocked
        if (Input.GetKeyDown(KeyCode.E) && box == true && LockControl.isPadlockOpened == true)
        {
            //play the OpenBox clip
            boxOpenClip.clip = testingClip;
            boxOpenClip.Play("OpenBox");
            StartCoroutine(WaitForAnimation(boxOpenClip));
        }
    }

    //This IEnumerator function will be invoked when the player wishes to search the box after unlocking the padlock.
    private IEnumerator WaitForAnimation(Animation animation)
    {
        //While the animation clip is running
        while (animation.isPlaying)
        {
            yield return null;
        }
        //Animation has completed and the following code will be executed.
        Debug.Log("Animation completed");
        //InsideGarageBox Scene will be loaded
        SceneManager.LoadScene("InsideGarageBox");
        //Cursor will be visible and unlocked
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
