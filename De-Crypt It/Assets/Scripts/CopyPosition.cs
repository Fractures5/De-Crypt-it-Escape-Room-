using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField]
    Transform transitionTarget;
    
    void Update()
    {
        transform.position = transitionTarget.position;
    }
}
