using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    //This script is used to move the card around in the card swipe puzzle
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
