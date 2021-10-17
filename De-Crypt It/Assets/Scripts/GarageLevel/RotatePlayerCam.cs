using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerCam : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Capsule;
    //public Camera camera;
    public float Rotation;

    public Transform player;

    public GameObject playerrrr;

    public Transform camera;

    public float playerXrotation;
    public float playerYrotation;
    public float playerZrotation;

    public bool test = false;

    void Start()
    {
        //hasPlayerTurned = false;
        PlayerPrefs.SetFloat("PositionX", player.position.x);
        PlayerPrefs.SetFloat("PositionY", player.position.y);
        PlayerPrefs.SetFloat("PositionZ", player.position.z);

       // PlayerPrefs.SetFloat("RotationX", camera.transform.eulerAngles.x);
        //PlayerPrefs.SetFloat("RotationY", camera.transform.eulerAngles.y+90);
        //PlayerPrefs.SetFloat("RotationZ", camera.transform.eulerAngles.z);

        //PlayerPrefs.SetFloat("RotationX", player.transform.eulerAngles.x);
        //PlayerPrefs.SetFloat("RotationY", player.transform.eulerAngles.y + 90);
        //PlayerPrefs.SetFloat("RotationZ", player.transform.eulerAngles.z);

        PlayerPrefs.SetFloat("RotationX", player.transform.eulerAngles.x);
        PlayerPrefs.SetFloat("RotationY", player.transform.eulerAngles.y+100);
        PlayerPrefs.SetFloat("RotationZ", player.transform.eulerAngles.z);

        playerXrotation = PlayerPrefs.GetFloat("RotationX");
        playerYrotation = PlayerPrefs.GetFloat("RotationY");
        playerZrotation = PlayerPrefs.GetFloat("RotationZ");

        //player.transform.rotation = Quaternion.Euler(playerXrotation, playerYrotation + 100, playerZrotation);

        if (LockControl.isPadlockOpened == true)
        {
            //player.transform.Rotate(0.0f, 80.0f, 0.0f, Space.Self);
            //player.transform.rotation = Quaternion.Euler(playerXrotation, playerYrotation+100, playerZrotation);
            //player.position = new Vector3(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"), PlayerPrefs.GetFloat("PositionZ"));
        }
    }

    void Awake()
    {
        //player.transform.rotation = Quaternion.Euler(playerXrotation, playerYrotation + 100, playerZrotation);
    }
    void testCode()
    {
        if (LockControl.isPadlockOpened == true)
        {
            transform.Rotate(0, 180, 0);
            Camera.transform.Rotate(40, 0, 0);
            
        }
    }
    void Update()
    {
        if (test == false)
        {
            test = true;
            testCode();
            //test = true;

        }
            //if (LockControl.isPadlockOpened == true)
            //{
                //player.transform.Rotate(0.0f, 100.0f, 0.0f, Space.Self);
                //player.position = new Vector3(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"), PlayerPrefs.GetFloat("PositionZ"));
                //Debug.Log("Player should turn towards box, bool been set to true");
                //transform.Rotate(0, 180, 0);
                //Camera.transform.Rotate(40, 0, 0);
            //}
        
        //player.position = new Vector3(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"), PlayerPrefs.GetFloat("PositionZ"));
        //if (LockControl.isPadlockOpened == true)
        //{
            //player.transform.Rotate(0.0f, 100.0f, 0.0f, Space.Self);
            //player.position = new Vector3(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"), PlayerPrefs.GetFloat("PositionZ"));
        //    Debug.Log("Player should turn towards box, bool been set to true");
           // transform.Rotate(0, 180, 0);
            //Camera.transform.Rotate(40, 0, 0);
        //}
        //if (LockControl.isPadlockOpened == false)
        //{
        //}
        /*if (LockControl.isPadlockOpened == true && LockControl.turnTowardsBox == true && EasyModePauseGame.isGamePaused == false && hasPlayerTurned == false)
        {
            transform.Rotate(0, 180, 0);
            Camera.transform.Rotate(40, 0, 0);
            StartCoroutine(WaitForSeconds());
            hasPlayerTurned = true;
            
        }
        else if (LockControl.isPadlockOpened == true && LockControl.turnTowardsBox == false)
        {
            //transform.Rotate(0, 0, 0);
            //Camera.transform.Rotate(0, 0, 0);
        }

        if (EasyModePauseGame.isGamePaused == true && LockControl.turnTowardsBox == false)
        {
            Camera.GetComponent<FirstPersonLook>().enabled = false;
            Capsule.SetActive(false);
            Debug.Log("Game should be paused");
        }

        if (hasPlayerTurned = true)
        {
            LockControl.turnTowardsBox = false;
        }*/
    }
}

//player.transform.eulerAngles.x = PlayerPrefs.GetFloat("RotationX");
//player.transform.eulerAngles.y = PlayerPrefs.GetFloat("RotationY");
// player.transform.eulerAngles.z = PlayerPrefs.GetFloat("RotationZ");

//player.transform.rotation = Quaternion.Euler(new Vector3(PlayerPrefs.GetFloat("RotationX"),PlayerPrefs.GetFloat("RotationY"), PlayerPrefs.GetFloat("RotationZ")));
//camera.rotation = new Quaternion.Euler(PlayerPrefs.GetFloat("RotationX"), PlayerPrefs.GetFloat("RotationY"), PlayerPrefs.GetFloat("RotationZ"));

//camera.rotation = Quaternion.Euler(PlayerPrefs.GetFloat("RotationX"), PlayerPrefs.GetFloat("RotationY"), PlayerPrefs.GetFloat("RotationZ"));

//Debug.Log("Player should turn towards box, bool been set to true");
// transform.Rotate(0, 180, 0);
//Camera.transform.Rotate(40, 0, 0);
