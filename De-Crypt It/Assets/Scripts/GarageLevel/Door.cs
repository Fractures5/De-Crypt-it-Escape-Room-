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

    public Text multipleKeySuccess;

    public Text doorUnlockedPrompt;
    
    public bool isRange = false;
    public AudioSource DoorOpenSoundFX;
    public AudioSource DoorCloseSoundFX;
    public AudioSource DoorLockedSoundFX;
    public AudioSource DoorStillLockedSoundFX;
    public AudioSource DoorCorrectKeyUnlockSoundFX;

    //This function is invoked when the correct key is used to unlock the door, playing an unlock sound effect.
    public void PlayDoorCorrectKeyUnlockSoundFX()
    {
        DoorCorrectKeyUnlockSoundFX.Play();

    }

    //This function is invoked when an incorrect key is used to unlock the door, playing a locked sound effect.
    public void PlayDoorStillLockedSoundFX()
    {
        DoorStillLockedSoundFX.Play();

    }

    //This function is invoked when no key has been collected and the player attempts to open the door, playing a locked sound effect.
    public void PlayDoorLockedSoundFX()
    {
        DoorLockedSoundFX.Play();

    }

    //This function is invoked when the door has been unlocked and the door is opened, playing an opening sound effect.
    public void PlayDoorOpenSoundFX()
    {
        DoorOpenSoundFX.Play();
    }

    //This function is invoked when the door has been unlocked and the door is opened, playing an opening sound effect.
    public void PlayDoorCloseSoundFX()
    {
        DoorCloseSoundFX.Play();
    }

    void Start(){
        //Gets the animation component attached to the game object and saves into doorClip
        doorClip = GetComponent<Animation>();
    }

    //if the player controller enters the collider of the door then this function will be invoked
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door = true;
            //if the player controller leaves the collider of the door
            if (isRange == false)
            {
                //set the text interaction pop-ups to false so they dont appear
                doorOpenInstructions.gameObject.SetActive(false);
                doorCloseInstructions.gameObject.SetActive(false);
                doorUnlockInstructions.gameObject.SetActive(false);
                doorLockedPrompt.gameObject.SetActive(false);
            }

            //if door is closed and NO keys have been collected
            if(isDoorOpened == false && Target.isKeyCollected == false && EnvironmentKey.hasWrongEnvKeyClltd == false) 
            {
                //show hide instruction and show open instruction
                doorCloseInstructions.gameObject.SetActive(false);
                doorOpenInstructions.gameObject.SetActive(true);
            
            }

            //if door is opened
            if(isDoorOpened == true) 
            {
                //show close instruction and hide open instruction
                doorOpenInstructions.gameObject.SetActive(false);
                doorCloseInstructions.gameObject.SetActive(true);
            }

            //if door hasnt been unlocked and not opened but correct key is collected
            if (hasDoorBeenUnlocked == false && Target.isKeyCollected == true && isDoorOpened == false) 
            {
                doorUnlockInstructions.gameObject.SetActive(true);
            }

            //if has been unlocked and correct key is collected and door has not been opened
            if (hasDoorBeenUnlocked == true && Target.isKeyCollected == true && isDoorOpened == false) 
            {
                doorOpenInstructions.gameObject.SetActive(true);
                doorCloseInstructions.gameObject.SetActive(false);
            }

            //if door has been unlocked and correct key is collected but door has been opened
            if (hasDoorBeenUnlocked == true && Target.isKeyCollected == true && isDoorOpened == true) 
            {
                doorCloseInstructions.gameObject.SetActive(true);
                doorOpenInstructions.gameObject.SetActive(false);
            }

            //if door has not been unlocked but wrong key is collected and door is not open
            if (hasDoorBeenUnlocked == false && EnvironmentKey.hasWrongEnvKeyClltd == true && isDoorOpened == false) 
            {
                doorUnlockInstructions.gameObject.SetActive(true);
            }
            
            //if door has been unlocked and a decoy has been collected and the door has not been opened
            if (hasDoorBeenUnlocked == true && EnvironmentKey.hasWrongEnvKeyClltd == true && isDoorOpened == false)
            {
                doorUnlockInstructions.gameObject.SetActive(false);
            }
        }
    }

    //checks if the player controller has left the collider of the door
    void OnTriggerExit (Collider other)
    {
        //if the player controller has left the collider of the door
        if (other.CompareTag("Player"))
        {
            //hide all interaction text pop ups
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
        //if the player has pressed U and the door range is true and the correct key is collected a decoy key is collected 
        if (Input.GetKeyDown(KeyCode.U) && door == true && Target.isKeyCollected == true && EnvironmentKey.hasWrongEnvKeyClltd == true)
        {
            //set the boolean value of hasDoorBeenUnlocked to true
            hasDoorBeenUnlocked = true;
            //execute Coroutine
            StartCoroutine(displayMultipleKeySuccess());
            doorUnlockInstructions.gameObject.SetActive(false);
            PlayDoorCorrectKeyUnlockSoundFX();
        }
        //if player has pressed U and the door range is true and the correct key is collected
        else if (Input.GetKeyDown(KeyCode.U) && door == true && Target.isKeyCollected == true)
        {
            //set the boolean value of hasDoorBeenUnlocked to true
            hasDoorBeenUnlocked = true;
            doorUnlockInstructions.gameObject.SetActive(false);
            StartCoroutine(displayUnlockSuccessful());
            PlayDoorCorrectKeyUnlockSoundFX();
        }
        //if door has been unlocked and the player has pressed E and the door range is true and the correct key is collected but the door is not opened
        else if (hasDoorBeenUnlocked == true && Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == true && isDoorOpened == false)
        {
            doorUnlockInstructions.gameObject.SetActive(false);
            //play the DoorOpen animation clip
            doorClip.clip = testingClip;
            doorClip.Play("DoorOpen");
            //play the open door sound effect
            PlayDoorOpenSoundFX();
            isDoorOpened = true;
            StartCoroutine(WaitForOpenAnimation(doorClip));
        }

        //if the player has pressed E and the door range is true and the correct key is collected and the door is also opened
        else if (Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == true && isDoorOpened == true)
        {
            //Play DoorClose animation clip
            doorClip.clip = testingClip;
            doorClip ["DoorClose"].speed = -1;
            doorClip ["DoorClose"].time = doorClip ["DoorClose"].length;
            doorClip.Play("DoorClose");
            //play the close door sound effect
            PlayDoorCloseSoundFX();
            isDoorOpened = false;
            StartCoroutine(WaitForCloseAnimation(doorClip));
            
        }

        //if the player has pressed U and the door range is ture and a wrong key has been collected and the door is not open
        else if (Input.GetKeyDown(KeyCode.U) && door == true && EnvironmentKey.hasWrongEnvKeyClltd == true && isDoorOpened == false)
        {
            doorUnlockInstructions.gameObject.SetActive(false);
            PlayDoorStillLockedSoundFX();
            StartCoroutine(doorStillLocked());
        }
        
        //if the player has 
        else if (Input.GetKeyDown(KeyCode.E) && door == true && Target.isKeyCollected == false && EnvironmentKey.hasWrongEnvKeyClltd == false)
        {
            PlayDoorLockedSoundFX();
            StartCoroutine(doorIsLocked());
            doorOpenInstructions.gameObject.SetActive(false);
        }
        
    }

    //IEnumerator function to display to the player that the door is still locked after trying the incorrect keys
    IEnumerator doorStillLocked() 
     {
        doorIncorrectKeyIns.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        doorIncorrectKeyIns.gameObject.SetActive(false);
     }

    //IEnumerator function to display to the player that the door is locked after trying to open the door without collecting any keys
    IEnumerator doorIsLocked()
     {
        yield return new WaitForSeconds(1);
        doorLockedPrompt.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        doorLockedPrompt.gameObject.SetActive(false);
     }

    //IEnumerator function to display to the player that the door is unlocked after trying the correct key
    IEnumerator displayUnlockSuccessful()
     {
        doorUnlockedPrompt.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        doorUnlockedPrompt.gameObject.SetActive(false);
        doorOpenInstructions.gameObject.SetActive(true);
     }

    //IEnumerator function to display to the player that the door is unlocked after trying the correct key while a decoy key has also been collected
    IEnumerator displayMultipleKeySuccess()
    {
        multipleKeySuccess.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        multipleKeySuccess.gameObject.SetActive(false);
        doorOpenInstructions.gameObject.SetActive(true);
    }

    //IEnumerator function to wait until the end of the open door animation of the door object
    private IEnumerator WaitForOpenAnimation(Animation animation)
    {
        //while animation clip is playing
        while (animation.isPlaying)
        {
            yield return null;
        }
        doorOpenInstructions.gameObject.SetActive(false);
        doorCloseInstructions.gameObject.SetActive(true);
    }

    //IEnumerator function to wait until the end of the open close animation of the door object
    private IEnumerator WaitForCloseAnimation(Animation animation)
    {
        //while animation clip is playing
        while (animation.isPlaying)
        {
            yield return null;
        }
        doorOpenInstructions.gameObject.SetActive(true);
        doorCloseInstructions.gameObject.SetActive(false);
    }
}