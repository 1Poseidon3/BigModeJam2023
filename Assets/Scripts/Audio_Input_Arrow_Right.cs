using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Input_Arrow_Right : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Input");
        }

    }
}

