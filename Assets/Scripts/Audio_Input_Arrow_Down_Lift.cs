using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Input_Arrow_Down_Lift : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Input");
        }

    }
}

