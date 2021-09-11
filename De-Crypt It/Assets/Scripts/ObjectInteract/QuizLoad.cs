using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizLoad : MonoBehaviour
{
    [SerializeField]
    public Text interactionText;
    public bool inRange = false;
    public static bool taskComplete = false;

    // Update is called once per frame
    void Update()
    {
        if(taskComplete == false)
        {
            if(inRange == true && Input.GetKeyDown("e"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(5);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(taskComplete == true)
        {
            inRange = false;
            interactionText.gameObject.SetActive(false);
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                inRange = true;
                interactionText.gameObject.SetActive(true);
            }
        }
    }

    void OnTiggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = false;
            interactionText.gameObject.SetActive(false);

        }
    }
}
