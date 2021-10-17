using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject TheKey;
    public bool playerNextToKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerNextToKey == true)
        {
            TheKey.active = false;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNextToKey = false;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNextToKey = true;
        }
    }
}
