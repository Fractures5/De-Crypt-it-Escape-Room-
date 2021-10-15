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
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = startcolor;
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
            GetComponent<Renderer>().material.color = startcolor;
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
    private IEnumerator WaitForAnimation(Animation animation)
    {
        while (animation.isPlaying)
        {
            yield return null;
        }
        Debug.Log("Animation completed");
        SceneManager.LoadScene("InsideGarageBox");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
