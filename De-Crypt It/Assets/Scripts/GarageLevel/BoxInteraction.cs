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
        boxOpenClip = GetComponent<Animation>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box = true;
            if (isRange == false)
            {
                boxInstructions.gameObject.SetActive(false);
                boxSearchInstructions.gameObject.SetActive(false);
            }

            if(LockControl.isPadlockOpened == false)
            {
                boxInstructions.gameObject.SetActive(true);
            }

            if(LockControl.isPadlockOpened == true)
            {
                boxSearchInstructions.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box = false;
            isRange = false;
            boxInstructions.gameObject.SetActive(false);
            boxSearchInstructions.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && box == true && LockControl.isPadlockOpened == false)
        {
            SceneManager.LoadScene("Padlock");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.E) && box == true && LockControl.isPadlockOpened == true)
        {
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
