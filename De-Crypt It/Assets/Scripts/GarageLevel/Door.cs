using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Door : MonoBehaviour
{

    public GameObject Key;
    public AnimationClip testingClip;
    public Animation doorClip;
    public bool door;
    public bool isDoorOpened = false;
    public Text doorOpenInstructions;
    public Text doorCloseInstructions;
    public Text doorIncorrectKeyIns;
    public Text doorLockedPrompt;
    public bool isRange = false;
    public AudioSource DoorOpenSoundFX;
    public AudioSource DoorCloseSoundFX;

    public void PlayDoorOpenSoundFX()
    {
        DoorOpenSoundFX.Play();

    }

    public void PlayDoorCloseSoundFX()
    {
        DoorCloseSoundFX.Play();
    }

    void Start(){
        doorClip = GetComponent<Animation>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door = true;
            if (isRange == false)
            {
                doorOpenInstructions.gameObject.SetActive(false);
                doorCloseInstructions.gameObject.SetActive(false);
                doorLockedPrompt.gameObject.SetActive(false);
            }

            if (Target.isKeyCollected == true /**Key.active == false**/ && isDoorOpened == false)
            {
                doorOpenInstructions.gameObject.SetActive(true);
                doorCloseInstructions.gameObject.SetActive(false);
            }

            if (Target.isKeyCollected == true /**Key.active == false**/ && isDoorOpened == true)
            {
                doorCloseInstructions.gameObject.SetActive(true);
                doorOpenInstructions.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door = false;
            isRange = false;
            doorOpenInstructions.gameObject.SetActive(false);
            doorCloseInstructions.gameObject.SetActive(false);
            doorLockedPrompt.gameObject.SetActive(false);
            doorIncorrectKeyIns.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == true /**Key.active == false**/ && isDoorOpened == false)
        {
            doorClip.clip = testingClip;
            doorClip.Play("DoorOpen");
            PlayDoorOpenSoundFX();
            isDoorOpened = true;
            doorOpenInstructions.gameObject.SetActive(false);
            doorCloseInstructions.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == true /**Key.active == false**/ && isDoorOpened == true)
        {
            doorClip.clip = testingClip;
            doorClip ["DoorClose"].speed = -1;
            doorClip ["DoorClose"].time = doorClip ["DoorClose"].length;
            doorClip.Play("DoorClose");
            PlayDoorCloseSoundFX();
            isDoorOpened = false;
            doorCloseInstructions.gameObject.SetActive(false);
            doorOpenInstructions.gameObject.SetActive(true);
            
        }

        else if (Input.GetKeyDown(KeyCode.E) && door == true && IncorrectKey.isWrongKeyCollected == true /**Key.active == false**/ && isDoorOpened == false)
        {
            doorIncorrectKeyIns.gameObject.SetActive(true);
        }
        

        else if (Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == true /**Key.active == true**/)
        {
            doorLockedPrompt.gameObject.SetActive(true);
        }
        
    }
}