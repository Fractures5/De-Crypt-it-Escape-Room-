using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalDisplay : MonoBehaviour
{

    [SerializeField]
    private Sprite[] digits;

    [SerializeField]
    private Image[] characters;

    private string codeSequence;

    public AudioSource correctFX;
    public AudioSource wrongFX;

    public Image correctImage;
    public Image wrongImage;

    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        codeSequence = "";

        for (int i = 0; i <= characters.Length -1; i++)
        {
            characters[i].sprite = digits[10];
        }

        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
        
        exitButton.gameObject.SetActive(true);
    }

    //takes parameter from ButtonPressed event and checks if less than 4, adds the digit to the sequence
    private void AddDigitToCodeSequence(string digitEntered)
    {
        if (codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "Zero":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;
                case "One":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;
                case "Two":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;
                case "Three":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;
                case "Four":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;
                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;
                case "Six":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;
                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;
                case "Eight":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;
                case "Nine":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
            }
        }

        switch (digitEntered)
        {
            case "Star":
                ResetDisplay();
                break;
            
            case "Hash":
                if (codeSequence.Length > 0)
                {
                    CheckResults();
                }
                break;
        }
    }
    //takes number entered as a parameter and displays the appropriate sprite depending on the order which the button is pressed
    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
        }

    }

    //checks if input code is equal to code sequence (correct answer)
    private void CheckResults()
    {
        if (codeSequence == "9607")
        {
            Debug.Log("Correct!");
            correctFX.Play(0);
            StartCoroutine(correctCoroutine());
            KeyPadLoad.taskComplete = true;
        }
        else
        {
            Debug.Log("Wrong!");
            wrongFX.Play(0);
            StartCoroutine(incorrectCoroutine());  
        }
    }

    //Will be invoked when correct pin is input and resets display
    IEnumerator correctCoroutine()
    {
        correctImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        correctImage.gameObject.SetActive(false);
        ResetDisplay();
    }

    //Will be invoked when incorrect pin is input and resets display
    IEnumerator incorrectCoroutine()
    {
        wrongImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        wrongImage.gameObject.SetActive(false);
        ResetDisplay();
    }

    //Resets Digital display by switching sprites to blank digital sprites
    private void ResetDisplay()
    {
        for (int i = 0; i <= characters.Length - 1; i++)
        {
            characters[i].sprite = digits[10];
        }

        codeSequence = "";
    }

    private void OnDestroy()
    {
        PushTheButton.ButtonPressed -= AddDigitToCodeSequence;
    }
}
