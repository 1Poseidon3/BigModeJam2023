using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump_Audio : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Jump");
        }
    }
}
