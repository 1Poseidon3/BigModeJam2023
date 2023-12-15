using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MUSIC_150BPM : MonoBehaviour
{
    public static MUSIC_150BPM instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}