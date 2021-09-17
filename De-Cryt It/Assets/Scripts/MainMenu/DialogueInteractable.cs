using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : MonoBehaviour
{
    //This script will handle the dialogue trigger
   public Dialogue dialogue;

   public void TriggerDialogue ()
   {
       FindObjectOfType<DialogueController>().StartDialogue(dialogue);
   }
}
