using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEndResult : MonoBehaviour
{
    public Text showMinutes;
    public Text showSeconds;

    public static string recordMinutesLeft;
    public static string recordSecondsLeft;

    // Update is called once per frame
    void Update()
    {
        showMinutes.text = recordMinutesLeft;
        showSeconds.text = recordSecondsLeft;
    }
}
