using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
  void awake(){
      //Dont destroy the audio
      DontDestroyOnLoad(transform.gameObject);
  }
}
