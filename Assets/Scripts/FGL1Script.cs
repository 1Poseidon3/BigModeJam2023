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

    public GameObject levelLoader;

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
