using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPosition : MonoBehaviour
{
    //storign a transfor for our start position of the game.
    public Transform startPosition;

    //This method is a trigger ented made to check if the tag is "player" and if so it will allow to collider with another object.
    public void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Player")){

            other.gameObject.transform.position =
            GameManager.Instance.lastCheckPoint.position;
        
        }

    }
}
