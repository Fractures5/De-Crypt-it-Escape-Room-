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
        padlockFalling = GetComponent<Animation>();
        //hasClipPlayed = false;

        /**if (LockControl.isPadlockOpened == true && hasClipPlayed == false)
        {
            padlockFalling.clip = plDropping;
            padlockFalling.Play("PadlockFall");
            hasClipPlayed = true;
        }**/
    }

    // Update is called once per frame
    void Update()
    {
        if (LockControl.isPadlockOpened == true && hasClipPlayed == false)
        {
            padlockFalling.clip = plDropping;
            padlockFalling.Play("PadlockFall");
            hasClipPlayed = true;
            StartCoroutine(WaitForFall(padlockFalling));
        }
        if (hasEnumeratorRan == true)
        {
            stuntDouble.gameObject.SetActive(true);
            gameObject.SetActive(false);
            //stuntDouble.gameObject.SetActive(true);
            //gameObject.GetComponent<PadLockDrop>().enabled = false;
        }

        IEnumerator WaitForFall(Animation animation)
        {
            while (animation.isPlaying)
            {
                yield return null;
            }
            stuntDouble.gameObject.SetActive(true);
            hasEnumeratorRan = true;
        }
    }

    
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