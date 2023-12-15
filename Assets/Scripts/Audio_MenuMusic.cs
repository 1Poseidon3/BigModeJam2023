using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_MenuMusic : MonoBehaviour

{
    public FMOD.Studio.EventInstance instance;
    
 

    // Update is called once per frame
    void Start()
    {
    instance = FMODUnity.RuntimeManager.CreateInstance("event:/Menu_Music");
    instance.start();
    instance.release();
    }


}
