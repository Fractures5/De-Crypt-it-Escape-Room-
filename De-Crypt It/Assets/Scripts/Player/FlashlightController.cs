using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    public static bool FlashlightActive = false;
    //public static bool isOn = false;
    public AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        FlashlightLight.gameObject.SetActive(FlashlightActive);
    }

    // Update is called once per frame
    void Update()
    {
        FlashlightLight.gameObject.SetActive(FlashlightActive);
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false) //checks if flashlight is not on
            {
                //isOn = true;
                clickSound.Play(); //plays audio for flashlight turning on (click)
                FlashlightLight.gameObject.SetActive(true);
                FlashlightActive = true; //turns on flashlight
            }
            else //if flashlight's state is anything but not on
            {
                //isOn = false;
                clickSound.Play(); //plays audio for flashlight turning off (click)
                FlashlightLight.gameObject.SetActive(false);
                FlashlightActive = false; //turns off flashlight

            }
        }
    }
}
