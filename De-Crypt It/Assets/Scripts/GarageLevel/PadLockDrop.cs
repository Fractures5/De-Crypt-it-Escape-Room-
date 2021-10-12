using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadLockDrop : MonoBehaviour
{
    public Animation padlockFalling;
    public AnimationClip plDropping;
    public bool hasClipPlayed;
    // Start is called before the first frame update
    void Start()
    {
        padlockFalling = GetComponent<Animation>();
        hasClipPlayed = false;

        if (LockControl.isPadlockOpened == true)
        {
            padlockFalling.clip = plDropping;
            padlockFalling.Play("PadlockFall");
            hasClipPlayed = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /**if (LockControl.isPadlockOpened == true && hasClipPlayed == false)
        {
            padlockFalling.clip = plDropping;
            padlockFalling.Play("PadlockFall");
            hasClipPlayed = true;
        }
        if (LockControl.isPadlockOpened == true && hasClipPlayed == true)
        {
            Debug.Log("The clip has played now");
            padlockFalling.Stop("PadlockFall");
        }
        **/
        //if (hasClipPlayed == true)
        //{
        //    Debug.Log("The clip has played now");
        //    padlockFalling.Stop("PadlockFall");
        //}
        //if (LockControl.isPadlockOpened == true)
        //{
            //padlockFalling.clip = plDropping;
            //padlockFalling.Play("PadlockFall");
       //}
        
    }
}
