using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentKey : MonoBehaviour
{
    public GameObject theIncorrectKey;
    public bool playerNextToKey = false;
    public static bool hasWrongEnvKeyClltd;
    public bool isRange = false;
    public Text collectKeyInstruction;
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
            collectKeyInstruction.gameObject.SetActive(false);
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
            isRange = false;
            playerNextToKey = false;
            collectKeyInstruction.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRange == false)
            {
                collectKeyInstruction.gameObject.SetActive(false);
            }
            playerNextToKey = true;
            collectKeyInstruction.gameObject.SetActive(true);

        }
    }
}
