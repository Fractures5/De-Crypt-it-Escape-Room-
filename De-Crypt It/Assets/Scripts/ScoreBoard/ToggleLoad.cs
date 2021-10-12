using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLoad : MonoBehaviour
{
    //importing gameobject UI for toggling enabled or disabled
    public GameObject hardDisplay;
    public GameObject mediumDisplay;
    public GameObject easyDisplay;

    //if user wishes to view game mode hard in leaderboord, medium and easy will be disabled
    public void showHard()
    {
        hardDisplay.SetActive(true);
        mediumDisplay.SetActive(false);
        easyDisplay.SetActive(false);
    }

    public void showMedium()
    {
        hardDisplay.SetActive(false);
        mediumDisplay.SetActive(true);
        easyDisplay.SetActive(false);
    }
    public void showEasy()
    {
        hardDisplay.SetActive(false);
        mediumDisplay.SetActive(false);
        easyDisplay.SetActive(true);
    }
}
