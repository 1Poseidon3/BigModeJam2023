using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FGL2Script : MonoBehaviour
{
    private enum InputState
    {
        None,
        FirstDown,
        FirstUp,
        SecondDown,
        SecondUp,
        ThirdDown,
        ThirdUp
    }
    private InputState current = InputState.None;

    public GameObject levelLoader;

    void Update()
    {
        switch (current)
        {
            case InputState.None:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    current = InputState.FirstDown;
                break;

            case InputState.FirstDown:
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                    current = InputState.FirstUp;
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    current = InputState.None;
                break;

            case InputState.FirstUp:
                if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow))
                    current = InputState.SecondDown;
                else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                    current = InputState.None;
                break;

            case InputState.SecondDown:
                if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                    current = InputState.SecondUp;
                else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    current = InputState.None;
                break;

            case InputState.SecondUp:
                if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
                    current = InputState.ThirdDown;
                break;

            case InputState.ThirdDown:
                if (Input.GetKeyUp(KeyCode.D) | Input.GetKeyUp(KeyCode.RightArrow))
                    current = InputState.ThirdUp;
                break;

            case InputState.ThirdUp:
                LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
                lls.LoadNextLevel();
                break;
        }
    }
}
