using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //This dont detroy function allows the timer screen ui to continue incrementing and to be displayed all throughout the seen
        //This is necessary to let the player know how much time they have left
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++) 
        {
                if(Object.FindObjectsOfType<DontDestroy>()[i] != this)
                {
                    //Check if there is a game object that has the same name, if there is then destroy that gameobject
                    if(Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                    {
                        Destroy(gameObject);
                    }
                }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

