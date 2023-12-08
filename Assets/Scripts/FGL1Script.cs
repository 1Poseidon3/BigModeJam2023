using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FGL1Script : MonoBehaviour
{
    private enum InputState
    {
        None,
        FirstDown,
        Combo,
        FirstUp
    }

    private InputState current = InputState.None;
    private readonly KeyCode[] allowedInputKeys = { KeyCode.S, KeyCode.D, KeyCode.DownArrow, KeyCode.RightArrow };
    void Update()
    {
        switch (current)
        {
            case InputState.None:
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    current = InputState.FirstDown;
                    Debug.Log("Entered First Down State");
                }
                break;

            case InputState.FirstDown:
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    current = InputState.Combo;
                    Debug.Log("Entered Combo State from First Down State");
                }
                else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                {
                    current = InputState.None;
                    Debug.Log("Entered None State from First Down State");
                }
                break;

            case InputState.Combo:
                if (Input.GetKeyUp(KeyCode.S) | Input.GetKeyUp(KeyCode.DownArrow))
                {
                    current = InputState.FirstUp;
                    Debug.Log("Entered First Up State from Combo State");
                }
                else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    current = InputState.None;
                    Debug.Log("Entered None State from Combo State");
                }
                break;

            case InputState.FirstUp:
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    current = InputState.None;
                    Debug.Log("Key sequence complete!");
                }
                break;
        }
    }
}
