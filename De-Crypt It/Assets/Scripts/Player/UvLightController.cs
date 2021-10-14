using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UvLightController : MonoBehaviour
{
    [SerializeField] GameObject UvLight;
    public static bool UvLightActive = false;
    //public static bool isOn = false;
    public AudioSource clickSound;
    // Start is called before the first frame update
    public static bool lightState = false;
    void Start()
    {
        UvLight.gameObject.SetActive(UvLightActive);
    }

    // Update is called once per frame
    void Update()
    {
        if(BatteryInteraction.isBatteryCollected == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
            if (UvLightActive == false) //checks if flashlight is not on
            {
                //isOn = true;
                clickSound.Play(); //plays audio for flashlight turning on (click)
                UvLight.gameObject.SetActive(true);
                UvLightActive = true; //turns on flashlight
            }
            else //if flashlight's state is anything but not on
            {
                //isOn = false;
                clickSound.Play(); //plays audio for flashlight turning off (click)
                UvLight.gameObject.SetActive(false);
                UvLightActive = false; //turns off flashlight

            }
            }
        }
    }
}
