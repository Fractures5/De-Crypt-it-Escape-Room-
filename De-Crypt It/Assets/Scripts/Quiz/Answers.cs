using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    // Declares variables
    public bool isCorrect = false;
    public Quiz_Manager quizManager;
    
    public Color initialColor;

    // Will set the initialColor variable as the original button color
    private void Start()
    {
        initialColor = GetComponent<Image>().color;
    }

    // Will print either an incorrect or correct message 
    //to the console depending on the users answer to the question.
    public void Answer()
    {
        if(isCorrect) 
        {
            //GetComponent<Image>().color = Color.green;
            StartCoroutine(ChangeColorGreen()); 
            Debug.Log("That is the Correct Answer");
            quizManager.answerCorrect();
        }
        else
        {
            //GetComponent<Image>().color = Color.red;
            StartCoroutine(ChangeColorRed()); 
            Debug.Log("That is the Wrong Answer");
            quizManager.answerIncorrect();
        }
    }

    // Changes the button to green then back to yellow in 0.5s
    IEnumerator ChangeColorGreen()
    {
        GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().color = initialColor;
        StopCoroutine(ChangeColorGreen());
    }

// Changes the button to red then back to yellow in 0.5s
    IEnumerator ChangeColorRed()
    {
        GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().color = initialColor;
        StopCoroutine(ChangeColorRed());
    }
}
