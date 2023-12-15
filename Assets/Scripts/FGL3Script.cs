using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FGL3Script : MonoBehaviour
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
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    current = InputState.None;
                break;

            case InputState.FirstUp:
                if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow))
                    current = InputState.SecondDown;
                else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                    current = InputState.None;
                break;

            case InputState.SecondDown:
                if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                    current = InputState.SecondUp;
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    current = InputState.None;
                break;

            case InputState.SecondUp:
                if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
                    current = InputState.ThirdDown;
                break;

            case InputState.ThirdDown:
                if (Input.GetKeyUp(KeyCode.A) | Input.GetKeyUp(KeyCode.LeftArrow))
                    current = InputState.ThirdUp;
                break;

            case InputState.ThirdUp:
                LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
                lls.LoadNextLevel();
                break;
        }
    }
}
