using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPosition : MonoBehaviour
{
    public Transform startPosition;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.transform.position = startPosition.position;
            other.gameObject.transform.position =
             GameManager.Instance.lastCheckPoint.position;
        }
    }
}
