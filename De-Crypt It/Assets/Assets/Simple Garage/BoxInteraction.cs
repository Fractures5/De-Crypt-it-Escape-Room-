using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxInteraction : MonoBehaviour
{
    public AnimationClip testingClip;
    public Animation boxOpenClip;

    public bool box;
    public Text boxInstructions;

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
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && box == true)
        {
            SceneManager.LoadScene("Padlock");
            Cursor.lockState = CursorLockMode.None;
            //boxOpenClip.clip = testingClip;
            //boxOpenClip.Play();

            if (LockControl.isPadlockOpened == true)
            {
                Debug.Log("Padlock is unlocked now");
            }
        }
    }


    

}
