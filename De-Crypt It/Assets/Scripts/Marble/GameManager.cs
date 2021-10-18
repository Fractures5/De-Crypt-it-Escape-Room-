using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class will be used to store the instance of the game.
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform lastCheckPoint;
    private void Awake()
    {
        Instance = this;
    }
}
