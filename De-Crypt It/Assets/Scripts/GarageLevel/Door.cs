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

    public bool hasDoorBeenUnlocked = false;
    public bool isDoorOpened = false;
    public Text doorOpenInstructions;
    public Text doorCloseInstructions;
    public Text doorUnlockInstructions;
    public Text doorIncorrectKeyIns;
    public Text doorLockedPrompt;

    public Text doorUnlockedPrompt;
    
    public bool isRange = false;
    public AudioSource DoorOpenSoundFX;
    public AudioSource DoorCloseSoundFX;
    public AudioSource DoorLockedSoundFX;
    public AudioSource DoorStillLockedSoundFX;

    public void PlayDoorStillLockedSoundFX()
    {
        DoorStillLockedSoundFX.Play();

    }
    public void PlayDoorLockedSoundFX()
    {
        DoorLockedSoundFX.Play();

    }

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
                doorUnlockInstructions.gameObject.SetActive(false);
                doorLockedPrompt.gameObject.SetActive(false);
            }

            if(isDoorOpened == false && Target.isKeyCollected == false && IncorrectKey.isWrongKeyCollected == false) //if door is closed and NO keys have been collected
            {
                doorCloseInstructions.gameObject.SetActive(false);
                doorOpenInstructions.gameObject.SetActive(true);
            
            }
            //this if-block is correct ^

            if(isDoorOpened == true) //if door is opened
            {
                doorOpenInstructions.gameObject.SetActive(false);
                doorCloseInstructions.gameObject.SetActive(true);
            }
            //this if-block is correct ^

            if (hasDoorBeenUnlocked == false && Target.isKeyCollected == true && isDoorOpened == false) //if door hasnt been unlocked and not opened but correct key is collected
            {
                doorUnlockInstructions.gameObject.SetActive(true);
            }

            if (hasDoorBeenUnlocked == true && Target.isKeyCollected == true && isDoorOpened == false) //if has been unlocked and correct key is collected and door has not been opened
            {
                doorOpenInstructions.gameObject.SetActive(true);
                doorCloseInstructions.gameObject.SetActive(false);
            }

            if (hasDoorBeenUnlocked == true && Target.isKeyCollected == true && isDoorOpened == true) //if door has been unlocked and correct key is collected but door has been opened
            {
                doorCloseInstructions.gameObject.SetActive(true);
                doorOpenInstructions.gameObject.SetActive(false);
            }

            if (hasDoorBeenUnlocked == false && IncorrectKey.isWrongKeyCollected == true && isDoorOpened == false) //if door has not been unlocked but wrong key is collected and door is not open
            {
                doorUnlockInstructions.gameObject.SetActive(true);
            }
            if (hasDoorBeenUnlocked == true && IncorrectKey.isWrongKeyCollected == true && isDoorOpened == false)
            {
                doorUnlockInstructions.gameObject.SetActive(false);
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
            doorUnlockInstructions.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDoorBeenUnlocked == false && Input.GetKeyDown(KeyCode.U) && door == true && Target.isKeyCollected)
        {
            hasDoorBeenUnlocked = true;
            doorUnlockInstructions.gameObject.SetActive(false);
            StartCoroutine(displayUnlockSuccessful());
            //doorOpenInstructions.gameObject.SetActive(true);
        }
        if (hasDoorBeenUnlocked == true && Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == true && isDoorOpened == false)
        {
            doorUnlockInstructions.gameObject.SetActive(false);
            doorClip.clip = testingClip;
            doorClip.Play("DoorOpen");
            PlayDoorOpenSoundFX();
            isDoorOpened = true;
            doorOpenInstructions.gameObject.SetActive(false);
            doorCloseInstructions.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == true && isDoorOpened == true)
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

        else if (Input.GetKeyDown(KeyCode.E) && door == true && IncorrectKey.isWrongKeyCollected == true && isDoorOpened == false)
        {
            //doorIncorrectKeyIns.gameObject.SetActive(true);
            PlayDoorStillLockedSoundFX();
            StartCoroutine(doorStillLocked());
            
        }
        

        else if (Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == false && IncorrectKey.isWrongKeyCollected == false)
        {
            PlayDoorLockedSoundFX();
            StartCoroutine(doorIsLocked());
            doorOpenInstructions.gameObject.SetActive(false);
        }
        
    }

     IEnumerator doorStillLocked() //method to display to the player that the door is still locked after trying the incorrect keys
     {
        doorIncorrectKeyIns.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        doorIncorrectKeyIns.gameObject.SetActive(false);
     }

     IEnumerator doorIsLocked()
     {
        yield return new WaitForSeconds(1);
        doorLockedPrompt.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        doorLockedPrompt.gameObject.SetActive(false);
     }

     IEnumerator displayUnlockSuccessful()
     {
        doorUnlockedPrompt.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        doorUnlockedPrompt.gameObject.SetActive(false);
     }
}