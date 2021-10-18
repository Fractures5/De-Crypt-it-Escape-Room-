using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    //This script handles the checkpoint feature of the player's marble in the marble arcade game in hard mode (MainGame)
    [SerializeField]
    Transform transitionTarget;
    
    void Update()
    {
        transform.position = transitionTarget.position;
    }
}
