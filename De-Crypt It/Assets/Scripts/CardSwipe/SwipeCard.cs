using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour, IDragHandler
{
    //This script is used for the card object in the card swipe puzzle to be moved around and swiped to complete the task
    public Canvas canvas;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position,
        canvas.worldCamera, out pos);

        transform.position = canvas.transform.TransformPoint(pos);
    }

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }
}
