using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadLockInitAnimation : MonoBehaviour
{
    public Animation rotatePadlockBody;
    public AnimationClip rotatingClip;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the animation component attached to the object which this script is applied to
        rotatePadlockBody = GetComponent<Animation>();
        rotatePadlockBody.clip = rotatingClip;
        //animation clip will be played
        rotatePadlockBody.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
