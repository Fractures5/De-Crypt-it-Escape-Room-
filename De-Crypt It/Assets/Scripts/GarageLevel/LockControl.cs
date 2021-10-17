using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    public static bool isPadlockOpened = false;
    public static bool isPadlockClosed;
    public Image correctImage;

    public void Update()
    {
    }
    private void Start()
    {
        //result array will store the clicked wheel number input from the player
        result = new int[]{0,0,0,0};
        //defines correct combination with the set padlock code the player must input to unlock the padlock
        correctCombination = new int[] {5,1,9,3};
        Rotate.Rotated += CheckResults;
    }

    //This function will check if the input from the player is correct and matches with the declared correct padlock combination
    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "WheelOne":
                result[0] = number;
                break;

            case "WheelTwo":
                result[1] = number;
                break;

            case "WheelThree":
                result[2] = number;
                break;

            case "WheelFour":
                result[3] = number;
                break;
        }

        //checking if each result for each padlock number wheel matches with the correct combination
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isPadlockOpened)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
            //invoke the coroutine which will tell the player that they have successfully input the correct padlock combination
            StartCoroutine(correctCoroutine());
            //set padlock opened bool to true
            isPadlockOpened = true;
        }
    }

    //IEnumerator function to display the correct pop up on in the padlock scene to let the player know they have input the correct padlock combination
    IEnumerator correctCoroutine()
    {
        correctImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        correctImage.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
