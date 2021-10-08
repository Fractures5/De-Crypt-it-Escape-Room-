using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRUnlockedDoorFX : MonoBehaviour
{
    public AudioSource unlockedDoorFX;

    // This function is called when the user is close to the box collider of door
    void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
            unlockedDoorFX.Play(0); // when user is in range of the locked door play locked door sound effect
        }
    }
}
