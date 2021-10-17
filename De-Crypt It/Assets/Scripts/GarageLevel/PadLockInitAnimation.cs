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
        rotatePadlockBody = GetComponent<Animation>();
        rotatePadlockBody.clip = rotatingClip;
        rotatePadlockBody.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
