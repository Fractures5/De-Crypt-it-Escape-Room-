using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PushTheButton : MonoBehaviour
{
    //takes place when particular button is pressed
    public static event Action<string> ButtonPressed = delegate { };
    private int dividerPosition;
    private string buttonName, buttonValue;
    
    // Start is called before the first frame update
    //Get button's name string and gets the index of the divider's position and uses substring method
    void Start()
    {
        buttonName = gameObject.name;
        dividerPosition = buttonName.IndexOf("_");
        buttonValue = buttonName.Substring(0, dividerPosition);
        //detects if button is clicked
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }
    
    private void ButtonClicked()
    {
        ButtonPressed(buttonValue);
    }
}
