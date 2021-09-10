using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInteraction : MonoBehaviour
{
    [SerializeField]
    private Image _parchment;

    public bool isRange = false;
    public Text interactionText;
    public GameObject firstPersonController;
    public GameObject firstPersonCamera;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(true);
            isRange = true;
            //_parchment.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           interactionText.gameObject.SetActive(false);
           isRange = false;
           //_parchment.enabled = false;
        }
    }

    // Start is called before the first frame update
    //void Start()
   // {
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        if (isRange == true && Input.GetKeyDown("e"))
        {
            interactionText.gameObject.SetActive(false);
            
            firstPersonController.GetComponent<Jump>().enabled=false;
            firstPersonController.GetComponent<FirstPersonMovement>().enabled=false;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=false;
            firstPersonCamera.GetComponent<Zoom>().enabled=false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _parchment.enabled = true;
        }
        else if(isRange == false)
        {
            _parchment.enabled = false;
        }
        
    }
}
