using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public Transform canvas;
    //public Transform Player;
    //public GameObject Environment;
    //public GameObject Player;
    public GameObject Canvas;
    public GameObject Capsule;
    //public GameObject PauseMenuCamera;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Pause();
        } 
    }

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            //Environment.SetActive(false);
            //Player.SetActive(false);
            Canvas.SetActive(false);
            canvas.gameObject.SetActive(true);
            Capsule.SetActive(false);
            //PauseMenuCamera.SetActive(true);
            Time.timeScale = 0; //pauses time, regular time is 1
            //Player.GetComponent<PlayerController>().enabled = false;

        } 
        else
        {
            //Environment.SetActive(true);
            //Player.SetActive(true);
            Canvas.SetActive(true);
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Capsule.SetActive(true);
            //PauseMenuCamera.SetActive(false);
            //Player.GetComponent<PlayerController>().enabled = true;
        }
        
    }
}