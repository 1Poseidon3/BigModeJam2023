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

    public GameObject levelLoader;

    private InputState current = InputState.None;
    private readonly KeyCode[] allowedInputKeys = { KeyCode.S, KeyCode.D, KeyCode.DownArrow, KeyCode.RightArrow };

    private void Start()
    {}

    void Update()
    {
        switch (current)
        {
            case InputState.None:
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    current = InputState.FirstDown;
                break;

            case InputState.FirstDown:
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    current = InputState.Combo;
                else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                    current = InputState.None;
                break;

            case InputState.Combo:
                if (Input.GetKeyUp(KeyCode.S) | Input.GetKeyUp(KeyCode.DownArrow))
                    current = InputState.FirstUp;
                else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                    current = InputState.None;
                break;

            case InputState.FirstUp:
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
                    lls.LoadNextLevel();
                }
                break;
        }
    }
}
