using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTask : MonoBehaviour
{
    public List<SwipePoint> swipePoints = new List<SwipePoint>();

    public float countdownMax = 0.5f;

    public GameObject greenOn;
    public GameObject redOn;

    public GameObject winScreen;
    public GameObject closeCardSwipe;

    private int currentSwipePointIndex = 0;

    private float countdown = 0;

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
        if (wasSuccesful)
        {
            greenOn.SetActive(true);
            winScreen.SetActive(true);
            closeCardSwipe.SetActive(true);
            CardSwipe.isComplete = true;
        }
        else
        {
            redOn.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        greenOn.SetActive(false);
        redOn.SetActive(false);
    }

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
