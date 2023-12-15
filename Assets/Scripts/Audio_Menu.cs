using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Menu : MonoBehaviour
{
  private FMOD.Studio.EventInstance instance;
  
  void Update() 
  {
    if (Input.GetKeyDown(KeyCode.Space)) 
    {
      instance = FMODUnity.RuntimeManager.CreateInstance("event:/LoopEvent");
      instance.start();
    }
  }


}
