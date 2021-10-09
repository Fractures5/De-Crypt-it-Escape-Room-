using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentKey : MonoBehaviour
{
    public GameObject theIncorrectKey;
    public bool playerNextToKey = false;
    public static bool hasWrongEnvKeyClltd;
    // Start is called before the first frame update
    void Start()
    {
        hasWrongEnvKeyClltd = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerNextToKey == true)
        {
            theIncorrectKey.SetActive(false);
            hasWrongEnvKeyClltd = true;
        }

        if (!theIncorrectKey.activeSelf)
        {
            Debug.Log("Not active anymore");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNextToKey = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNextToKey = true;
        }
    }
}
