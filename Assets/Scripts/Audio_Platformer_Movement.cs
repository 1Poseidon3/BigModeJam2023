using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Platformer_Movement : MonoBehaviour
{
  private FMOD.Studio.EventInstance instance;
  
  void Update() 
{
    if (Input.GetKeyDown(KeyCode.A)) 
    {
      instance = FMODUnity.RuntimeManager.CreateInstance("event:/MiniGame_Running");
      instance.start();
    }
    if (Input.GetKeyUp(KeyCode.A)) 
    {
      instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
      instance.release();
    }

    if (Input.GetKeyDown(KeyCode.D)) 
    {
      instance = FMODUnity.RuntimeManager.CreateInstance("event:/MiniGame_Running");
      instance.start();
    }
    if (Input.GetKeyUp(KeyCode.D)) 
    {
      instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
      instance.release();
    }
  }

  
}