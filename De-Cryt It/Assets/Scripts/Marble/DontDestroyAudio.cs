using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
  void awake(){
      DontDestroyOnLoad(transform.gameObject);
  }
}
