using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadLockDrop : MonoBehaviour
{
    public Animation padlockFalling;
    public AnimationClip plDropping;
    // Start is called before the first frame update
    void Start()
    {
        padlockFalling = GetComponent<Animation>();
        if (LockControl.isPadlockOpened == true)
        {
            padlockFalling.clip = plDropping;
            padlockFalling.Play("PadlockFall");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LockControl.isPadlockOpened == true)
        {
            //padlockFalling.clip = plDropping;
            //padlockFalling.Play("PadlockFall");
        }
        
    }
}
