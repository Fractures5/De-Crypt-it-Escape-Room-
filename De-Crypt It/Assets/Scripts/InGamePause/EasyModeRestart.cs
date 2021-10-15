using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyModeRestart : MonoBehaviour
{
    //This script will run and reset necesary variables when the player wishes to restart the game
    [SerializeField] private ConfirmationWindow RestartConfirmationWindow;

    // Start is called before the first frame update
    void Start()
    {
        OpenConfirmationWindow();
    }

    private void OpenConfirmationWindow()
    {
        RestartConfirmationWindow.gameObject.SetActive(true);
        RestartConfirmationWindow.yesButton.onClick.AddListener(YesClicked);
        RestartConfirmationWindow.noButton.onClick.AddListener(NoClicked);
    }
    //This function restarts all the necessary ingame variables and objects
    void restartStatus()
    {
        StorePlayerLocation.savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
        StorePlayerLocation.restartStatus = true;

        PadLockDrop.hasClipPlayed = false;
        PadLockDrop.hasEnumeratorRan = false;
        BatteryInteraction.isBatteryCollected = false;
        //EnvironmentKey.hasWrongEnvKeyClltd = false;
        EnvironmentKeyRed.hasWrongEnvKeyClltd = false;
        Target.isKeyCollected = false;
        LockControl.isPadlockOpened = false;
        FlashlightController.FlashlightActive = false;
        UvLightController.UvLightActive = false;
        
        TimerCountdown.timeLeft = 3600;

    }
    private void YesClicked()
    {
        RestartConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes Clicked");
        Debug.Log("You chose to restart the game");
        restartStatus();
        SceneManager.LoadScene("EasyGame");
        Time.timeScale = 1;
    }

    private void NoClicked()
    {
        RestartConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No Clicked");
        Debug.Log("You chose to NOT restart the game");
    }
}
