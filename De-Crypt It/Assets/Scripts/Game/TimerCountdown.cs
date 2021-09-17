using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public static int timeLeft = 1800;
    public static bool timeTaken = false;
    public static int minutes;
    public static int seconds;
    public bool check = false;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {

        if (timeTaken == false && timeLeft > 0)
        {
            StartCoroutine(Timer());
        }
        else if (timeLeft == 0 && check == false)
        {
            check = true;
            SceneManager.LoadScene("EndScreen");
            Debug.Log("You have failed to escape!");
        }
    }

    IEnumerator Timer()
    {
        timeTaken = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        textDisplay.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeTaken = false;
    }
}
