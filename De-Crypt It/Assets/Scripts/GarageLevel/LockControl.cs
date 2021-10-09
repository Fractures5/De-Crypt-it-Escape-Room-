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
    private void Start()
    {
        result = new int[]{0,0,0,0};
        correctCombination = new int[] {3,9,1,0};
        //isPadlockOpened = false;
        Rotate.Rotated += CheckResults;
    }

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

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isPadlockOpened)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
            StartCoroutine(correctCoroutine());
            isPadlockOpened = true;
            Debug.Log("Padlock is unlocked now");
        }

    }

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
