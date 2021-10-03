using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxInteraction : MonoBehaviour
{

    [SerializeField]
    public Color startcolor;

    public bool isRange = false;

    public AnimationClip testingClip;
    public Animation boxOpenClip;

    public bool box;
    public Text boxInstructions;

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
            }

            if(LockControl.isPadlockOpened == false)
            {
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = startcolor;
                boxInstructions.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box = false;
            GetComponent<Renderer>().material.color = startcolor;
            isRange = false;
            boxInstructions.gameObject.SetActive(false);
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
