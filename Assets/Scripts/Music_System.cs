using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Music_System : MonoBehaviour

{
    private static FMOD.Studio.EventInstance  MiniGameMusic_150BPM;
    // Start is called before the first frame update
    void Start()
    {
        
        MiniGameMusic_150BPM = FMODUnity.RuntimeManager.CreateInstance("event:/MiniGame_Music_150BPM");
        MiniGameMusic_150BPM.start();
        MiniGameMusic_150BPM.release();

        DontDestroyOnLoad(GameObject.Find("MiniGame_Music_150BPM"));
        
    }
    
}
