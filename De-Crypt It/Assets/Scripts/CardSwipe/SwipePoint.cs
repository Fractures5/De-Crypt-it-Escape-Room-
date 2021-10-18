using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePoint : MonoBehaviour
{
    //This script is used to keep the swipe task puzzle awake and have the points of swipe be triggered when the card object is swiped through
    private SwipeTask swipeTask;

    private void Awake()
    {
        swipeTask = GetComponentInParent<SwipeTask>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        swipeTask.SwipePointTrigger(this);
    }
}
