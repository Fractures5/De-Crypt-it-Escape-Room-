using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{

    [SerializeField] private ConfirmationWindow RestartConfirmationWindow;
    //public GameObject player;

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

    void restartStatus()
    {
        StorePlayerLocation.savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
        StorePlayerLocation.restartStatus = true;
        GameObject[] allLights= GameObject.FindGameObjectsWithTag("SwitchLight");
        //Getting audio source component
        foreach (GameObject i in allLights)
        { 
            i.SetActive(false); 
        } 
        FuseboxLoad.taskComplete = false;
        KeyPadLoad.taskComplete = false;
        QuizLoad.taskComplete = false;
        PhoneDecoy.taskComplete = false;
        ArcadeLoad.taskComplete = false;
        FlashlightController.FlashlightActive = false;
        TimerCountdown.timeLeft = 1800;
        //TimerCountdown.minutes = Mathf.FloorToInt(TimerCountdown.timeLeft / 60F);
        //TimerCountdown.seconds = Mathf.FloorToInt(TimerCountdown.timeLeft - TimerCountdown.minutes * 60);

    }
    private void YesClicked()
    {
        RestartConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes Clicked");
        Debug.Log("You chose to restart the game");
        restartStatus();
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    private void NoClicked()
    {
        RestartConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No Clicked");
        Debug.Log("You chose to NOT restart the game");
    }
}
