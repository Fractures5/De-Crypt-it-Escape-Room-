using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerCursor : MonoBehaviour
{
    
    void Update()
    {
        //Show the cursor and unlock the cursor to the screen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
