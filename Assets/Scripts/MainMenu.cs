using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelLoader;
    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnStartClick()
    {

        LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
        lls.LoadNextLevel();

        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_UI_Click");
    }

}
