using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //this method will check for the tag, and if it matches will allow the objects to collide.
    public void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player")){

           GameManager.Instance.lastCheckPoint = transform;
        
        }
    }
}
