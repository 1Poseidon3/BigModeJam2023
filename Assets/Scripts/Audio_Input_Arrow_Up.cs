using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Input_Arrow_Up : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Input");
        }

    }
}

