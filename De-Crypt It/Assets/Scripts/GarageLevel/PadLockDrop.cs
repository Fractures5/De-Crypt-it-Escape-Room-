using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadLockDrop : MonoBehaviour
{
    public Animation padlockFalling;
    public AnimationClip plDropping;
    public GameObject stuntDouble;
    public static bool hasClipPlayed = false;
    public static bool hasEnumeratorRan = false;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the animation clip attached to the game object which this script is applied to and saves it into Animation variable
        padlockFalling = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //if padlock has been unlocked and the animation clip has not played yet
        if (LockControl.isPadlockOpened == true && hasClipPlayed == false)
        {
            //play the PadlockFall animation clip
            padlockFalling.clip = plDropping;
            padlockFalling.Play("PadlockFall");
            hasClipPlayed = true;
            StartCoroutine(WaitForFall(padlockFalling));
        }
        //checks if IEnumerator function has executed
        if (hasEnumeratorRan == true)
        {
            //sets 2nd padlock gameobject stunt double to true state to display it on the ground
            stuntDouble.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        //IEnumerator function which waits until padlock falling animation is complete
        IEnumerator WaitForFall(Animation animation)
        {
            //while animation clip of padlock falling is running
            while (animation.isPlaying)
            {
                yield return null;
            }
            stuntDouble.gameObject.SetActive(true);
            hasEnumeratorRan = true;
        }
    }

}