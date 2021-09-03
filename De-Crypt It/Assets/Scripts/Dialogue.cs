using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use dialogue class an object we can pass into the dialogue controller when
// we need to begin a new dialogue. This class stores information we need about a dialogue.
[System.Serializable]
public class Dialogue
{
    public string characterName;

    [TextArea(3, 10)]
    public string[] sentences;

}
