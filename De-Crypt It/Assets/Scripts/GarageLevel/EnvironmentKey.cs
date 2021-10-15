using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentKey : MonoBehaviour
{
    public GameObject theIncorrectKey;
    public bool playerNextToKey = false;
    public static bool hasWrongEnvKeyClltd = false;
    public bool isRange = false;
    public Text collectKeyInstruction;

    public AudioSource collectKeySoundFX;
    // Start is called before the first frame update

    public void PlayCollectKeySoundFX()
    {
        collectKeySoundFX.Play();

    }
    void Start()
    {
        if (hasWrongEnvKeyClltd == true)
        {
            theIncorrectKey.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerNextToKey == true)
        {
            PlayCollectKeySoundFX();
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
