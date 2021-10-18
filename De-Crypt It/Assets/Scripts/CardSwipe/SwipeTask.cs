using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTask : MonoBehaviour
{
    //This script is used to display the course of actions during the card task puzzle
    public List<SwipePoint> swipePoints = new List<SwipePoint>();

    public float countdownMax = 0.5f;

    public GameObject greenOn;
    public GameObject redOn;

    public GameObject winScreen;
    public GameObject closeCardSwipe;

    public AudioSource winNoise;
    public AudioSource loseNoise;

    private int currentSwipePointIndex = 0;

    private float countdown = 0;

    public static bool isComplete = false;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (currentSwipePointIndex != 0 && countdown <= 0)
        {
            currentSwipePointIndex = 0;
            StartCoroutine(FinishTask(false));
        }
    }

    private IEnumerator FinishTask(bool wasSuccesful)
    {
        //If the task is succesful, then the task will be complete, a green light will indicate success, the win screen for the task will be displayed and give the user to return back to the stage
        if (wasSuccesful)
        {
            isComplete = true;
            winNoise.Play();
            greenOn.SetActive(true);
            winScreen.SetActive(true);
            closeCardSwipe.SetActive(true);
            CardSwipe.isComplete = true;
        }
        else
        {
            //A fail noise will be played along with a red light being emitted to show an unsucceful card swipe
            loseNoise.Play();
            redOn.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        greenOn.SetActive(false);
        redOn.SetActive(false);
    }

    //This function is used to append the succesful card swipe triggers in one succesion, where if succesful will count as the task beng complete, and if not then the task will be false and reset
    public void SwipePointTrigger(SwipePoint swipePoint)
    {
        if (swipePoint == swipePoints[currentSwipePointIndex])
        {
            currentSwipePointIndex++;
            countdown = countdownMax;
        }

        if (currentSwipePointIndex >= swipePoints.Count)
        {
            currentSwipePointIndex = 0;
            StartCoroutine(FinishTask(true));
        }
    }
}