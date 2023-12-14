using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Input_Arrow_Down : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Input");
        }

    }
}

