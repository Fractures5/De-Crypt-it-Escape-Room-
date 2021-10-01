using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    public AnimationClip testingClip;
    public Animation boxOpenClip;
    public bool box;
    // Start is called before the first frame update
    void Start()
    {
        boxOpenClip = GetComponent<Animation>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && box == true)
        {
            boxOpenClip.clip = testingClip;
            boxOpenClip.Play();
        }
    }


    

}
