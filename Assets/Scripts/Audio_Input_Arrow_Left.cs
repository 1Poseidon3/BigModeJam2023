using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Input_Arrow_Left : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Input");
        }

    }
}

